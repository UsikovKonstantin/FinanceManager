using FinanceManager.Application.Features.Users.Commands.ChangeEmail;
using FinanceManager.Application.Features.Users.Commands.ChangeEmailConfirm;
using FinanceManager.Application.Features.Users.Commands.ChangePassword;
using FinanceManager.Application.Features.Users.Commands.ChangeUserName;
using FinanceManager.Application.Features.Users.Commands.ConfirmRegistration;
using FinanceManager.Application.Features.Users.Commands.ForgotPassword;
using FinanceManager.Application.Features.Users.Commands.Login;
using FinanceManager.Application.Features.Users.Commands.Refresh;
using FinanceManager.Application.Features.Users.Commands.RegisterUser;
using FinanceManager.Application.Features.Users.Commands.ResetPassword;
using FinanceManager.Application.Features.Users.Commands.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

	[HttpPost("forgotPassword")]
	public async Task<ActionResult> ForgotPassword(ForgotPasswordCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}

	[HttpPost("resetPassword")]
	public async Task<ActionResult> ForgotPassword(ResetPasswordCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}

	[Authorize]
	[HttpPost("changeEmail")]
	public async Task<ActionResult> ChangeEmail(ChangeEmailCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}

	[HttpGet("changeEmailConfirm")]
	public async Task<ActionResult> ChangeEmailConfirm(string token)
	{
		ChangeEmailConfirmCommand command = new ChangeEmailConfirmCommand { ChangeEmailToken = token };
		await _mediator.Send(command);
		return NoContent();
	}

	[Authorize]
	[HttpPost("changePassword")]
	public async Task<ActionResult> ChangePassword(ChangePasswordCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}

	[Authorize]
	[HttpPost("changeUserName")]
	public async Task<ActionResult> ChangeUserName(ChangeUserNameCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}

	[Authorize]
	[HttpPost("updateUser")]
	public async Task<ActionResult> UpdateUser(UpdateUserCommand command)
	{
		await _mediator.Send(command);
		return NoContent();
	}
}
