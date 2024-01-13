namespace FinanceManager.Domain;

public class CategoryTransfer : BaseEntity
{
	public int UserId { get; set; }
	public int CategoryId { get; set; }
	public double Amount { get; set; }
	public DateTime DoneAt { get; set; }
	public string? Description { get; set; }

	public User? User { get; set; }
	public Category? Category { get; set; }
}
