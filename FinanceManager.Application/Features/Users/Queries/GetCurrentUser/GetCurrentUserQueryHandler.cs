﻿using AutoMapper;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.Users.Queries.GetCurrentUser;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserResponse>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;
	private readonly IMapper _mapper;

	public GetCurrentUserQueryHandler(IUserRepository userRepository, IUserService userService, IMapper mapper)
    {
        _userRepository = userRepository;
		_userService = userService;
		_mapper = mapper;
    }

    public async Task<UserResponse> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
	{
		// Найти пользователя, вызвавшего запрос
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Преобразовать элемент к UserResponse
		UserResponse userResponse = _mapper.Map<UserResponse>(user);

		return userResponse;
	}
}
