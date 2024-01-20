using FinanceManager.Application.Features.Categories.Queries.GetCategories;
using FinanceManager.Application.Features.Categories.Queries.GetCategory;
using FinanceManager.Application.Features.Categories.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoriesController : Controller
{
	private readonly IMediator _mediator;

	public CategoriesController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[Authorize]
	[HttpGet]
	public async Task<ActionResult> GetCategories(bool income, bool expenses)
	{
		IEnumerable<CategoryResponse> categories =  await _mediator.Send(new GetCategoriesQuery { Income = income, Expenses = expenses });
		return Ok(categories);
	}

	[Authorize]
	[HttpGet("{id}")]
	public async Task<ActionResult> GetCategory(int id)
	{
		CategoryResponse category = await _mediator.Send(new GetCategoryQuery { Id = id });
		return Ok(category);
	}
}
