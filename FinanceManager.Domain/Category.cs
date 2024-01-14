namespace FinanceManager.Domain;

public class Category : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public char Type { get; set; }

    public IEnumerable<CategoryTransfer>? CategoryTransfers { get; set; }
}
