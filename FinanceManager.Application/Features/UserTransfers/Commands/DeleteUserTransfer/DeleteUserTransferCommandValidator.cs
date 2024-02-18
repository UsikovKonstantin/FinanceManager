using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.UserTransfers.Commands.DeleteUserTransfer;

public class DeleteUserTransferCommandValidator : AbstractValidator<DeleteUserTransferCommand>
{
	private readonly IUserTransferRepository _userTransferRepository;
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

	public DeleteUserTransferCommandValidator(IUserTransferRepository userTransferRepository,
		IUserRepository userRepository, IUserService userService)
    {
		_userTransferRepository = userTransferRepository;
		_userRepository = userRepository;
		_userService = userService;

		RuleFor(ut => ut.Id)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.GreaterThan(0).WithMessage("{PropertyName} must be more than {ComparisonValue}")
			.MustAsync(UserIsOwner).WithMessage("You are not owner of this transfer")
			.MustAsync(UserToHasEnoughBalance).WithMessage("Not enough balance");
	}

	private async Task<bool> UserIsOwner(int id, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);

		UserTransfer? userTransfer = await _userTransferRepository.GetByIdAsync(id);

		return user == null || userTransfer == null || userTransfer.UserFromId == user.Id;
	}

	private async Task<bool> UserToHasEnoughBalance(int id, CancellationToken token)
	{
		UserTransfer? userTransfer = await _userTransferRepository.GetByIdAsync(id);

		User? userTo = await _userRepository.GetByIdAsync(userTransfer == null ? 0 : userTransfer.UserToId);

		return userTransfer == null || userTo == null || userTo.Balance - userTransfer.Amount >= 0;
	}
}
