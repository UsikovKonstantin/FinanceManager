using FinanceManager.Application.Features.Categories.Queries.Shared;
using MediatR;

namespace FinanceManager.Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQuery : IRequest<IEnumerable<CategoryResponse>>
{
    public string? Type { get; set; }
}
