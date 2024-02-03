using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FluentValidation;

namespace FinanceManager.Application.Features.CategoryTransfers.Commands.CreateCategoryTransfer;

public class CreateCategoryTransferCommandValidator : AbstractValidator<CreateCategoryTransferCommand>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IUserService _userService;
	private readonly IUserRepository _userRepository;

	public CreateCategoryTransferCommandValidator(ICategoryRepository categoryRepository, IUserService userService, IUserRepository userRepository)
    {
		_categoryRepository = categoryRepository;
		_userService = userService;
		_userRepository = userRepository;

		RuleFor(ct => ct.CategoryId)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.GreaterThan(0).WithMessage("{PropertyName} must be more than {ComparisonValue}");

		RuleFor(ct => ct.Amount)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.NotEqual(0).WithMessage("{PropertyName} must be not equal to {ComparisonValue}")
			.GreaterThan(-100000).WithMessage("{PropertyName} must be more than {ComparisonValue}")
			.LessThan(100000).WithMessage("{PropertyName} must be less than {ComparisonValue}");

		RuleFor(ct => ct.DoneAt)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.LessThan(DateTime.Now).WithMessage("{PropertyName} must be less than Now");

		RuleFor(ct => ct.Description)
			.MaximumLength(100).WithMessage("{PropertyName} must be fewer than {MaxLength} characters");

		RuleFor(ct => ct)
			.MustAsync(CategoryTypeAndAmountMatches).WithMessage("Category type and amount doesn't match")
			.MustAsync(UserBalanceCheck).WithMessage("You don't have enough money");
	}

	private async Task<bool> UserBalanceCheck(CreateCategoryTransferCommand command, CancellationToken token)
	{
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		return user == null || user.Balance + command.Amount >= 0;
	}

	private async Task<bool> CategoryTypeAndAmountMatches(CreateCategoryTransferCommand command, CancellationToken token)
	{
		Category? category = await _categoryRepository.GetByIdAsync(command.CategoryId);
		if (category == null)
			return true;
		
		if (category.Type == "B" || (category.Type == "I" && command.Amount >= 0) || (category.Type == "E" && command.Amount <= 0))
			return true;
		return false;
	}
}
