using AutoMapper;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.UserTransfers.Queries.Shared;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.UserTransfers.Queries.GetUserTransfer;

public class GetUserTransferQueryHandler : IRequestHandler<GetUserTransferQuery, UserTransferResponse>
{
	private readonly IUserTransferRepository _userTransferRepository;
	private readonly IUserService _userService;
	private readonly IMapper _mapper;

	public GetUserTransferQueryHandler(IUserTransferRepository userTransferRepository, IUserService userService, IMapper mapper)
	{
		_userTransferRepository = userTransferRepository;
		_userService = userService;
		_mapper = mapper;
	}

	public async Task<UserTransferResponse> Handle(GetUserTransferQuery request, CancellationToken cancellationToken)
	{
		UserTransfer? userTransfer = await _userTransferRepository.GetByIdAsync(request.Id);
		if (userTransfer == null)
			throw new NotFoundException(nameof(UserTransfer), request.Id);

		if (userTransfer.UserFromId != _userService.UserId && userTransfer.UserToId != _userService.UserId)
			throw new BadRequestException("This is not your transfer");

		UserTransferResponse userTransferResponse = _mapper.Map<UserTransferResponse>(userTransfer);

		return userTransferResponse;
	}
}
