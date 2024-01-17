using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
	private readonly IUserRepository _userRepository;

	public RegisterUserCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(u => u.UserName)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
			.MustAsync(UserNameUnique).WithMessage("User with this {PropertyName} already exists");

		RuleFor(u => u.FirstName)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters");

		RuleFor(u => u.LastName)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters");

		RuleFor(u => u.Gender)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.Must(gender => gender == 'M' || gender == 'F').WithMessage("Gender must be 'M' or 'F'");

		RuleFor(u => u.Email)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
			.EmailAddress().WithMessage("{PropertyName} is not valid")
			.MustAsync(UserEmailUnique).WithMessage("User with this {PropertyName} already exists");

		RuleFor(u => u.Password)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MinimumLength(6).WithMessage("{PropertyName} must be more than {MinLength} characters")
			.MaximumLength(150).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
			.Matches("[A-Z]").WithMessage("{PropertyName} must contain at least 1 upper letter")
			.Matches("[a-z]").WithMessage("{PropertyName} must contain at least 1 lower letter")
			.Matches("[0-9]").WithMessage("{PropertyName} must contain at least 1 digit");
	}

	private async Task<bool> UserEmailUnique(string email, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.Email == email);
		return user == null;
	}

	private async Task<bool> UserNameUnique(string userName, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.UserName == userName);
		return user == null;
	}
}
