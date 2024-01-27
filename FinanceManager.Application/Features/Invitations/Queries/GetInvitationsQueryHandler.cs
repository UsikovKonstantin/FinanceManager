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
		bool fromMeNeeded = request.Type == null || request.Type.ToLower() == "fromme";
		bool toMeNeeded = request.Type == null || request.Type.ToLower() == "tome";

		IEnumerable<Invitation> invitations = await _invitationRepository.GetWhereAsync(
			i => (fromMeNeeded && i.UserFromId == _userService.UserId) || (toMeNeeded && i.UserToId == _userService.UserId));

		IEnumerable<InvitationResponse> invitationResponses = _mapper.Map<IEnumerable<InvitationResponse>>(invitations);

		return invitationResponses;
	}
}
