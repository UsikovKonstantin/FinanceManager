namespace FinanceManager.Domain;

public class Category : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public string Type { get; set; } = string.Empty;

    public IEnumerable<CategoryTransfer>? CategoryTransfers { get; set; }
}
