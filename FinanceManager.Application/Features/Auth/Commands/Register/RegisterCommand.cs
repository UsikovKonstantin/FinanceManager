using MediatR;

namespace FinanceManager.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<Unit>
{
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
