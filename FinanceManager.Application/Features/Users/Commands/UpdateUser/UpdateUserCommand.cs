using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Unit>
{
    public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Gender { get; set; }
}
