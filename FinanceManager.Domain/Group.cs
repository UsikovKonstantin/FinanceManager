namespace FinanceManager.Domain;

public class Group : BaseEntity
{
	public string Name { get; set; } = string.Empty;

    public IEnumerable<User>? Users { get; set; }
}
