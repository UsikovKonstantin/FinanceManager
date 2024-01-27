using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.KickUser;

public class KickUserCommandHandler : IRequestHandler<KickUserCommand, Unit>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;
	private readonly ITeamRepository _teamRepository;

	public KickUserCommandHandler(IUserRepository userRepository, IUserService userService, ITeamRepository teamRepository)
	{
		_userRepository = userRepository;
		_userService = userService;
		_teamRepository = teamRepository;
	}

	public async Task<Unit> Handle(KickUserCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		KickUserCommandValidator validator = new KickUserCommandValidator(_userRepository, _userService);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid KickUserCommand", validationResult);

		// Найти пользователя, вызвавшего запрос
		User? userFrom = await _userRepository.GetByIdAsync(_userService.UserId);
		if (userFrom == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти пользователя, которого удаляют из группы
		User? userTo = await _userRepository.GetByIdAsync(request.Id);
		if (userTo == null)
			throw new NotFoundException(nameof(User), request.Id);

		// Создать новую команду для пользователя
		Team team = new Team { Name = $"Команда {userTo.UserName}" };
		await _teamRepository.CreateAsync(team);

		// Удалить пользователя из группы
		userTo.TeamId = team.Id;
		await _userRepository.UpdateAsync(userTo);

		return Unit.Value;
	}
}
