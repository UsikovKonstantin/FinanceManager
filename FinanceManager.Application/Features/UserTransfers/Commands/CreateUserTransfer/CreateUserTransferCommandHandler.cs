using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.UserTransfers.Commands.CreateUserTransfer;

public class CreateUserTransferCommandHandler : IRequestHandler<CreateUserTransferCommand, int>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;
	private readonly IUserTransferRepository _userTransferRepository;

	public CreateUserTransferCommandHandler(IUserRepository userRepository, IUserService userService, IUserTransferRepository userTransferRepository)
	{
		_userRepository = userRepository;
		_userService = userService;
		_userTransferRepository = userTransferRepository;
	}

	public async Task<int> Handle(CreateUserTransferCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		CreateUserTransferCommandValidator validator = new CreateUserTransferCommandValidator(_userService, _userRepository);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid CreateUserTransferCommand", validationResult);

		// Найти пользователя, вызвавшего запрос
		User? userFrom = await _userRepository.GetByIdAsync(_userService.UserId);
		if (userFrom == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти пользователя, которому адресован перевод
		User? userTo = await _userRepository.GetByIdAsync(request.UserToId);
		if (userTo == null)
			throw new NotFoundException(nameof(Category), request.UserToId);

		// Добавить перевод
		UserTransfer userTransfer = new UserTransfer
		{
			UserFromId = userFrom.Id,
			UserToId = userTo.Id,
			Amount = request.Amount,
			DoneAt = request.DoneAt ?? DateTime.UtcNow,
			Description = request.Description
		};
		await _userTransferRepository.CreateAsync(userTransfer);

		userFrom.Balance -= userTransfer.Amount;
		await _userRepository.UpdateAsync(userFrom);

		userTo.Balance += userTransfer.Amount;
		await _userRepository.UpdateAsync(userTo);

		return userTransfer.Id;
	}
}
