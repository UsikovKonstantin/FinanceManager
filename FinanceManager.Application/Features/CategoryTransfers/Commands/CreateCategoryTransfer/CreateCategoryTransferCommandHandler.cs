using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.CategoryTransfers.Commands.CreateCategoryTransfer;

public class CreateCategoryTransferCommandHandler : IRequestHandler<CreateCategoryTransferCommand, int>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;
	private readonly ICategoryTransferRepository _categoryTransferRepository;

    public CreateCategoryTransferCommandHandler(ICategoryRepository categoryRepository, IUserRepository userRepository,
		IUserService userService, ICategoryTransferRepository categoryTransferRepository)
    {
		_categoryRepository = categoryRepository;
		_userRepository = userRepository;
		_userService = userService;
		_categoryTransferRepository = categoryTransferRepository;
    }

    public async Task<int> Handle(CreateCategoryTransferCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		CreateCategoryTransferCommandValidator validator = new CreateCategoryTransferCommandValidator(_categoryRepository, _userService, _userRepository);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid CreateCategoryTransferCommand", validationResult);

		// Найти пользователя, вызвавшего запрос
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти категорию
		Category? category = await _categoryRepository.GetByIdAsync(request.CategoryId);
		if (category == null)
			throw new NotFoundException(nameof(Category), request.CategoryId);

		// Добавить перевод
		CategoryTransfer categoryTransfer = new CategoryTransfer
		{
			UserId = user.Id,
			CategoryId = category.Id,
			Amount = request.Amount,
			DoneAt = request.DoneAt ?? DateTime.UtcNow,
			Description = request.Description
		};
		await _categoryTransferRepository.CreateAsync(categoryTransfer);

		user.Balance += categoryTransfer.Amount;
		await _userRepository.UpdateAsync(user);

		return categoryTransfer.Id;
	}
}
