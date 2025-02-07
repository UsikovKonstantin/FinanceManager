﻿using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ChangeUserName;

public class ChangeUserNameCommandHandler : IRequestHandler<ChangeUserNameCommand, Unit>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

	public ChangeUserNameCommandHandler(IUserRepository userRepository, IUserService userService)
	{
		_userRepository = userRepository;
		_userService = userService;
	}

	public async Task<Unit> Handle(ChangeUserNameCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		ChangeUserNameCommandValidator validator = new ChangeUserNameCommandValidator(_userService, _userRepository);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid ChangeUserNameCommand", validationResult);

		// Найти пользователя, который вызвал запрос
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Обновить имя пользователя
		user.UserName = request.NewUserName;
		await _userRepository.UpdateAsync(user);

		return Unit.Value;
	}
}
