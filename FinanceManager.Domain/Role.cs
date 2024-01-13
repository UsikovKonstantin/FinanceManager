namespace FinanceManager.Domain;

public class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public IEnumerable<User>? Users { get; set; }
}
