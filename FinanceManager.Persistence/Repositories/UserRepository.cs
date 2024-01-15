using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;

namespace FinanceManager.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
	public UserRepository(FinanceManagerDatabaseContext context) : base(context)
	{

	}
}
