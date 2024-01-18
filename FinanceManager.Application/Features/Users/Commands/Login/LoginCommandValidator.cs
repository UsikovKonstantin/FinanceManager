using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
		RuleFor(l => l.Email)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
			.EmailAddress().WithMessage("{PropertyName} is not valid");

		RuleFor(l => l.Password)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MinimumLength(6).WithMessage("{PropertyName} must be more than {MinLength} characters")
			.MaximumLength(150).WithMessage("{PropertyName} must be fewer than {MaxLength} characters");
	}
}
