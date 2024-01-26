using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Invitations.Commands.DeclineInvitation;

public class DeclineInvitationCommandHandler : IRequestHandler<DeclineInvitationCommand, Unit>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;
	private readonly IInvitationRepository _invatationRepository;

	public DeclineInvitationCommandHandler(IUserRepository userRepository, IUserService userService, IInvitationRepository invatationRepository)
	{
		_userRepository = userRepository;
		_userService = userService;
		_invatationRepository = invatationRepository;
	}

	public async Task<Unit> Handle(DeclineInvitationCommand request, CancellationToken cancellationToken)
	{
		// Проверить данные
		DeclineInvitationCommandValidator validator = new DeclineInvitationCommandValidator(_userService, _invatationRepository);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid DeclineInvitationCommand", validationResult);

		// Найти пользователя, вызвавшего запрос
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти приглашение для удаления
		Invitation? invitation = await _invatationRepository.GetByIdAsync(request.Id);
		if (invitation == null)
			throw new NotFoundException(nameof(Invitation), request.Id);

		// Удалить приглашение
		await _invatationRepository.DeleteAsync(invitation);

		return Unit.Value;
	}
}
