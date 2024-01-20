using FinanceManager.Application.Features.Categories.Queries.Shared;
using MediatR;

namespace FinanceManager.Application.Features.Categories.Queries.GetCategory;

public class GetCategoryQuery : IRequest<CategoryResponse>
{
    public int Id { get; set; }
}
