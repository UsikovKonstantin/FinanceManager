using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<int>
{
    public string UserName { get; set; } = string.Empty;
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
    public char Gender { get; set; }
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
}
