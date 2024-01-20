namespace FinanceManager.Application.Features.Users.Queries.GetUsersInMyTeam;

public class UserInMyTeamResponse
{
	public int Id { get; set; }
	public string UserName { get; set; } = string.Empty;
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public double Balance { get; set; }
	public string Gender { get; set; } = string.Empty;
}
