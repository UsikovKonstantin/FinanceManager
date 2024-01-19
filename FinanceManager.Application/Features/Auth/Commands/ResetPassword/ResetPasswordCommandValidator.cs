using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Features.Auth.Shared;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    private readonly IUserRepository _userRepository;

    public ResetPasswordCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(u => u.ResetPasswordToken)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(TokenNotExpired).WithMessage("{PropertyName} has already expired");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MinimumLength(6).WithMessage("{PropertyName} must be more than {MinLength} characters")
            .MaximumLength(150).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
            .Matches("[A-Z]").WithMessage("{PropertyName} must contain at least 1 upper letter")
            .Matches("[a-z]").WithMessage("{PropertyName} must contain at least 1 lower letter")
            .Matches("[0-9]").WithMessage("{PropertyName} must contain at least 1 digit");

        RuleFor(u => u.ConfirmPassword)
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(u => u)
            .Must(u => u.Password == u.ConfirmPassword).WithMessage("ConfirmPassword must equal to Password")
            .MustAsync(PasswordIsNew).WithMessage("Password must be new");
	}

	private async Task<bool> PasswordIsNew(ResetPasswordCommand command, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.ResetPasswordToken == command.ResetPasswordToken);
		return user == null || !SecretHasher.Verify(command.Password, user.Password);
	}

	private async Task<bool> TokenNotExpired(string resetPasswordToken, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.ResetPasswordToken == resetPasswordToken);
		return user == null || user.ResetPasswordTokenExpirationDate > DateTime.UtcNow;
	}
}
