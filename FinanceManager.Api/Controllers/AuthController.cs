using FinanceManager.Application.Features.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
	private readonly IMediator _mediator;

	public AuthController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPost("register")]
	public async Task<ActionResult> Register(RegisterUserCommand command)
	{
		int id = await _mediator.Send(command);
		return Ok(new { id = id });
	}
}
