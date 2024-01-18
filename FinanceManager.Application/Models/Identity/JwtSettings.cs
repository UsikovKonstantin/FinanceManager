namespace FinanceManager.Application.Models.Identity;

public class JwtSettings
{
	public string Key { get; set; } = string.Empty;
	public string Issuer { get; set; } = string.Empty;
	public string Audience { get; set; } = string.Empty;
	public double AccessTokenDurationInMinutes { get; set; }
	public double RegistrationTokenDurationInMinutes { get; set; }
	public double ResetPasswordTokenDurationInMinutes { get; set; }
	public double ChangeEmailTokenDurationInMinutes { get; set; }
	public double RefreshTokenDurationInDays { get; set; }
}