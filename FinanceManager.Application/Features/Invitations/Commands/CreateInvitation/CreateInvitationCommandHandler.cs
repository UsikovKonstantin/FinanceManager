using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Invitations.Commands.CreateInvitation;

public class CreateInvitationCommandHandler : IRequestHandler<CreateInvitationCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly IInvitationRepository _invatationRepository;

    public CreateInvitationCommandHandler(IUserRepository userRepository, IUserService userService, IInvitationRepository invatationRepository)
    {
        _userRepository = userRepository;
        _userService = userService;
        _invatationRepository = invatationRepository;
    }

    public async Task<int> Handle(CreateInvitationCommand request, CancellationToken cancellationToken)
    {
        // Проверить данные
        CreateInvitationCommandValidator validator = new CreateInvitationCommandValidator(_userRepository, _userService, _invatationRepository);
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid CreateInvitationCommand", validationResult);

        // Найти пользователя, вызвавшего запрос
        User? userFrom = await _userRepository.GetByIdAsync(_userService.UserId);
        if (userFrom == null)
            throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти пользователя, которому адресовано приглашение
		User? userTo = await _userRepository.GetByIdAsync(request.UserToId);
		if (userTo == null)
			throw new NotFoundException(nameof(User), request.UserToId);

        // Добавить приглашение
        Invitation invitation = new Invitation
        {
            UserFromId = userFrom.Id,
            UserToId = userTo.Id
		};
        await _invatationRepository.CreateAsync(invitation);

        return invitation.Id;
	}
}
