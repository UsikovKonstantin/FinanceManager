﻿using FinanceManager.Application.Contracts.Email;
using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.Auth.Shared;
using FinanceManager.Application.Models.Email;
using FinanceManager.Application.Models.Identity;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using System.Web;

namespace FinanceManager.Application.Features.Users.Commands.ChangeEmail;

public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, Unit>
{
    private readonly IUserRepository _userRepository;
	private readonly ITokenService _tokenService;
	private readonly IUserService _userService;
	private readonly JwtSettings _jwtSettings;
	private readonly IEmailSender _emailSender;

	public ChangeEmailCommandHandler(IUserRepository userRepository, ITokenService tokenService,
		IUserService userService, IOptions<JwtSettings> jwtSettings, IEmailSender emailSender)
    {
        _userRepository = userRepository;
		_tokenService = tokenService;
		_userService = userService;
		_jwtSettings = jwtSettings.Value;
		_emailSender = emailSender;
	}

	public async Task<Unit> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
	{
		ChangeEmailCommandValidator validator = new ChangeEmailCommandValidator(_userRepository);
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid ChangeEmailRequest", validationResult);

		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);
		if (!SecretHasher.Verify(request.Password, user.Password))
			throw new BadRequestException("Incorrect password");

		user.NewEmail = request.NewEmail;
		user.ChangeEmailToken = _tokenService.GenerateRandomToken();
		user.ChangeEmailTokenExpirationDate = DateTime.UtcNow.AddMinutes(_jwtSettings.ChangeEmailTokenDurationInMinutes);
		await _userRepository.UpdateAsync(user);

		string url = "https://localhost:5001/api/auth/changeEmailConfirm?token=" + HttpUtility.UrlEncode(user.ChangeEmailToken);
		await _emailSender.SendEmailAsync(new EmailMessage
		{
			ToMail = request.NewEmail,
			Subject = "Смена почты",
			Message = "Для смены почты перейдите по ссылке: " + url
		});

		return Unit.Value;
	}
}
