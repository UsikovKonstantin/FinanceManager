using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;

namespace FinanceManager.Persistence.Repositories;

public class InvitationRepository : GenericRepository<Invitation>, IInvitationRepository
{
	public InvitationRepository(FinanceManagerDatabaseContext context) : base(context)
	{

	}
}
