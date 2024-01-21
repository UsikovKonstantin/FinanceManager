using AutoMapper;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.Invitations.Queries;

public class GetInvitationsQueryHandler : IRequestHandler<GetInvitationsQuery, IEnumerable<InvitationResponse>>
{
	private readonly IInvitationRepository _invitationRepository;
	private readonly IUserService _userService;
	private readonly IMapper _mapper;

	public GetInvitationsQueryHandler(IInvitationRepository invitationRepository, IMapper mapper, IUserService userService)
	{
		_invitationRepository = invitationRepository;
		_mapper = mapper;
		_userService = userService;
	}

	public async Task<IEnumerable<InvitationResponse>> Handle(GetInvitationsQuery request, CancellationToken cancellationToken)
	{
		IEnumerable<Invitation> invitations = await _invitationRepository.GetWhereAsync(
			i => (request.FromMe && i.UserFromId == _userService.UserId) || (request.ToMe && i.UserToId == _userService.UserId));

		IEnumerable<InvitationResponse> invitationResponses = _mapper.Map<IEnumerable<InvitationResponse>>(invitations);

		return invitationResponses;
	}
}
