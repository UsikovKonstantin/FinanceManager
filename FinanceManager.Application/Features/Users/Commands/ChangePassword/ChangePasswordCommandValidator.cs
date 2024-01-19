using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
		RuleFor(p => p.CurrentPassword)
			.NotEmpty().WithMessage("{PropertyName} is required");

		RuleFor(p => p.NewPassword)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MinimumLength(6).WithMessage("{PropertyName} must be more than {MinLength} characters")
			.MaximumLength(150).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
			.Matches("[A-Z]").WithMessage("{PropertyName} must contain at least 1 upper letter")
			.Matches("[a-z]").WithMessage("{PropertyName} must contain at least 1 lower letter")
			.Matches("[0-9]").WithMessage("{PropertyName} must contain at least 1 digit");

		RuleFor(p => p.ConfirmNewPassword)
			.NotEmpty().WithMessage("{PropertyName} is required");

		RuleFor(p => p)
			.Must(p => p.NewPassword == p.ConfirmNewPassword).WithMessage("NewPassword must equal to ConfirmNewPassword")
			.Must(p => p.CurrentPassword != p.NewPassword).WithMessage("NewPassword must be new");
	}
}
