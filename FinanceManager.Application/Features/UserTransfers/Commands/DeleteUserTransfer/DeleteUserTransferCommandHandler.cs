using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.UserTransfers.Commands.DeleteUserTransfer;

public class DeleteUserTransferCommandHandler : IRequestHandler<DeleteUserTransferCommand, Unit>
{
	private readonly IUserTransferRepository _userTransferRepository;
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

	public DeleteUserTransferCommandHandler(IUserTransferRepository userTransferRepository,
		IUserRepository userRepository, IUserService userService)
	{
		_userTransferRepository = userTransferRepository;
		_userRepository = userRepository;
		_userService = userService;
	}

	public async Task<Unit> Handle(DeleteUserTransferCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		DeleteUserTransferCommandValidator validator = new DeleteUserTransferCommandValidator(_userTransferRepository, _userRepository, _userService);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid DeleteUserTransferCommand", validationResult);

		// Найти пользователя, вызвавшего запрос
		User? userFrom = await _userRepository.GetByIdAsync(_userService.UserId);
		if (userFrom == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти перевод
		UserTransfer? userTransfer = await _userTransferRepository.GetByIdAsync(request.Id);
		if (userTransfer == null)
			throw new NotFoundException(nameof(CategoryTransfer), request.Id);

		// Найти пользователя, кому был адресован перевод
		User? userTo = await _userRepository.GetByIdAsync(userTransfer.UserToId);
		if (userTo == null)
			throw new NotFoundException(nameof(User), userTransfer.UserToId);

		// Удалить перевод
		userTo.Balance -= userTransfer.Amount;
		userFrom.Balance += userTransfer.Amount;
		await _userRepository.UpdateAsync(userTo);
		await _userRepository.UpdateAsync(userFrom);
		await _userTransferRepository.DeleteAsync(userTransfer);

		return Unit.Value;
	}
}
