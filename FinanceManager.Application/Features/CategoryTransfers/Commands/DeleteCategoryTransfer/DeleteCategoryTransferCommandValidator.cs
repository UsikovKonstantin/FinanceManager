using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.CategoryTransfers.Commands.DeleteCategoryTransfer;

public class DeleteCategoryTransferCommandValidator : AbstractValidator<DeleteCategoryTransferCommand>
{
	private readonly ICategoryTransferRepository _categoryTransferRepository;
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

    public DeleteCategoryTransferCommandValidator(ICategoryTransferRepository categoryTransferRepository,
		IUserRepository userRepository, IUserService userService)
    {
		_categoryTransferRepository = categoryTransferRepository;
		_userRepository = userRepository;
		_userService = userService;

		RuleFor(ct => ct.Id)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.GreaterThan(0).WithMessage("{PropertyName} must be more than {ComparisonValue}")
			.MustAsync(UserIsOwner).WithMessage("You are not owner of this transfer")
			.MustAsync(UserHasEnoughBalance).WithMessage("Not enough balance");
	}

	private async Task<bool> UserIsOwner(int id, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);

		CategoryTransfer? categoryTransfer = await _categoryTransferRepository.GetByIdAsync(id);

		return user == null || categoryTransfer == null || categoryTransfer.UserId == user.Id;
	}

	private async Task<bool> UserHasEnoughBalance(int id, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);

		CategoryTransfer? categoryTransfer = await _categoryTransferRepository.GetByIdAsync(id);

		return user == null || categoryTransfer == null || user.Balance - categoryTransfer.Amount >= 0;
	}
}
