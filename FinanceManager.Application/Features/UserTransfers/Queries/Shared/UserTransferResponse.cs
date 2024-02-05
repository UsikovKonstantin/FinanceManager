namespace FinanceManager.Application.Features.UserTransfers.Queries.Shared;

public class UserTransferResponse
{
	public int Id { get; set; }
	public int UserFromId { get; set; }
	public int UserToId { get; set; }
	public double Amount { get; set; }
	public DateTime DoneAt { get; set; }
	public string? Description { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime ModifiedAt { get; set; }
}
