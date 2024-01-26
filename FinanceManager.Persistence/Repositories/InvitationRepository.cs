using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Persistence.Repositories;

public class InvitationRepository : GenericRepository<Invitation>, IInvitationRepository
{
	public InvitationRepository(FinanceManagerDatabaseContext context) : base(context)
	{

	}

	public async Task<IEnumerable<Invitation>> GetByUserToIdAndUserFromTeamId(int userToId, int userFromTeamId)
	{
		return await _context.Invitations
			.AsNoTracking()
			.Where(i => i.UserToId == userToId)
			.Include(i => i.UserFrom)
			.Where(i => i.UserFrom == null ? false : i.UserFrom.TeamId == userFromTeamId)
			.ToListAsync();
	}

	public async Task<IEnumerable<Invitation>> GetByUserFromIdAndUserToTeamId(int userFromId, int userToTeamId)
	{
		return await _context.Invitations
			.AsNoTracking()
			.Where(i => i.UserFromId == userFromId)
			.Include(i => i.UserTo)
			.Where(i => i.UserTo == null ? false : i.UserTo.TeamId == userToTeamId)
			.ToListAsync();
	}
}
