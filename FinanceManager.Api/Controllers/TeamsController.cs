using FinanceManager.Application.Features.Teams.Commands;
using FinanceManager.Application.Features.Teams.Queries;
using FinanceManager.Application.Features.Users.Queries.GetUsersInMyTeam;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : Controller
{
	private readonly IMediator _mediator;

	public TeamsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[Authorize]
	[HttpGet("my/users")]
	public async Task<ActionResult> GetUsersInMyTeam()
	{
		IEnumerable<UserInMyTeamResponse> users = await _mediator.Send(new GetUsersInMyTeamQuery());
		return Ok(users);
	}

	[Authorize]
	[HttpGet("my")]
	public async Task<ActionResult> GetMyTeam()
	{
		TeamResponse team = await _mediator.Send(new GetMyTeamQuery());
		return Ok(team);
	}

	[HttpPut("my")]
	public async Task<ActionResult> ChangeMyTeamName(ChangeMyTeamNameCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}
}
