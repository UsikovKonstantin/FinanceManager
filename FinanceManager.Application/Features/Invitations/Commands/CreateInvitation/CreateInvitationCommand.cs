using MediatR;

namespace FinanceManager.Application.Features.Invitations.Commands.CreateInvitation;

public class CreateInvitationCommand : IRequest<int>
{
    public int UserToId { get; set; }
}
