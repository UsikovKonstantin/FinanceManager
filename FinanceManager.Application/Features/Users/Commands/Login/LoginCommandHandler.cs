using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.Users.Shared;
using FinanceManager.Application.Models.Identity;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace FinanceManager.Application.Features.Users.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
	private readonly IUserRepository _userRepository;
	private readonly ITokenService _tokenService;
	private readonly JwtSettings _jwtSettings;

	public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService, 
		IOptions<JwtSettings> jwtSettings)
	{
		_userRepository = userRepository;
		_tokenService = tokenService;
		_jwtSettings = jwtSettings.Value;
	}

	public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
	{
		LoginCommandValidator validator = new LoginCommandValidator();
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid LoginRequest", validationResult);

		User? user = await _userRepository.FirstOrDefaultAsync(u => u.Email == request.Email);
		if (user == null)
			throw new NotFoundException(nameof(User), request.Email);

		if (!SecretHasher.Verify(request.Password, user.Password))
			throw new BadRequestException("Incorrect password");

		JwtSecurityToken accessToken = await _tokenService.GenerateAccessTokenAsync(user);

		user.RefreshToken = _tokenService.GenerateRandomToken();
		user.RefreshTokenExpirationDate = DateTime.UtcNow.AddMinutes(_jwtSettings.RefreshTokenDurationInDays);

		await _userRepository.UpdateAsync(user);

		LoginResponse response = new LoginResponse
		{
			UserId = user.Id,
			UserName = user.UserName,
			Email = user.Email,
			AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
			RefreshToken = user.RefreshToken
		};

		return response;
	}
}
