namespace FinanceManager.Domain;

public class User : BaseEntity
{
    public int GroupId { get; set; }
	public string UserName { get; set; } = string.Empty;
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public double Balance { get; set; }
	public string Gender { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public bool EmailConfirmed { get; set; }
	public string Password { get; set; } = string.Empty;
	public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpirationDate { get; set; }

    public Group? Group { get; set; }
    public IEnumerable<Role>? Roles { get; set; }
	public IEnumerable<CategoryTransfer>? CategoryTransfers { get; set; }
	public IEnumerable<UserTransfer>? UserTransfersFrom { get; set; }
	public IEnumerable<UserTransfer>? UserTransfersTo { get; set; }
	public IEnumerable<Invitation>? InvitationsFrom { get; set; }
	public IEnumerable<Invitation>? InvitationsTo { get; set; }
}
