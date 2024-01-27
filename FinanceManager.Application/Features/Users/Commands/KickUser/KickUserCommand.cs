using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.KickUser;

public class KickUserCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
