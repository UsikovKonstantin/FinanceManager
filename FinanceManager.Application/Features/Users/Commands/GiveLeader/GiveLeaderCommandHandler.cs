using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.GiveLeader;

public class GiveLeaderCommandHandler : IRequestHandler<GiveLeaderCommand, Unit>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;
	private readonly ITeamRepository _teamRepository;

	public GiveLeaderCommandHandler(IUserRepository userRepository, IUserService userService, ITeamRepository teamRepository)
	{
		_userRepository = userRepository;
		_userService = userService;
		_teamRepository = teamRepository;
	}

	public async Task<Unit> Handle(GiveLeaderCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		GiveLeaderCommandValidator validator = new GiveLeaderCommandValidator(_userRepository, _userService);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid GiveLeaderCommand", validationResult);

		// Найти пользователя, вызвавшего запрос
		User? userFrom = await _userRepository.GetByIdAsync(_userService.UserId);
		if (userFrom == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти пользователя, которому передают роль
		User? userTo = await _userRepository.GetByIdAsync(request.Id);
		if (userTo == null)
			throw new NotFoundException(nameof(User), request.Id);

		// Передать роль
		await _userRepository.RemoveUserFromRoleAsync(userTo.Id, "RoleMember");
		await _userRepository.AddUserToRoleAsync(userTo.Id, "RoleLeader");
		await _userRepository.RemoveUserFromRoleAsync(userFrom.Id, "RoleLeader");
		await _userRepository.AddUserToRoleAsync(userFrom.Id, "RoleMember");

		return Unit.Value;
	}
}
