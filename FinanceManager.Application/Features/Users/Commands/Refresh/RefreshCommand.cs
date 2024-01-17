﻿using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.Refresh;

public class RefreshCommand : IRequest<RefreshResponse>
{
    public string AccessToken { get; set; } = string.Empty;
	public string RefreshToken { get; set; } = string.Empty;
}
