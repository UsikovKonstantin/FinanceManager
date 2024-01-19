using FinanceManager.Application.Contracts.Email;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Logging;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Models.Email;
using FinanceManager.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class TestController : ControllerBase
	{
		private readonly IUserRepository _userRepository;
		private readonly IAppLogger<TestController> _logger;
		private readonly IEmailSender _emailSender;
		private readonly ITokenService _tokenService;
		private readonly IUserService _userService;

		public TestController(IUserRepository userRepository, IAppLogger<TestController> logger, IEmailSender emailSender, ITokenService tokenService,
			IUserService userService)
		{
			_userRepository = userRepository;
			_logger = logger;
			_emailSender = emailSender;
			_tokenService = tokenService;
			_userService = userService;
		}

		[HttpGet()]
		public async Task<IEnumerable<User>> Get()
		{
			_logger.LogInformation(_userService.UserId.ToString());

			string token = _tokenService.GenerateRandomToken();

			_logger.LogInformation("Logging something...");

			await _emailSender.SendEmailAsync(new EmailMessage
			{
				ToMail = "usikov-kostya@mail.ru",
				Subject = "Тема",
				Message = "Сообщение"
			});

			return await _userRepository.GetAllAsync();
		}
	}
}
