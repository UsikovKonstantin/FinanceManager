using MediatR;

namespace FinanceManager.Application.Features.Invitations.Queries;

public class GetInvitationsQuery : IRequest<IEnumerable<InvitationResponse>>
{
	public bool FromMe { get; set; }
	public bool ToMe { get; set; }
}
