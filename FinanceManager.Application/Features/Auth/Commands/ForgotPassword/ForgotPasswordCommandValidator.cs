using FluentValidation;

namespace FinanceManager.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator()
    {
		RuleFor(f => f.Email)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
			.EmailAddress().WithMessage("{PropertyName} is not valid");
	}
}
