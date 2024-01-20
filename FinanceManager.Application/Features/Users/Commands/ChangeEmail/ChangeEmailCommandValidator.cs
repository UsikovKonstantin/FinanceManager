using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Features.Auth.Shared;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.ChangeEmail;

public class ChangeEmailCommandValidator : AbstractValidator<ChangeEmailCommand>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

	public ChangeEmailCommandValidator(IUserRepository userRepository, IUserService userService)
    {
		_userRepository = userRepository;
		_userService = userService;

		RuleFor(c => c.Password)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MinimumLength(6).WithMessage("{PropertyName} must be more than {MinLength} characters")
			.MaximumLength(150).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
			.MustAsync(PasswordCorrect).WithMessage("Incorrect password");

		RuleFor(c => c.NewEmail)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
			.EmailAddress().WithMessage("{PropertyName} is not valid")
			.MustAsync(EmailUniqueAsync).WithMessage("Email already taken")
			.MustAsync(EmailNewAsync).WithMessage("Email must be new");
	}

	private async Task<bool> EmailNewAsync(string email, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		return user == null || user.Email != email;
	}

	private async Task<bool> PasswordCorrect(string password, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		return user == null || SecretHasher.Verify(password, user.Password);
	}

	private async Task<bool> EmailUniqueAsync(string email, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.Email == email);
		return user == null || user.Id == _userService.UserId;
	}
}
