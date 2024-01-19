using FinanceManager.Application.Contracts.Email;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Models.Email;
using FinanceManager.Application.Models.Identity;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;

namespace FinanceManager.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwtSettings;
    private readonly ITokenService _tokenService;
    private readonly IEmailSender _emailSender;

    public ForgotPasswordCommandHandler(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings,
        ITokenService tokenService, IEmailSender emailSender)
    {
        _userRepository = userRepository;
        _jwtSettings = jwtSettings.Value;
        _tokenService = tokenService;
        _emailSender = emailSender;
    }

    public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
		// Проверить данные
		ForgotPasswordCommandValidator validator = new ForgotPasswordCommandValidator();
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid ForgotPasswordCommand", validationResult);

		// Найти пользователя по email
		User? user = await _userRepository.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null)
            throw new NotFoundException(nameof(User), request.Email);

		// Генерируем токен для сброса пароля
		user.ResetPasswordToken = _tokenService.GenerateRandomToken();
        user.ResetPasswordTokenExpirationDate = DateTime.UtcNow.AddMinutes(_jwtSettings.ResetPasswordTokenDurationInMinutes);
        await _userRepository.UpdateAsync(user);

        // Отправляем сообщение с токеном
        await _emailSender.SendEmailAsync(new EmailMessage
        {
            ToMail = request.Email,
            Subject = "Сброс пароля",
            Message = "Ваш токен для сброса пароля: " + user.ResetPasswordToken
        });

        return Unit.Value;
    }
}
