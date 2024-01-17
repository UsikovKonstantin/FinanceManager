using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.Refresh;

public class RefreshCommandValidator : AbstractValidator<RefreshCommand>
{
    public RefreshCommandValidator()
    {
		RuleFor(r => r.AccessToken)
			.NotEmpty().WithMessage("{PropertyName} is required");

		RuleFor(r => r.RefreshToken)
			.NotEmpty().WithMessage("{PropertyName} is required");
	}
}
