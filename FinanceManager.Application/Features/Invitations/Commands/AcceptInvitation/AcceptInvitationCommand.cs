using MediatR;

namespace FinanceManager.Application.Features.Invitations.Commands.AcceptInvitation;

public class AcceptInvitationCommand : IRequest<Unit>
{
	public int Id { get; set; }
}
