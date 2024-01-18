namespace FinanceManager.Domain;

public class User : BaseEntity
{
    public int TeamId { get; set; }
	public string UserName { get; set; } = string.Empty;
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public double Balance { get; set; }
	public string Gender { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public bool IsRegistered { get; set; }

	public string? RegistrationToken { get; set; }
	public DateTime? RegistrationTokenExpirationDate { get; set; }

	public string? ResetPasswordToken { get; set; }
	public DateTime? ResetPasswordTokenExpirationDate { get; set; }

	public string? NewEmail { get; set; }
	public string? ChangeEmailToken { get; set; }
	public DateTime? ChangeEmailTokenExpirationDate { get; set; }

	public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpirationDate { get; set; }

    public Team? Team { get; set; }
    public IEnumerable<UserRole>? UserRoles { get; set; }
	public IEnumerable<CategoryTransfer>? CategoryTransfers { get; set; }
	public IEnumerable<UserTransfer>? UserTransfersFrom { get; set; }
	public IEnumerable<UserTransfer>? UserTransfersTo { get; set; }
	public IEnumerable<Invitation>? InvitationsFrom { get; set; }
	public IEnumerable<Invitation>? InvitationsTo { get; set; }
}
