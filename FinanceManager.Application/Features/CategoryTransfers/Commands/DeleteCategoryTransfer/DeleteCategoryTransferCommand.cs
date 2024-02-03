using MediatR;

namespace FinanceManager.Application.Features.CategoryTransfers.Commands.DeleteCategoryTransfer;

public class DeleteCategoryTransferCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
