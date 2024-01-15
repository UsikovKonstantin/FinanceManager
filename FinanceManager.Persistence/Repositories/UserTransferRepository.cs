using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;

namespace FinanceManager.Persistence.Repositories;

public class UserTransferRepository : GenericRepository<UserTransfer>, IUserTransferRepository
{
	public UserTransferRepository(FinanceManagerDatabaseContext context) : base(context)
	{

	}
}
