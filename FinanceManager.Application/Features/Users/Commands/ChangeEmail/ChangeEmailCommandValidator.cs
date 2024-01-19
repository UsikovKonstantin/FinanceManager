using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.ChangeEmail;

public class ChangeEmailCommandValidator : AbstractValidator<ChangeEmailCommand>
{
	private readonly IUserRepository _userRepository;

    public ChangeEmailCommandValidator(IUserRepository userRepository)
    {
		_userRepository = userRepository;

		RuleFor(c => c.Password)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MinimumLength(6).WithMessage("{PropertyName} must be more than {MinLength} characters")
			.MaximumLength(150).WithMessage("{PropertyName} must be fewer than {MaxLength} characters");

		RuleFor(c => c.NewEmail)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
			.EmailAddress().WithMessage("{PropertyName} is not valid")
			.MustAsync(EmailUniqueAsync).WithMessage("Email already taken");
	}

	private async Task<bool> EmailUniqueAsync(string email, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.Email == email);
		return user == null;
	}
}
