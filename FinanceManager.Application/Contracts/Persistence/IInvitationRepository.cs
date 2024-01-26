using FinanceManager.Domain;

namespace FinanceManager.Application.Contracts.Persistence;

public interface IInvitationRepository : IGenericRepository<Invitation>
{
	Task<IEnumerable<Invitation>> GetByUserToIdAndUserFromTeamId(int userToId, int userFromTeamId);
	Task<IEnumerable<Invitation>> GetByUserFromIdAndUserToTeamId(int userFromId, int userToTeamId);
}
