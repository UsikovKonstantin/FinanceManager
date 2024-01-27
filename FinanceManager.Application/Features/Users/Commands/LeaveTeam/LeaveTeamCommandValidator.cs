using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.LeaveTeam;

public class LeaveTeamCommandValidator : AbstractValidator<LeaveTeamCommand>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

	public LeaveTeamCommandValidator(IUserRepository userRepository, IUserService userService)
    {
        _userRepository = userRepository;
		_userService = userService;

		RuleFor(i => i)
			.MustAsync(UserNotLeader).WithMessage("You can't leave team because you are leader");
	}

	private async Task<bool> UserNotLeader(LeaveTeamCommand command, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			return true;

		return await _userRepository.IsUserInRoleAsync(user.Id, "TeamLeader");
	}
}
