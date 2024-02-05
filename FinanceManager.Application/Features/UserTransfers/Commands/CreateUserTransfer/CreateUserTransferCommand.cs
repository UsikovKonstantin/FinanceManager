using MediatR;

namespace FinanceManager.Application.Features.UserTransfers.Commands.CreateUserTransfer;

public class CreateUserTransferCommand : IRequest<int>
{
	public int UserToId { get; set; }
	public double Amount { get; set; }
	public DateTime? DoneAt { get; set; }
	public string? Description { get; set; }
}
