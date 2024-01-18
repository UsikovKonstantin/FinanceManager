using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.ResetPassword;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
		RuleFor(u => u.Token)
			.NotEmpty().WithMessage("{PropertyName} is required");

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
			.Must(u => u.Password == u.ConfirmPassword).WithMessage("Password must equal to ConfirmPassword");
	}
}
