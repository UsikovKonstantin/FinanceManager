namespace FinanceManager.Application.Features.Categories.Queries.Shared;

public class CategoryResponse
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Type { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; }
	public DateTime ModifiedAt { get; set; }
}
