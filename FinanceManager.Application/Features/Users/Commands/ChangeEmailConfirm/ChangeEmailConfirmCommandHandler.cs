using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ChangeEmailConfirm;

public class ChangeEmailConfirmCommandHandler : IRequestHandler<ChangeEmailConfirmCommand, Unit>
{
	private readonly IUserRepository _userRepository;

	public ChangeEmailConfirmCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<Unit> Handle(ChangeEmailConfirmCommand request, CancellationToken cancellationToken)
	{
		if (request.ChangeEmailToken == "")
			throw new BadRequestException("ChangeEmailToken is required");

		User? user = await _userRepository.FirstOrDefaultAsync(u => u.ChangeEmailToken == request.ChangeEmailToken);
		if (user == null)
			throw new BadRequestException("User with this ChangeEmailToken wasn't found");
		if (user.NewEmail == null)
			throw new BadRequestException("Can't find new email");
		if (user.RegistrationTokenExpirationDate < DateTime.UtcNow)
			throw new BadRequestException("ChangeEmailToken has already expired");

		User? userByEmail = await _userRepository.FirstOrDefaultAsync(u => u.Email == user.NewEmail);
		if (userByEmail != null)
			throw new BadRequestException("User with this email already exists");

		user.Email = user.NewEmail;
		user.NewEmail = null;
		user.ChangeEmailToken = null;
		user.ChangeEmailTokenExpirationDate = null;
		await _userRepository.UpdateAsync(user);

		return Unit.Value;
	}
}
