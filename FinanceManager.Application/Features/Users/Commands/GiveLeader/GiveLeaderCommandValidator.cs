using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.GiveLeader;

public class GiveLeaderCommandValidator : AbstractValidator<GiveLeaderCommand>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

	public GiveLeaderCommandValidator(IUserRepository userRepository, IUserService userService)
	{
		_userRepository = userRepository;
		_userService = userService;

		RuleFor(i => i.Id)
			.MustAsync(AuthUserIsLeader).WithMessage("You are not leader")
			.MustAsync(UserToIsMember).WithMessage("UserTo is not member")
			.MustAsync(UserToIsInSameTeam).WithMessage("User is not in your team");
	}

	private async Task<bool> AuthUserIsLeader(int userToId, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			return true;

		return await _userRepository.IsUserInRoleAsync(user.Id, "TeamLeader");
	}

	private async Task<bool> UserToIsMember(int userToId, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(userToId);
		if (user == null)
			return true;

		return await _userRepository.IsUserInRoleAsync(user.Id, "TeamMember");
	}

	private async Task<bool> UserToIsInSameTeam(int userToId, CancellationToken token)
	{
		int userFromId = _userService.UserId;
		User? userFrom = await _userRepository.GetByIdAsync(userFromId);

		User? userTo = await _userRepository.GetByIdAsync(userToId);

		return userFrom == null || userTo == null || userFrom.TeamId == userTo.TeamId;
	}
}
