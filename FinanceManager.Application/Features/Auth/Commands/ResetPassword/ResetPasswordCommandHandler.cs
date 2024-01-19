using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.Auth.Shared;
using FinanceManager.Application.Models.Identity;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;

namespace FinanceManager.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwtSettings;

    public ResetPasswordCommandHandler(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
    {
        _userRepository = userRepository;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
		// Проверить данные
		ResetPasswordCommandValidator validator = new ResetPasswordCommandValidator(_userRepository);
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid ResetPasswordCommand", validationResult);

		// Найти пользователя по токену
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.ResetPasswordToken == request.ResetPasswordToken);
        if (user == null)
            throw new NotFoundException(nameof(User), request.ResetPasswordToken);

        // Установить новый пароль
        user.Password = SecretHasher.Hash(request.Password);
        user.ResetPasswordToken = null;
        user.ResetPasswordTokenExpirationDate = null;
        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}
