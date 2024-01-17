using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;

namespace FinanceManager.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
	public UserRepository(FinanceManagerDatabaseContext context) : base(context)
	{

	}

	public async Task AddUserToRole(int userId, string roleName)
	{
		Role? role = _context.Roles.FirstOrDefault(r => r.Name == roleName);
		if (role != null)
		{
			UserRole userRole = new UserRole 
			{
				UserId = userId,
				RoleId = role.Id
			};
			await _context.UserRoles.AddAsync(userRole);
		}
	}
}
