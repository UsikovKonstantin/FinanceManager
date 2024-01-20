using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Features.Auth.Shared;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

    public ChangePasswordCommandValidator(IUserRepository userRepository, IUserService userService)
    {
		_userRepository = userRepository;
		_userService = userService;

		RuleFor(p => p.CurrentPassword)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MustAsync(PasswordCorrect).WithMessage("Incorrect password");

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

	private async Task<bool> PasswordCorrect(string password, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		return user == null || SecretHasher.Verify(password, user.Password);
	}
}
