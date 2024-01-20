using AutoMapper;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Features.Categories.Queries.Shared;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

	public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
	{
        IEnumerable<Category> categories = await _categoryRepository.GetWhereAsync(
            c => (request.Income && (c.Type == "I" || c.Type == "B")) || (request.Expenses && (c.Type == "E" || c.Type == "B")));

		IEnumerable<CategoryResponse> categoryResponses = _mapper.Map<IEnumerable<CategoryResponse>>(categories);

        return categoryResponses;
	}
}
