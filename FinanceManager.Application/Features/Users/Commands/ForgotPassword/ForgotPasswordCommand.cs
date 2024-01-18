using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ForgotPassword;

public class ForgotPasswordCommand : IRequest<Unit>
{
    public string Email { get; set; } = string.Empty;
}
