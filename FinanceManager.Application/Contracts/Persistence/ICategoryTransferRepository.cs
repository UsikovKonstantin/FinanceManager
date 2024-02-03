using FinanceManager.Domain;

namespace FinanceManager.Application.Contracts.Persistence;

public interface ICategoryTransferRepository : IGenericRepository<CategoryTransfer>
{
	public Task<IEnumerable<CategoryTransfer>> GetCategoryTransfers(string? from, string? type, int? categoryId,
		DateTime? startDate, DateTime? endDate, int pageSize, int page, string? sortColumn, string? sortOrder);
}
