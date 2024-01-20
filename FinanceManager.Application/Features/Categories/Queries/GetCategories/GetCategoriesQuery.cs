using FinanceManager.Application.Features.Categories.Queries.Shared;
using MediatR;

namespace FinanceManager.Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQuery : IRequest<IEnumerable<CategoryResponse>>
{
    public bool Income { get; set; }
	public bool Expenses { get; set; }
}
