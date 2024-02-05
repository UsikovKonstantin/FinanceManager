using FinanceManager.Application.Features.UserTransfers.Queries.Shared;
using MediatR;

namespace FinanceManager.Application.Features.UserTransfers.Queries.GetUserTransfer;

public class GetUserTransferQuery : IRequest<UserTransferResponse>
{
	public int Id { get; set; }
}
