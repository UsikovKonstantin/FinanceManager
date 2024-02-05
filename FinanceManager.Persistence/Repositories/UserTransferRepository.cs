using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceManager.Persistence.Repositories;

public class UserTransferRepository : GenericRepository<UserTransfer>, IUserTransferRepository
{
	private readonly IUserService _userService;

	public UserTransferRepository(FinanceManagerDatabaseContext context, IUserService userService) : base(context)
	{
		_userService = userService;
	}

	public async Task<IEnumerable<UserTransfer>> GetUserTransfers(string? from, string? to, 
		DateTime? startDate, DateTime? endDate, int pageSize, int page, string? sortColumn, string? sortOrder)
	{
		// Найти пользователя, вызвавшего запрос
		User? user = await _context.Users.FindAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Выполнить выборку
		if (from == null && to == null)
			from = "me";
		bool fromMeNeeded = from != null && from.ToLower() == "me";
		bool fromMyTeamNeeded = from != null && from.ToLower() == "myteam";
		bool toMeNeeded = to != null && to.ToLower() == "me";
		bool toMyTeamNeeded = to != null && to.ToLower() == "myteam";
		bool startDateNeeded = startDate != null;
		bool endDateNeeded = endDate != null;
		IQueryable<UserTransfer> userTransfersQuery = _context.UserTransfers
			.AsNoTracking()
			.Include(ut => ut.UserFrom)
			.Include(ut => ut.UserTo)
			.Where(ut =>
				((!fromMeNeeded && !fromMyTeamNeeded) || (fromMeNeeded && ut.UserFromId == user.Id) || (fromMyTeamNeeded && ((ut.UserFrom != null) ? ut.UserFrom.TeamId : 0) == user.TeamId)) &&
				((!toMeNeeded && !toMyTeamNeeded) || (toMeNeeded && ut.UserToId == user.Id) || (toMyTeamNeeded && ((ut.UserTo != null) ? ut.UserTo.TeamId : 0) == user.TeamId)) &&
				(!startDateNeeded || ut.DoneAt >= startDate) &&
				(!endDateNeeded || ut.DoneAt <= endDate));

		// Выполнить сортировку
		sortColumn = sortColumn ?? "id";
		Expression<Func<UserTransfer, object?>> keySelector;
		switch (sortColumn.ToLower())
		{
			case "id":
				keySelector = p => p.Id;
				break;
			case "userfromid":
				keySelector = p => p.UserFromId;
				break;
			case "usertoid":
				keySelector = p => p.UserToId;
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

		sortOrder = sortOrder ?? "asc";
		if (sortOrder.ToLower() == "asc")
			userTransfersQuery = userTransfersQuery.OrderBy(keySelector);
		else if (sortOrder.ToLower() == "desc")
			userTransfersQuery = userTransfersQuery.OrderByDescending(keySelector);
		else
			throw new BadRequestException("Unknown sort order: " + sortColumn.ToLower());

		IEnumerable<UserTransfer> userTransfers = await userTransfersQuery.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
		return userTransfersQuery;
	}
}
