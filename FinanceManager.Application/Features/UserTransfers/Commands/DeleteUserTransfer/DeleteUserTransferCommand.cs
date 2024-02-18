using MediatR;

namespace FinanceManager.Application.Features.UserTransfers.Commands.DeleteUserTransfer;

public class DeleteUserTransferCommand : IRequest<Unit>
{
	public int Id { get; set; }
}
