using MediatR;

namespace FinanceManager.Application.Features.Invitations.Commands.DeclineInvitation;

public class DeclineInvitationCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
