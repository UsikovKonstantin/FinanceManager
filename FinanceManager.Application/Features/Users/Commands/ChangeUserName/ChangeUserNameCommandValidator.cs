using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Features.Auth.Shared;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.Users.Commands.ChangeUserName;

public class ChangeUserNameCommandValidator : AbstractValidator<ChangeUserNameCommand>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

    public ChangeUserNameCommandValidator(IUserService userService, IUserRepository userRepository)
    {
		_userService = userService;
		_userRepository = userRepository;

		RuleFor(p => p.Password)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MustAsync(PasswordCorrect).WithMessage("Incorrect password");

		RuleFor(u => u.NewUserName)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.MaximumLength(50).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
			.MustAsync(UserNameUnique).WithMessage("User with this {PropertyName} already exists")
			.MustAsync(UserNameNew).WithMessage("{PropertyName} must be new");
	}

	private async Task<bool> UserNameNew(string userName, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		return user == null || user.UserName != userName;
	}

	private async Task<bool> UserNameUnique(string userName, CancellationToken token)
	{
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.UserName == userName);
		return user == null || user.Id == _userService.UserId;
	}

	private async Task<bool> PasswordCorrect(string password, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		return user == null || SecretHasher.Verify(password, user.Password);
	}
}
