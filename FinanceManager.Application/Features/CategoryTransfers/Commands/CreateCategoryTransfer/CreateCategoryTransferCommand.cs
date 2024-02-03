using MediatR;

namespace FinanceManager.Application.Features.CategoryTransfers.Commands.CreateCategoryTransfer;

public class CreateCategoryTransferCommand : IRequest<int>
{
    public int CategoryId { get; set; }
	public double Amount { get; set; }
    public DateTime? DoneAt { get; set; }
    public string? Description { get; set; }
}
