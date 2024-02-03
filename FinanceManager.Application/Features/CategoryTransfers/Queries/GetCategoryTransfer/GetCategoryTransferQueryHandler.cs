using AutoMapper;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.CategoryTransfers.Queries.Shared;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.CategoryTransfers.Queries.GetCategoryTransfer;

public class GetCategoryTransferQueryHandler : IRequestHandler<GetCategoryTransferQuery, CategoryTransferResponse>
{
	private readonly ICategoryTransferRepository _categoryTransferRepository;
	private readonly IUserService _userService;
	private readonly IMapper _mapper;

	public GetCategoryTransferQueryHandler(ICategoryTransferRepository categoryTransferRepository, IUserService userService, IMapper mapper)
	{
		_categoryTransferRepository = categoryTransferRepository;
		_userService = userService;
		_mapper = mapper;
	}

	public async Task<CategoryTransferResponse> Handle(GetCategoryTransferQuery request, CancellationToken cancellationToken)
	{
		CategoryTransfer? categoryTransfer = await _categoryTransferRepository.GetByIdAsync(request.Id);
		if (categoryTransfer == null)
			throw new NotFoundException(nameof(CategoryTransfer), request.Id);

		if (categoryTransfer.UserId != _userService.UserId)
			throw new BadRequestException("This is not your transfer");

		CategoryTransferResponse categoryTransferResponse = _mapper.Map<CategoryTransferResponse>(categoryTransfer);

		return categoryTransferResponse;
	}
}
