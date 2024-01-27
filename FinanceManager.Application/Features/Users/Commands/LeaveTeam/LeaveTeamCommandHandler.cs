using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.LeaveTeam;

public class LeaveTeamCommandHandler : IRequestHandler<LeaveTeamCommand, Unit>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;
	private readonly ITeamRepository _teamRepository;

	public LeaveTeamCommandHandler(IUserRepository userRepository, IUserService userService, ITeamRepository teamRepository)
	{
		_userRepository = userRepository;
		_userService = userService;
		_teamRepository = teamRepository;
	}

	public async Task<Unit> Handle(LeaveTeamCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		LeaveTeamCommandValidator validator = new LeaveTeamCommandValidator(_userRepository, _userService);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid LeaveTeamCommand", validationResult);

		// Найти пользователя, вызвавшего запрос
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Создать новую команду для пользователя
		Team team = new Team { Name = $"Команда {user.UserName}" };
		await _teamRepository.CreateAsync(team);

		// Изменить команду пользователя
		user.TeamId = team.Id;
		await _userRepository.UpdateAsync(user);

		return Unit.Value;
	}
}
