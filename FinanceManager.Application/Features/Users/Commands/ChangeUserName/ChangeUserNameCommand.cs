﻿using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ChangeUserName;

public class ChangeUserNameCommand : IRequest<Unit>
{
	public string Password { get; set; } = string.Empty;
	public string NewUserName { get; set; } = string.Empty;
}
