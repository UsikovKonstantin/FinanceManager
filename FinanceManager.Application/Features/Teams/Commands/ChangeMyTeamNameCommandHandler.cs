using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Teams.Commands;

public class ChangeMyTeamNameCommandHandler : IRequestHandler<ChangeMyTeamNameCommand, Unit>
{
	private readonly IUserRepository _userRepository;
	private readonly ITeamRepository _teamRepository;
	private readonly IUserService _userService;

	public ChangeMyTeamNameCommandHandler(IUserRepository userRepository, ITeamRepository teamRepository,
		IUserService userService)
	{
		_userRepository = userRepository;
		_teamRepository = teamRepository;
		_userService = userService;
	}

	public async Task<Unit> Handle(ChangeMyTeamNameCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		ChangeMyTeamNameCommandValidator validator = new ChangeMyTeamNameCommandValidator();
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid ChangeMyTeamNameCommand", validationResult);

		// Найти пользователя, вызвавшего запрос
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти его команду
		Team? team = await _teamRepository.GetByIdAsync(user.TeamId);
		if (team == null)
			throw new NotFoundException(nameof(Team), user.TeamId);

		// Изменить название команды
		team.Name = request.Name;
		await _teamRepository.UpdateAsync(team);

		return Unit.Value;
	}
}
