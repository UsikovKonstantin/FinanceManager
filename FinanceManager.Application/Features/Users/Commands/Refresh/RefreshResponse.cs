﻿namespace FinanceManager.Application.Features.Users.Commands.Refresh;

public class RefreshResponse
{
	public string AccessToken { get; set; } = string.Empty;
	public string RefreshToken { get; set; } = string.Empty;
}
