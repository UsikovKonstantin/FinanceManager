using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ChangeEmailConfirm;

public class ChangeEmailConfirmCommand : IRequest<Unit>
{
	public string ChangeEmailToken { get; set; } = string.Empty;
}
