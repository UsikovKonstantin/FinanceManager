using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.ChangeEmailConfirm;

public class ChangeEmailConfirmCommandValidator : AbstractValidator<ChangeEmailConfirmCommand>
{
	private readonly IUserRepository _userRepository;

    public ChangeEmailConfirmCommandValidator(IUserRepository userRepository)
    {
		_userRepository = userRepository;

		RuleFor(c => c.ChangeEmailToken)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MustAsync(TokenNotExpired).WithMessage("{PropertyName} has already expired")
			.MustAsync(NewEmailUnique).WithMessage("User with this email already exists");
	}

	private async Task<bool> NewEmailUnique(string changeEmailToken, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.ChangeEmailToken == changeEmailToken);
		if (user == null)
			return true;
		
		User? user2 = await _userRepository.FirstOrDefaultAsync(u => u.Email == user.NewEmail);
		return user2 == null;
	}

	private async Task<bool> TokenNotExpired(string changeEmailToken, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.ChangeEmailToken == changeEmailToken);
		return user == null || user.ChangeEmailTokenExpirationDate > DateTime.UtcNow;
	}
}
