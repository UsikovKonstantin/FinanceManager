using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ConfirmRegistration;

public class ConfirmRegistrationCommand : IRequest<Unit>
{
    public string RegistrationToken { get; set; } = string.Empty;
}
