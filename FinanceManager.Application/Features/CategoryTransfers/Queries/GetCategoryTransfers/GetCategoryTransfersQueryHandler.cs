using AutoMapper;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Features.CategoryTransfers.Queries.Shared;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.CategoryTransfers.Queries.GetCategoryTransfers;

public class GetCategoryTransfersQueryHandler : IRequestHandler<GetCategoryTransfersQuery, IEnumerable<CategoryTransferResponse>>
{
	private readonly ICategoryTransferRepository _categoryTransferRepository;
	private readonly IMapper _mapper;

	public GetCategoryTransfersQueryHandler(ICategoryTransferRepository categoryTransferRepository, IMapper mapper)
	{
		_categoryTransferRepository = categoryTransferRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CategoryTransferResponse>> Handle(GetCategoryTransfersQuery request, CancellationToken cancellationToken)
	{
		IEnumerable<CategoryTransfer> categoryTransfers = await _categoryTransferRepository.GetCategoryTransfers(request.From, request.Type, 
			request.CategoryId, request.StartDate, request.EndDate, request.PageSize, request.Page, request.SortColumn, request.SortOrder);

		IEnumerable<CategoryTransferResponse> categoryTransferResponses = _mapper.Map<IEnumerable<CategoryTransferResponse>>(categoryTransfers);

		return categoryTransferResponses;
	}
}
