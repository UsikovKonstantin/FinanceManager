using AutoMapper;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.Categories.Queries.Shared;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryResponse>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

	public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
		_mapper = mapper;
    }

    public async Task<CategoryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
	{
		Category? category = await _categoryRepository.GetByIdAsync(request.Id);

		if (category == null)
			throw new NotFoundException(nameof(Category), request.Id);

		CategoryResponse categoryResponse = _mapper.Map<CategoryResponse>(category);

		return categoryResponse;
	}
}
