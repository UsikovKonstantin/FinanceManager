using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ResetPassword;

public class ResetPasswordCommand : IRequest<Unit>
{
    public string Token { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string ConfirmPassword { get; set; } = string.Empty;
}
