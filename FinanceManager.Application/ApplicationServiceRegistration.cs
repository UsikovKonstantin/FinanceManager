using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Models.Identity;
using FinanceManager.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace FinanceManager.Application;

public static class ApplicationServiceRegistration
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

		services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

		services.AddTransient<ITokenService, TokenService>();

		services.AddHttpContextAccessor();
		services.AddTransient<IUserService, UserService>();

		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(opts =>
		{
			opts.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateIssuerSigningKey = true,
				ValidateLifetime = true,
				ValidIssuer = configuration["JwtSettings:Issuer"],
				ValidAudience = configuration["JwtSettings:Audience"],
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"] ?? "")),
				ClockSkew = TimeSpan.Zero
			};
		});

		return services;
	}
}
