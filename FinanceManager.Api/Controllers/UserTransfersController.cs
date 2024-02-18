using FinanceManager.Application.Features.UserTransfers.Commands.CreateUserTransfer;
using FinanceManager.Application.Features.UserTransfers.Commands.DeleteUserTransfer;
using FinanceManager.Application.Features.UserTransfers.Queries.GetUserTransfer;
using FinanceManager.Application.Features.UserTransfers.Queries.GetUserTransfers;
using FinanceManager.Application.Features.UserTransfers.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserTransfersController : Controller
{
	private readonly IMediator _mediator;

	public UserTransfersController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[Authorize]
	[HttpGet]
	public async Task<ActionResult> GetUserTransfers(string? from, string? to,
		DateTime? startDate, DateTime? endDate, string? sortColumn, string? sortOrder, int pageSize = int.MaxValue, int page = 1)
	{
		IEnumerable<UserTransferResponse> userTransfers = await _mediator.Send(new GetUserTransfersQuery
		{
			From = from,
			To = to,
			StartDate = startDate,
			EndDate = endDate,
			SortColumn = sortColumn,
			SortOrder = sortOrder,
			PageSize = pageSize,
			Page = page
		});
		return Ok(userTransfers);
	}

	[Authorize]
	[HttpGet("{id}")]
	public async Task<ActionResult> GetUserTransfer(int id)
	{
		UserTransferResponse userTransfer = await _mediator.Send(new GetUserTransferQuery { Id = id });
		return Ok(userTransfer);
	}

	[Authorize]
	[HttpPost]
	public async Task<ActionResult> CreateUserTransfer(CreateUserTransferCommand command)
	{
		int id = await _mediator.Send(command);
		return Ok(new { id = id });
	}

	[Authorize]
	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteUserTransfer(int id)
	{
		await _mediator.Send(new DeleteUserTransferCommand { Id = id });
		return NoContent();
	}
}
