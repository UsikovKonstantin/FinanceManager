using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ConfirmRegistration;

public class ConfirmRegistrationCommandHandler : IRequestHandler<ConfirmRegistrationCommand, Unit>
{
	private readonly IUserRepository _userRepository;

	public ConfirmRegistrationCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<Unit> Handle(ConfirmRegistrationCommand request, CancellationToken cancellationToken)
	{
		if (request.Token == "")
			throw new BadRequestException("Token is required");

		User? user = await _userRepository.FirstOrDefaultAsync(u => u.AccessToken == request.Token);
		if (user == null)
			throw new BadRequestException("User with this token wasn't found");
		if (user.AccessTokenExpirationDate < DateTime.UtcNow)
			throw new BadRequestException("Token has already expired. Try to register again");
		
		user.IsRegistered = true;
		user.EmailConfirmed = true;
		user.AccessToken = null;
		user.AccessTokenExpirationDate = null;
		await _userRepository.UpdateAsync(user);

		return Unit.Value;
	}
}
