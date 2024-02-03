using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.CategoryTransfers.Commands.DeleteCategoryTransfer;

public class DeleteCategoryTransferCommandHandler : IRequestHandler<DeleteCategoryTransferCommand, Unit>
{
	private readonly ICategoryTransferRepository _categoryTransferRepository;
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

    public DeleteCategoryTransferCommandHandler(ICategoryTransferRepository categoryTransferRepository,
		IUserRepository userRepository, IUserService userService)
    {
        _categoryTransferRepository = categoryTransferRepository;
		_userRepository = userRepository;
		_userService = userService;
    }

    public async Task<Unit> Handle(DeleteCategoryTransferCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		DeleteCategoryTransferCommandValidator validator = new DeleteCategoryTransferCommandValidator(_categoryTransferRepository, _userRepository, _userService);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid DeleteCategoryTransferCommand", validationResult);

		// Найти пользователя, вызвавшего запрос
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти перевод
		CategoryTransfer? categoryTransfer = await _categoryTransferRepository.GetByIdAsync(request.Id);
		if (categoryTransfer == null)
			throw new NotFoundException(nameof(CategoryTransfer), request.Id);

		// Удалить перевод
		user.Balance -= categoryTransfer.Amount;
		await _userRepository.UpdateAsync(user);
		await _categoryTransferRepository.DeleteAsync(categoryTransfer);

		return Unit.Value;
	}
}
