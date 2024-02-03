using FinanceManager.Application.Features.CategoryTransfers.Queries.Shared;
using MediatR;

namespace FinanceManager.Application.Features.CategoryTransfers.Queries.GetCategoryTransfer;

public class GetCategoryTransferQuery : IRequest<CategoryTransferResponse>
{
    public int Id { get; set; }
}
