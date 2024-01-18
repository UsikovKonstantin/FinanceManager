using FinanceManager.Application.Contracts.Logging;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using MediatR;
using System.Web;

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
		if (request.RegistrationToken == "")
			throw new BadRequestException("RegistrationToken is required");

		User? user = await _userRepository.FirstOrDefaultAsync(u => u.RegistrationToken == request.RegistrationToken);
		if (user == null)
			throw new BadRequestException("User with this RegistrationToken wasn't found");
		if (user.RegistrationTokenExpirationDate < DateTime.UtcNow)
			throw new BadRequestException("RegistrationToken has already expired. Try to register again");
		
		user.IsRegistered = true;
		user.RegistrationToken = null;
		user.RegistrationTokenExpirationDate = null;
		await _userRepository.UpdateAsync(user);

		return Unit.Value;
	}
}
