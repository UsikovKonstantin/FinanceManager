namespace FinanceManager.Application.Features.CategoryTransfers.Queries.Shared;

public class CategoryTransferResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public double Amount { get; set; }
    public DateTime DoneAt { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
