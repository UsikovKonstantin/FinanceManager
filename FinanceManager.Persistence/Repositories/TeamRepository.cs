using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;

namespace FinanceManager.Persistence.Repositories;

public class TeamRepository : GenericRepository<Team>, ITeamRepository
{
	public TeamRepository(FinanceManagerDatabaseContext context) : base(context)
	{

	}
}
