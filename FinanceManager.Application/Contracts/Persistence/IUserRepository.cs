using FinanceManager.Domain;

namespace FinanceManager.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
	Task AddUserToRole(int userId, string roleName);
}
