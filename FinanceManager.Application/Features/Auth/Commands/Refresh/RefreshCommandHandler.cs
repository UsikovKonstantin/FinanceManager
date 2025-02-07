﻿using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Models.Identity;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinanceManager.Application.Features.Auth.Commands.Refresh;

public class RefreshCommandHandler : IRequestHandler<RefreshCommand, RefreshResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly JwtSettings _jwtSettings;

    public RefreshCommandHandler(IUserRepository userRepository, ITokenService tokenService,
        IOptions<JwtSettings> jwtSettings)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<RefreshResponse> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
		// Проверить данные
		RefreshCommandValidator validator = new RefreshCommandValidator();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid RefreshCommand", validationResult);

        // Получаем имя пользователя из access токена
        ClaimsPrincipal? principal = _tokenService.GetPrincipalFromAccessToken(request.AccessToken);
        string? userName = principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userName == null)
            throw new BadRequestException("Not valid access token");

        // Проверяем, что пользователь существует и токены валидны
        User? user = await _userRepository.FirstOrDefaultAsync(u => u.UserName == userName);
        if (user == null)
            throw new NotFoundException(nameof(User), userName);
        if (user.RefreshToken != request.RefreshToken)
            throw new BadRequestException("Incorrect refresh token");
        if (user.RefreshTokenExpirationDate < DateTime.UtcNow)
            throw new BadRequestException("Refresh token has already expired");

		// Генерируем новые access и refresh токены
		JwtSecurityToken accessToken = await _tokenService.GenerateAccessTokenAsync(user);

        user.RefreshToken = _tokenService.GenerateRandomToken();
        user.RefreshTokenExpirationDate = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenDurationInDays);
        await _userRepository.UpdateAsync(user);

		// Возвращаем ответ
		RefreshResponse response = new RefreshResponse
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
            RefreshToken = user.RefreshToken
        };
        return response;
    }
}
