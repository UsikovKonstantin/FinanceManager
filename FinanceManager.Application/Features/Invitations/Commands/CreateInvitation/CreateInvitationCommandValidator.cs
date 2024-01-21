using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Invitations.Commands.CreateInvitation;

public class CreateInvitationCommandValidator : AbstractValidator<CreateInvitationCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
	private readonly IInvitationRepository _invitationRepository;

	public CreateInvitationCommandValidator(IUserRepository userRepository, IUserService userService, IInvitationRepository invitationRepository)
    {
        _userRepository = userRepository;
        _userService = userService;
        _invitationRepository = invitationRepository;

        RuleFor(i => i.UserToId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be more than {ComparisonValue}")
            .MustAsync(NotInSameTeam).WithMessage("This user is in your team")
            .MustAsync(InvitationUnique).WithMessage("This invitation already exists");
	}

	private async Task<bool> InvitationUnique(int userToId, CancellationToken token)
	{
		int userFromId = _userService.UserId;
		User? userFrom = await _userRepository.GetByIdAsync(userFromId);

		User? userTo = await _userRepository.GetByIdAsync(userToId);

        Invitation? invitation = await _invitationRepository.FirstOrDefaultAsync(i => i.UserFromId == userFromId && i.UserToId == userToId);

		return userFrom == null || userTo == null || invitation == null;
	}

	private async Task<bool> NotInSameTeam(int userToId, CancellationToken token)
    {
        int userFromId = _userService.UserId;
        User? userFrom = await _userRepository.GetByIdAsync(userFromId);

        User? userTo = await _userRepository.GetByIdAsync(userToId);

        return userFrom == null || userTo == null || userFrom.TeamId != userTo.TeamId;
    }
}
