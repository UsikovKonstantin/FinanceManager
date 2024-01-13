namespace FinanceManager.Domain;

public class Invitation : BaseEntity
{
    public int UserFromId { get; set; }
    public int UserToId { get; set; }

    public User? UserFrom { get; set; }
	public User? UserTo{ get; set; }
}
