namespace FinanceManager.Domain;

public class UserTransfer : BaseEntity
{
	public int UserFromId { get; set; }
	public int UserToId { get; set; }
	public double Amount { get; set; }
	public DateTime DoneAt { get; set; }
	public string? Description { get; set; }

	public User? UserFrom { get; set; }
	public User? UserTo { get; set; }
}
