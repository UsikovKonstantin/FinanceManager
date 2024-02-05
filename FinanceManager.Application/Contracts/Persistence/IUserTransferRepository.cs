using FinanceManager.Domain;

namespace FinanceManager.Application.Contracts.Persistence;

public interface IUserTransferRepository : IGenericRepository<UserTransfer>
{
	public Task<IEnumerable<UserTransfer>> GetUserTransfers(string? from, string? to,
		DateTime? startDate, DateTime? endDate, int pageSize, int page, string? sortColumn, string? sortOrder);
}
