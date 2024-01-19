using AutoMapper;
using FinanceManager.Application.Contracts.Email;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.Auth.Shared;
using FinanceManager.Application.Models.Email;
using FinanceManager.Application.Models.Identity;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using System.Web;

namespace FinanceManager.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly ITokenService _tokenService;
    private readonly IEmailSender _emailSender;
    private readonly IMapper _mapper;
    private readonly JwtSettings _jwtSettings;

    public RegisterCommandHandler(IUserRepository userRepository, 
        ITeamRepository teamRepository, ITokenService tokenService, 
        IEmailSender emailSender, IMapper mapper, 
        IOptions<JwtSettings> jwtSettings)
    {
        _userRepository = userRepository;
        _teamRepository = teamRepository;
        _tokenService = tokenService;
        _emailSender = emailSender;
        _mapper = mapper;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // Если пользователь не подтвердил регистрацию, то удаляем его и начинаем процесс регистрации заново
        User? foundUser = await _userRepository.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (foundUser != null && !foundUser.IsRegistered && foundUser.RegistrationTokenExpirationDate < DateTime.UtcNow)
        {
            Team? foundTeam = await _teamRepository.GetByIdAsync(foundUser.TeamId);
            await _userRepository.DeleteAsync(foundUser);
            if (foundTeam != null)
                await _teamRepository.DeleteAsync(foundTeam);
        }

        // Проверить данные для регистрации
        RegisterCommandValidator validator = new RegisterCommandValidator(_userRepository);
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid RegisterCommand", validationResult);

		// Добавить команду для пользователя
		Team team = new Team { Name = $"Команда {request.UserName}" };
		await _teamRepository.CreateAsync(team);

		// Преобразовать запрос к User, зашифровать пароль и указать команду, затем сохранить пользователя
		User user = _mapper.Map<User>(request);
        user.Password = SecretHasher.Hash(user.Password);
        user.TeamId = team.Id;
        await _userRepository.CreateAsync(user);

        // Добавить роль пользователю
        await _userRepository.AddUserToRole(user.Id, "TeamLeader");

        // Генерируем токен для подтверждения регистрации
        user.RegistrationToken = _tokenService.GenerateRandomToken();
        user.RegistrationTokenExpirationDate = DateTime.UtcNow.AddMinutes(_jwtSettings.RegistrationTokenDurationInMinutes);
        await _userRepository.UpdateAsync(user);

        // Отправляем сообщение с токеном на почту пользователя
        string url = "https://localhost:5001/api/auth/confirmRegistration?token=" + HttpUtility.UrlEncode(user.RegistrationToken);
        await _emailSender.SendEmailAsync(new EmailMessage
        {
            ToMail = request.Email,
            Subject = "Подтверждение регистрации",
            Message = "Для подтверждения регистрации перейдите по ссылке: " + url
        });

        return Unit.Value;
    }
}
