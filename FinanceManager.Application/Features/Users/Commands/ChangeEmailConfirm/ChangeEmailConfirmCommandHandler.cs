using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ChangeEmailConfirm;

public class ChangeEmailConfirmCommandHandler : IRequestHandler<ChangeEmailConfirmCommand, Unit>
{
	private readonly IUserRepository _userRepository;

	public ChangeEmailConfirmCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<Unit> Handle(ChangeEmailConfirmCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		ChangeEmailConfirmCommandValidator validator = new ChangeEmailConfirmCommandValidator(_userRepository);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid ChangeEmailConfirmCommand", validationResult);

		// Найти пользователя по токену
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.ChangeEmailToken == request.ChangeEmailToken);
		if (user == null)
			throw new NotFoundException(nameof(User), request.ChangeEmailToken);
		if (user.NewEmail == null)
			throw new BadRequestException("Can't find new email");

		// Заменить почту на новую
		user.Email = user.NewEmail;
		user.NewEmail = null;
		user.ChangeEmailToken = null;
		user.ChangeEmailTokenExpirationDate = null;
		await _userRepository.UpdateAsync(user);

		return Unit.Value;
	}
}
