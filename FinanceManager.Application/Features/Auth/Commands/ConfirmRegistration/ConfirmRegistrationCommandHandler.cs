using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Auth.Commands.ConfirmRegistration;

public class ConfirmRegistrationCommandHandler : IRequestHandler<ConfirmRegistrationCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public ConfirmRegistrationCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(ConfirmRegistrationCommand request, CancellationToken cancellationToken)
    {
		// Проверить токен для подтверждения регистрации
		ConfirmRegistrationCommandValidator validator = new ConfirmRegistrationCommandValidator(_userRepository);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid ConfirmRegistrationCommand", validationResult);

        // Найти пользователя по токену
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.RegistrationToken == request.RegistrationToken);
        if (user == null)
            throw new NotFoundException(nameof(User), request.RegistrationToken);

        // Подтвердить регистрацию
        user.IsRegistered = true;
        user.RegistrationToken = null;
        user.RegistrationTokenExpirationDate = null;
        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}
