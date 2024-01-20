using FluentValidation;

namespace FinanceManager.Application.Features.Teams.Commands;

public class ChangeMyTeamNameCommandValidator : AbstractValidator<ChangeMyTeamNameCommand>
{
    public ChangeMyTeamNameCommandValidator()
    {
		RuleFor(c => c.Name)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters");
	}
}
