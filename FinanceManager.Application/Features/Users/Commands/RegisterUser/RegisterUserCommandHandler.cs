using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
{


	public Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
