using FinanceManager.Application.Features.Invitations.Commands.CreateInvitation;
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
	public async Task<ActionResult> GetInvitations(bool fromMe, bool toMe)
	{
		IEnumerable<InvitationResponse> invitations = await _mediator.Send(new GetInvitationsQuery { FromMe = fromMe, ToMe = toMe });
		return Ok(invitations);
	}

	[Authorize]
	[HttpPost]
	public async Task<ActionResult> CreateInvatation(CreateInvitationCommand command)
	{
		int id = await _mediator.Send(command);
		return Ok(new { id = id });
	}
}
