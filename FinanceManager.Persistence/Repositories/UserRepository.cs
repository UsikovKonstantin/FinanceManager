using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
	public UserRepository(FinanceManagerDatabaseContext context) : base(context)
	{

	}

	public async Task<IEnumerable<string>> GetRolesByUserIdAsync(int userId)
	{
		return await _context.UserRoles
			.AsNoTracking()
			.Where(ur => ur.UserId == userId)
			.Include(ur => ur.Role)
			.Select(ur => ur.Role == null ? "No role" : ur.Role.Name)
			.ToListAsync();
	}

	public async Task<bool> IsUserInRoleAsync(int userId, string roleName)
	{
		return await _context.UserRoles
			.AsNoTracking()
			.Where(ur => ur.UserId == userId)
			.Include(ur => ur.Role)
			.AnyAsync(ur => ur.Role == null ? false : ur.Role.Name == roleName);
	}

	public async Task AddUserToRoleAsync(int userId, string roleName)
	{
		Role? role = _context.Roles.FirstOrDefault(r => r.Name == roleName);
		if (role != null)
		{
			UserRole? userRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == role.Id);
			if (userRole == null)
			{
				UserRole userRoleToAdd = new UserRole
				{
					UserId = userId,
					RoleId = role.Id
				};
				await _context.UserRoles.AddAsync(userRoleToAdd);
				await _context.SaveChangesAsync();
			}
		}
	}

	public async Task RemoveUserFromRoleAsync(int userId, string roleName)
	{
		Role? role = _context.Roles.FirstOrDefault(r => r.Name == roleName);
		if (role != null)
		{
			UserRole? userRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == role.Id);
			if (userRole != null)
			{
				_context.UserRoles.Remove(userRole);
				await _context.SaveChangesAsync();
			}
		}
	}
}
