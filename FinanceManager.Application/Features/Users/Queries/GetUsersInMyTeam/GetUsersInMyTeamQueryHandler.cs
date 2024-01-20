using AutoMapper;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.Users.Queries.GetUsersInMyTeam;

public class GetUsersInMyTeamQueryHandler : IRequestHandler<GetUsersInMyTeamQuery, IEnumerable<UserInMyTeamResponse>>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;
	private readonly IMapper _mapper;

	public GetUsersInMyTeamQueryHandler(IUserRepository userRepository, IUserService userService, IMapper mapper)
	{
		_userRepository = userRepository;
		_userService = userService;
		_mapper = mapper;
	}

	public async Task<IEnumerable<UserInMyTeamResponse>> Handle(GetUsersInMyTeamQuery request, CancellationToken cancellationToken)
	{
		// Найти пользователя, вызвавшего запрос
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти людей в одной команде с этим пользователем
		IEnumerable<User> users = await _userRepository.GetWhereAsync(u => u.TeamId == user.TeamId);

		// Преобразовать элемент к IEnumerable<UserResponse>
		IEnumerable<UserInMyTeamResponse> userResponses = _mapper.Map<IEnumerable<UserInMyTeamResponse>>(users);

		return userResponses;
	}
}
