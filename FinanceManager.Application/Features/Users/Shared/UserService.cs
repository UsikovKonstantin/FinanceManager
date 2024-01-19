using FinanceManager.Application.Contracts.Identity;
using Microsoft.AspNetCore.Http;

namespace FinanceManager.Application.Features.Users.Shared;

public class UserService : IUserService
{
	private readonly IHttpContextAccessor _contextAccessor;

	public UserService(IHttpContextAccessor contextAccessor)
	{
		_contextAccessor = contextAccessor;
	}

	public int UserId { get => int.Parse(_contextAccessor.HttpContext?.User?.FindFirst("uid")?.Value ?? "0"); }
}
