using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TestController : ControllerBase
	{
		private readonly IUserRepository _userRepository;

		public TestController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet()]
		public async Task<IEnumerable<User>> Get()
		{
			return await _userRepository.GetAllAsync();
		}
	}
}
