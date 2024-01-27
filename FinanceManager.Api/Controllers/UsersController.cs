using FinanceManager.Application.Features.Users.Commands.ChangeEmail;
using FinanceManager.Application.Features.Users.Commands.ChangeEmailConfirm;
using FinanceManager.Application.Features.Users.Commands.ChangePassword;
using FinanceManager.Application.Features.Users.Commands.ChangeUserName;
using FinanceManager.Application.Features.Users.Commands.GiveLeader;
using FinanceManager.Application.Features.Users.Commands.KickUser;
using FinanceManager.Application.Features.Users.Commands.LeaveTeam;
using FinanceManager.Application.Features.Users.Commands.UpdateUser;
using FinanceManager.Application.Features.Users.Queries.GetMe;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
	private readonly IMediator _mediator;

	public UsersController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[Authorize]
	[HttpGet("me")]
	public async Task<ActionResult> GetCurrentUser()
	{
		CurrentUserResponse user = await _mediator.Send(new GetCurrentUserQuery());
		return Ok(user);
	}

	[Authorize]
	[HttpPost("me/changeEmail")]
	public async Task<ActionResult> ChangeEmail(ChangeEmailCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}

	[HttpGet("me/changeEmailConfirm")]
	public async Task<ActionResult> ChangeEmailConfirm(string token)
	{
		ChangeEmailConfirmCommand command = new ChangeEmailConfirmCommand { ChangeEmailToken = token };
		await _mediator.Send(command);
		return NoContent();
	}

	[Authorize]
	[HttpPost("me/changePassword")]
	public async Task<ActionResult> ChangePassword(ChangePasswordCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}

	[Authorize]
	[HttpPost("me/changeUserName")]
	public async Task<ActionResult> ChangeUserName(ChangeUserNameCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}

	[Authorize]
	[HttpPatch("me")]
	public async Task<ActionResult> UpdateUser(UpdateUserCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}

	[Authorize]
	[HttpPost("me/leave")]
	public async Task<ActionResult> LeaveTeam()
	{
		await _mediator.Send(new LeaveTeamCommand());
		return NoContent();
	}

	[Authorize]
	[HttpPost("{id}/giveLeader")]
	public async Task<ActionResult> GiveLeader(int id)
	{
		await _mediator.Send(new GiveLeaderCommand { Id = id });
		return NoContent();
	}

	[Authorize]
	[HttpPost("{id}/kick")]
	public async Task<ActionResult> Kick(int id)
	{
		await _mediator.Send(new KickUserCommand { Id = id });
		return NoContent();
	}
}
