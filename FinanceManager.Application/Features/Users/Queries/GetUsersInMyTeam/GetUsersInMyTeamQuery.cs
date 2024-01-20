using MediatR;

namespace FinanceManager.Application.Features.Users.Queries.GetUsersInMyTeam;

public class GetUsersInMyTeamQuery : IRequest<IEnumerable<UserInMyTeamResponse>>
{

}
