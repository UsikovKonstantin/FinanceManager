namespace FinanceManager.Application.Features.Teams.Queries;

public class TeamResponse
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; }
	public DateTime ModifiedAt { get; set; }
}
