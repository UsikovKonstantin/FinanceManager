using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ChangeEmail;

public class ChangeEmailCommand : IRequest<Unit>
{
    public string Password { get; set; } = string.Empty;
    public string NewEmail { get; set; } = string.Empty;
}
