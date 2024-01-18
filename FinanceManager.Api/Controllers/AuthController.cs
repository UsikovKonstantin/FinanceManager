using FinanceManager.Application.Features.Users.Commands.ConfirmRegistration;
using FinanceManager.Application.Features.Users.Commands.Login;
using FinanceManager.Application.Features.Users.Commands.Refresh;
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

	[HttpGet("confirmRegistration")]
	public async Task<ActionResult> ConfirmRegistration(string token)
	{
		ConfirmRegistrationCommand command = new ConfirmRegistrationCommand { RegistrationToken = token };
		await _mediator.Send(command);
		return NoContent();
	}

	[HttpPost("login")]
	public async Task<ActionResult<LoginResponse>> Login(LoginCommand command)
	{
		LoginResponse response = await _mediator.Send(command);
		return Ok(response);
	}

	[HttpPost("refresh")]
	public async Task<ActionResult<RefreshResponse>> Refresh(RefreshCommand command)
	{
		RefreshResponse response = await _mediator.Send(command);
		return Ok(response);
	}
}
