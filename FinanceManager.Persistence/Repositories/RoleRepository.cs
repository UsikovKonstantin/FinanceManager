using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Persistence.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
	public RoleRepository(FinanceManagerDatabaseContext context) : base(context)
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
}
