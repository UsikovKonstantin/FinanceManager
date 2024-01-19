using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Auth.Commands.ConfirmRegistration;

public class ConfirmRegistrationCommandValidator : AbstractValidator<ConfirmRegistrationCommand>
{
	private readonly IUserRepository _userRepository;

    public ConfirmRegistrationCommandValidator(IUserRepository userRepository)
    {
		_userRepository = userRepository;

		RuleFor(c => c.RegistrationToken)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MustAsync(TokenNotExpired).WithMessage("{PropertyName} has already expired");
	}

	private async Task<bool> TokenNotExpired(string registrationToken, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.RegistrationToken == registrationToken);
		return user == null || user.RegistrationTokenExpirationDate > DateTime.UtcNow;
	}
}
