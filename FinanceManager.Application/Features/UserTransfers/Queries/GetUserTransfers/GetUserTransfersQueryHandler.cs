using AutoMapper;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Features.UserTransfers.Queries.Shared;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.UserTransfers.Queries.GetUserTransfers;

public class GetUserTransfersQueryHandler : IRequestHandler<GetUserTransfersQuery, IEnumerable<UserTransferResponse>>
{
	private readonly IUserTransferRepository _userTransferRepository;
	private readonly IMapper _mapper;

	public GetUserTransfersQueryHandler(IUserTransferRepository userTransferRepository, IMapper mapper)
	{
		_userTransferRepository = userTransferRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<UserTransferResponse>> Handle(GetUserTransfersQuery request, CancellationToken cancellationToken)
	{
		IEnumerable<UserTransfer> userTransfers = await _userTransferRepository.GetUserTransfers(request.From, request.To,
			request.StartDate, request.EndDate, request.PageSize, request.Page, request.SortColumn, request.SortOrder);

		IEnumerable<UserTransferResponse> userTransferResponses = _mapper.Map<IEnumerable<UserTransferResponse>>(userTransfers);

		return userTransferResponses;
	}
}
