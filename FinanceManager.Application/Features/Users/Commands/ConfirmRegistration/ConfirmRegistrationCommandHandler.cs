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
	private readonly IAppLogger<ConfirmRegistrationCommandHandler> _logger;

	public ConfirmRegistrationCommandHandler(IUserRepository userRepository,
		IAppLogger<ConfirmRegistrationCommandHandler> logger)
	{
		_userRepository = userRepository;
		_logger = logger;
	}

	public async Task<Unit> Handle(ConfirmRegistrationCommand request, CancellationToken cancellationToken)
	{
		if (request.RegistrationToken == "")
			throw new BadRequestException("RegistrationToken is required");

		_logger.LogInformation(request.RegistrationToken);
		_logger.LogInformation(HttpUtility.UrlDecode(request.RegistrationToken));

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
