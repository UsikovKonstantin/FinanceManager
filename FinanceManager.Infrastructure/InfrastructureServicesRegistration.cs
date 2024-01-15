using FinanceManager.Application.Contracts.Email;
using FinanceManager.Application.Contracts.Logging;
using FinanceManager.Application.Models.Email;
using FinanceManager.Infrastructure.EmailService;
using FinanceManager.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infrastructure;

public static class InfrastructureServicesRegistration
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
		services.AddTransient<IEmailSender, EmailSender>();
		services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

		return services;
	}
}
