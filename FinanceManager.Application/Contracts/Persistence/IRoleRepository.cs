using FinanceManager.Domain;

namespace FinanceManager.Application.Contracts.Persistence;

public interface IRoleRepository : IGenericRepository<Role>
{
	Task<IEnumerable<string>> GetRolesByUserIdAsync(int userId);
}
