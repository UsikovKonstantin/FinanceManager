using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;

namespace FinanceManager.Persistence.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
	public RoleRepository(FinanceManagerDatabaseContext context) : base(context)
	{

	}
}
