using AutoMapper;
using FinanceManager.Application.Contracts.Email;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.Users.Shared;
using FinanceManager.Application.Models.Email;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace FinanceManager.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
{
	private readonly IUserRepository _userRepository;
	private readonly ITeamRepository _teamRepository;
	private readonly ITokenService _tokenService;
	private readonly IEmailSender _emailSender;
	private readonly IMapper _mapper;

	public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, 
		ITeamRepository teamRepository, ITokenService tokenService, IEmailSender emailSender)
	{
		_userRepository = userRepository;
		_mapper = mapper;
		_teamRepository = teamRepository;
		_tokenService = tokenService;
		_emailSender = emailSender;
	}

	public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{
		// Если пользователь повторно запросил сообщение для регистрации
		User? foundUser = await _userRepository.FirstOrDefaultAsync(u => u.Email == request.Email);
		if (foundUser != null && !foundUser.IsRegistered && foundUser.AccessTokenExpirationDate < DateTime.UtcNow)
		{
			Team? foundTeam = await _teamRepository.GetByIdAsync(foundUser.TeamId);
			if (foundTeam != null)
			{
				await _teamRepository.DeleteAsync(foundTeam);
			}
			await _userRepository.DeleteAsync(foundUser);
		}

		// Проверить входящие данные
		RegisterUserCommandValidator validator = new RegisterUserCommandValidator(_userRepository);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid User", validationResult);

		// Преобразовать элемент к User
		User user = _mapper.Map<User>(request);

		// Зашифровать пароль
		user.Password = SecretHasher.Hash(user.Password);

		// Добавить команду для пользователя
		Team team = new Team { Name = $"Команда {user.UserName}" };
		await _teamRepository.CreateAsync(team);
		user.TeamId = team.Id;

		// Добавить пользователя
		await _userRepository.CreateAsync(user);

		// Добавить роль пользователю
		await _userRepository.AddUserToRole(user.Id, "TeamLeader");

		// Генерируем токен
		JwtSecurityToken jwtSecurityToken = await _tokenService.GenerateAccessTokenAsync(user);
		user.AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
		user.AccessTokenExpirationDate = jwtSecurityToken.ValidTo;
		await _userRepository.UpdateAsync(user);

		// Отправляем сообщение
		string url = "https://localhost:5001/api/auth/confirmRegistration?token=" + user.AccessToken;
		await _emailSender.SendEmailAsync(new EmailMessage
		{
			ToMail = request.Email,
			Subject = "Подтверждение регистрации",
			Message = "Для подтверждения регистрации перейдите по ссылке: " + url
		});

		// Вернуть id
		return user.Id;
	}
}
