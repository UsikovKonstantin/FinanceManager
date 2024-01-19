using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<Unit>
{
    public string CurrentPassword { get; set; } = string.Empty;
	public string NewPassword { get; set; } = string.Empty;
	public string ConfirmNewPassword { get; set; } = string.Empty;
}
