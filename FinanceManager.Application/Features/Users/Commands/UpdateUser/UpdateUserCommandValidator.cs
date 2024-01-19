using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
		RuleFor(u => u.FirstName)
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters");

		RuleFor(u => u.LastName)
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters");

		RuleFor(u => u.Gender)
			.MaximumLength(1).WithMessage("{PropertyName} must be {MaxLength} character long")
			.Must(gender => gender == null || gender == "M" || gender == "F").WithMessage("Gender must be 'M' or 'F'");
	}
}
