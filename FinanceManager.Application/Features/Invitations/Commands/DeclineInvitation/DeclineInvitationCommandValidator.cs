using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Invitations.Commands.DeclineInvitation;

public class DeclineInvitationCommandValidator : AbstractValidator<DeclineInvitationCommand>
{
	private readonly IUserService _userService;
	private readonly IInvitationRepository _invitationRepository;

	public DeclineInvitationCommandValidator(IUserService userService, IInvitationRepository invitationRepository)
    {
		_userService = userService;
		_invitationRepository = invitationRepository;

		RuleFor(i => i.Id)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.GreaterThan(0).WithMessage("{PropertyName} must be more than {ComparisonValue}")
			.MustAsync(InvitationToAuthUser).WithMessage("This invitation is not yours");
	}

	private async Task<bool> InvitationToAuthUser(int id, CancellationToken token)
	{
		Invitation? invitation = await _invitationRepository.GetByIdAsync(id);
		return invitation == null || invitation.UserToId == _userService.UserId || invitation.UserFromId == _userService.UserId;
	}
}
