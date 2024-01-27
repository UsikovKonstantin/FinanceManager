using MediatR;

namespace FinanceManager.Application.Features.Invitations.Queries;

public class GetInvitationsQuery : IRequest<IEnumerable<InvitationResponse>>
{
    public string? Type { get; set; }
}
