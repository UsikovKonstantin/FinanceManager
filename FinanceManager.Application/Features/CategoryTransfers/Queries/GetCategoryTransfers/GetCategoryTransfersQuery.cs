using FinanceManager.Application.Features.CategoryTransfers.Queries.Shared;
using MediatR;

namespace FinanceManager.Application.Features.CategoryTransfers.Queries.GetCategoryTransfers;

public class GetCategoryTransfersQuery : IRequest<IEnumerable<CategoryTransferResponse>>
{
    public string? From { get; set; }
	public string? Type { get; set; }
	public int? CategoryId { get; set; }
	public DateTime? StartDate { get; set; }
	public DateTime? EndDate { get; set; }
    public int PageSize { get; set; }
	public int Page { get; set; }
	public string? SortColumn { get; set; }
	public string? SortOrder { get; set; }
}
