using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.UserTransfers.Commands.CreateUserTransfer;

public class CreateUserTransferCommandValidator : AbstractValidator<CreateUserTransferCommand>
{
	private readonly IUserService _userService;
	private readonly IUserRepository _userRepository;

	public CreateUserTransferCommandValidator(IUserService userService, IUserRepository userRepository)
	{
		_userService = userService;
		_userRepository = userRepository;

		RuleFor(ut => ut.UserToId)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.GreaterThan(0).WithMessage("{PropertyName} must be more than {ComparisonValue}")
			.MustAsync(UserToCheck).WithMessage("You can't make transfer to you");

		RuleFor(ut => ut.Amount)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.GreaterThan(0).WithMessage("{PropertyName} must be more than {ComparisonValue}")
			.LessThan(100000).WithMessage("{PropertyName} must be less than {ComparisonValue}");

		RuleFor(ut => ut.DoneAt)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.LessThan(DateTime.Now).WithMessage("{PropertyName} must be less than Now");

		RuleFor(ut => ut.Description)
			.MaximumLength(100).WithMessage("{PropertyName} must be fewer than {MaxLength} characters");

		RuleFor(ut => ut)
			.MustAsync(UserBalanceCheck).WithMessage("You don't have enough money");
	}

	private async Task<bool> UserToCheck(int userToId, CancellationToken token)
	{
		User? userTo = await _userRepository.GetByIdAsync(userToId);
		return userTo == null || userTo.Id != _userService.UserId;
	}

	private async Task<bool> UserBalanceCheck(CreateUserTransferCommand command, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		return user == null || user.Balance - command.Amount >= 0;
	}
}
