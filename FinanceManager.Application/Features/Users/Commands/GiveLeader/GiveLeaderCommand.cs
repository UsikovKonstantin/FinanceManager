using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.GiveLeader;

public class GiveLeaderCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
