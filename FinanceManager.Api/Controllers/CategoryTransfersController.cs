using FinanceManager.Application.Features.CategoryTransfers.Commands.CreateCategoryTransfer;
using FinanceManager.Application.Features.CategoryTransfers.Commands.DeleteCategoryTransfer;
using FinanceManager.Application.Features.CategoryTransfers.Queries.GetCategoryTransfer;
using FinanceManager.Application.Features.CategoryTransfers.Queries.GetCategoryTransfers;
using FinanceManager.Application.Features.CategoryTransfers.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryTransfersController : Controller
{
	private readonly IMediator _mediator;

	public CategoryTransfersController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[Authorize]
	[HttpGet]
	public async Task<ActionResult> GetCategoryTransfers(string? from, string? type, int? categoryId,
		DateTime? startDate, DateTime? endDate, string? sortColumn, string? sortOrder, int pageSize = int.MaxValue, int page = 1)
	{
		IEnumerable<CategoryTransferResponse> categoryTransfers = await _mediator.Send(new GetCategoryTransfersQuery 
		{ 
			From = from,
			Type = type,
			CategoryId = categoryId,
			StartDate = startDate,
			EndDate = endDate,
			SortColumn = sortColumn,
			SortOrder = sortOrder,
			PageSize = pageSize,
			Page = page
		});
		return Ok(categoryTransfers);
	}

	[Authorize]
	[HttpGet("{id}")]
	public async Task<ActionResult> GetCategoryTransfer(int id)
	{
		CategoryTransferResponse categoryTransfer = await _mediator.Send(new GetCategoryTransferQuery { Id = id });
		return Ok(categoryTransfer);
	}

	[Authorize]
	[HttpPost]
	public async Task<ActionResult> CreateCategoryTransfer(CreateCategoryTransferCommand command)
	{
		int id = await _mediator.Send(command);
		return Ok(new { id = id });
	}

	[Authorize]
	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteCategoryTransfer(int id)
	{
		await _mediator.Send(new DeleteCategoryTransferCommand { Id = id });
		return NoContent();
	}
}
