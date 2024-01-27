using FinanceManager.Application.Features.Invitations.Commands.AcceptInvitation;
using FinanceManager.Application.Features.Invitations.Commands.CreateInvitation;
using FinanceManager.Application.Features.Invitations.Commands.DeclineInvitation;
using FinanceManager.Application.Features.Invitations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvitationsController : Controller
{
	private readonly IMediator _mediator;

	public InvitationsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[Authorize]
	[HttpGet]
	public async Task<ActionResult> GetInvitations(string? type)
	{
		IEnumerable<InvitationResponse> invitations = await _mediator.Send(new GetInvitationsQuery { Type = type });
		return Ok(invitations);
	}

	[Authorize]
	[HttpPost]
	public async Task<ActionResult> CreateInvatation(CreateInvitationCommand command)
	{
		int id = await _mediator.Send(command);
		return Ok(new { id = id });
	}

	[Authorize]
	[HttpPost("{id}/decline")]
	public async Task<ActionResult> DeclineInvatation(int id)
	{
		await _mediator.Send(new DeclineInvitationCommand { Id = id });
		return NoContent();
	}

	[Authorize]
	[HttpPost("{id}/accept")]
	public async Task<ActionResult> AcceptInvatation(int id)
	{
		await _mediator.Send(new AcceptInvitationCommand { Id = id });
		return NoContent();
	}
}
