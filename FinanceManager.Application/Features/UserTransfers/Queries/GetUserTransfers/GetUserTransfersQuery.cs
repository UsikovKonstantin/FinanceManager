using FinanceManager.Application.Features.UserTransfers.Queries.Shared;
using MediatR;

namespace FinanceManager.Application.Features.UserTransfers.Queries.GetUserTransfers;

public class GetUserTransfersQuery : IRequest<IEnumerable<UserTransferResponse>>
{
	public string? From { get; set; }
	public string? To { get; set; }
	public DateTime? StartDate { get; set; }
	public DateTime? EndDate { get; set; }
	public int PageSize { get; set; }
	public int Page { get; set; }
	public string? SortColumn { get; set; }
	public string? SortOrder { get; set; }
}
