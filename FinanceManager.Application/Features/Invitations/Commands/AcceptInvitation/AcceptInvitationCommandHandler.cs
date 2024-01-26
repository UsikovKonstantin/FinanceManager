using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Invitations.Commands.AcceptInvitation;

public class AcceptInvitationCommandHandler : IRequestHandler<AcceptInvitationCommand, Unit>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;
	private readonly IInvitationRepository _invatationRepository;

	public AcceptInvitationCommandHandler(IUserRepository userRepository, IUserService userService, IInvitationRepository invatationRepository)
	{
		_userRepository = userRepository;
		_userService = userService;
		_invatationRepository = invatationRepository;
	}

	public async Task<Unit> Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		AcceptInvitationCommandValidator validator = new AcceptInvitationCommandValidator(_userService, _invatationRepository);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid AcceptInvitationCommand", validationResult);

		// Найти пользователя, кому адресовано приглашение
		User? userTo = await _userRepository.GetByIdAsync(_userService.UserId);
		if (userTo == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти приглашение
		Invitation? invitation = await _invatationRepository.GetByIdAsync(request.Id);
		if (invitation == null)
			throw new NotFoundException(nameof(Invitation), request.Id);

		// Найти пользователя, который отправлял приглашение
		User? userFrom = await _userRepository.GetByIdAsync(invitation.UserFromId);
		if (userFrom == null)
			throw new NotFoundException(nameof(User), invitation.UserFromId);

		// Может ли пользователь принять запрос? (не должен быть лидером)
		IEnumerable<User> users = await _userRepository.GetWhereAsync(u => u.TeamId == userTo.TeamId);
		bool isLeader = await _userRepository.IsUserInRoleAsync(userTo.Id, "TeamLeader");
		if (isLeader && users.Count() > 1)
			throw new BadRequestException("Leader can't leave his own team");

		// Найти приглашения, которые нужно будет удалить после принятия 
		// 1. Приглашения, отправленные мной людям команды, в которую я перехожу
		IEnumerable<Invitation> invitationsToDelete = await _invatationRepository.GetByUserFromIdAndUserToTeamId(userTo.Id, userFrom.TeamId);
		// 2. Приглашения, отправленные мне людьми команды, в которую я перехожу
		IEnumerable<Invitation> invitationsToDelete2 = await _invatationRepository.GetByUserToIdAndUserFromTeamId(userTo.Id, userFrom.TeamId);

		// Осуществляем переход
		if (isLeader)
		{
			await _userRepository.RemoveUserFromRoleAsync(userTo.Id, "TeamLeader");
			await _userRepository.AddUserToRoleAsync(userTo.Id, "TeamMember");
		}
		userTo.TeamId = userFrom.TeamId;
		await _userRepository.UpdateAsync(userTo);

		// Удаляем приглашения
		await _invatationRepository.DeleteRangeAsync(invitationsToDelete.ToArray());
		await _invatationRepository.DeleteRangeAsync(invitationsToDelete2.ToArray());

		return Unit.Value;
	}
}
