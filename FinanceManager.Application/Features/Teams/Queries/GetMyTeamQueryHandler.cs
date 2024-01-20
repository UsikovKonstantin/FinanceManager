using AutoMapper;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using MediatR;

namespace FinanceManager.Application.Features.Teams.Queries;

public class GetMyTeamQueryHandler : IRequestHandler<GetMyTeamQuery, TeamResponse>
{
	private readonly IUserRepository _userRepository;
	private readonly ITeamRepository _teamRepository;
	private readonly IUserService _userService;
	private readonly IMapper _mapper;

	public GetMyTeamQueryHandler(IUserRepository userRepository, ITeamRepository teamRepository,
		IUserService userService, IMapper mapper)
	{
		_userRepository = userRepository;
		_teamRepository = teamRepository;
		_userService = userService;
		_mapper = mapper;
	}

	public async Task<TeamResponse> Handle(GetMyTeamQuery request, CancellationToken cancellationToken)
	{
		// Найти пользователя, вызвавшего запрос
		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		// Найти его команду
		Team? team = await _teamRepository.GetByIdAsync(user.TeamId);
		if (team == null)
			throw new NotFoundException(nameof(Team), user.TeamId);

		// Преобразовать элемент к UserResponse
		TeamResponse teamResponse = _mapper.Map<TeamResponse>(team);

		return teamResponse;
	}
}
