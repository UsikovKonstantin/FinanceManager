namespace FinanceManager.Application.Features.Invitations.Queries;

public class InvitationResponse
{
	public int Id { get; set; }
	public int UserFromId { get; set; }
	public int UserToId { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime ModifiedAt { get; set; }
}
