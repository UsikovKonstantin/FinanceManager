using FinanceManager.Application.Contracts.Email;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Logging;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Models.Email;
using FinanceManager.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TestController : ControllerBase
	{
		private readonly IUserRepository _userRepository;
		private readonly IAppLogger<TestController> _logger;
		private readonly IEmailSender _emailSender;
		private readonly ITokenService _tokenService;

		public TestController(IUserRepository userRepository, IAppLogger<TestController> logger, IEmailSender emailSender, ITokenService tokenService)
		{
			_userRepository = userRepository;
			_logger = logger;
			_emailSender = emailSender;
			_tokenService = tokenService;
		}

		[HttpGet()]
		public async Task<IEnumerable<User>> Get()
		{
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
