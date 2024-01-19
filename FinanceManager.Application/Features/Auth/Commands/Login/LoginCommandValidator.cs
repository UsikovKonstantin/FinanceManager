using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Features.Auth.Shared;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    private readonly IUserRepository _userRepository;

    public LoginCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(l => l.Email)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
            .EmailAddress().WithMessage("{PropertyName} is not valid");

        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MinimumLength(6).WithMessage("{PropertyName} must be more than {MinLength} characters")
            .MaximumLength(150).WithMessage("{PropertyName} must be fewer than {MaxLength} characters");

        RuleFor(l => l)
            .MustAsync(PasswordCorrect).WithMessage("Incorrect password");

	}

	private async Task<bool> PasswordCorrect(LoginCommand command, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.Email == command.Email);
        return user == null || SecretHasher.Verify(command.Password, user.Password);
	}
}
