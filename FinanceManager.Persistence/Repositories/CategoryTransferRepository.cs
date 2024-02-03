using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceManager.Persistence.Repositories;

public class CategoryTransferRepository : GenericRepository<CategoryTransfer>, ICategoryTransferRepository
{
	private readonly IUserService _userService;

	public CategoryTransferRepository(FinanceManagerDatabaseContext context, IUserService userService) : base(context)
	{
		_userService = userService;
	}

	public async Task<IEnumerable<CategoryTransfer>> GetCategoryTransfers(string? from, string? type, int? categoryId, 
		DateTime? startDate, DateTime? endDate, int pageSize, int page, string? sortColumn, string? sortOrder)
	{
		// Найти пользователя, вызвавшего запрос
		User? user = await _context.Users.FindAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Выполнить выборку
		bool fromMeNeeded = from == null || from.ToLower() == "me";
		bool fromMyTeamNeeded = from != null && from.ToLower() == "myteam";
		bool incomeNeeded = type == null || type.ToLower() == "income";
		bool expensesNeeded = type == null || type.ToLower() == "expenses";
		bool categoryIdNeeded = categoryId != null;
		bool startDateNeeded = startDate != null;
		bool endDateNeeded = endDate != null;
		IQueryable<CategoryTransfer> categoryTransfersQuery = _context.CategoryTransfers
			.AsNoTracking()
			.Include(ct => ct.User)
			.Where(ct =>
				((fromMeNeeded && ct.UserId == user.Id) || (fromMyTeamNeeded && ((ct.User != null) ? ct.User.TeamId : 0) == user.TeamId)) &&
				((incomeNeeded && ct.Amount > 0) || (expensesNeeded && ct.Amount < 0)) &&
				(!startDateNeeded || ct.DoneAt >= startDate) &&
				(!endDateNeeded || ct.DoneAt <= endDate) &&
				(!categoryIdNeeded || ct.CategoryId == categoryId))
			.Skip((page - 1) * pageSize)
			.Take(pageSize);

		// Выполнить сортировку
		if (sortColumn == null)
			return await categoryTransfersQuery.ToListAsync();

		Expression<Func<CategoryTransfer, object?>> keySelector;
		switch (sortColumn.ToLower())
		{
			case "id":
				keySelector = p => p.Id;
				break;
			case "userid":
				keySelector = p => p.UserId;
				break;
			case "categoryid":
				keySelector = p => p.CategoryId;
				break;
			case "amount":
				keySelector = p => p.Amount;
				break;
			case "doneat":
				keySelector = p => p.DoneAt;
				break;
			case "description":
				keySelector = p => p.Description;
				break;
			default:
				throw new BadRequestException("Unknown sort column: " + sortColumn.ToLower());
		}

		IEnumerable<CategoryTransfer> categoryTransfers;
		sortOrder = sortOrder ?? "asc";
		if (sortOrder.ToLower() == "asc")
			categoryTransfers = await categoryTransfersQuery.OrderBy(keySelector).ToListAsync();
		else if (sortOrder.ToLower() == "desc")
			categoryTransfers = await categoryTransfersQuery.OrderByDescending(keySelector).ToListAsync();
		else
			throw new BadRequestException("Unknown sort order: " + sortColumn.ToLower());

		return categoryTransfersQuery;
	}
}
