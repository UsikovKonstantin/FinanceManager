using MediatR;

namespace FinanceManager.Application.Features.Teams.Commands;

public class ChangeMyTeamNameCommand : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;
}
