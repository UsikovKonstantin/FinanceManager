using FinanceManager.Domain;

namespace FinanceManager.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
	Task<IEnumerable<string>> GetRolesByUserIdAsync(int userId);
	Task<bool> IsUserInRoleAsync(int userId, string roleName);
	Task AddUserToRoleAsync(int userId, string roleName);
	Task RemoveUserFromRoleAsync(int userId, string roleName);
}
