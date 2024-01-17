using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.Users.Shared;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace FinanceManager.Application.Features.Users.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
	private readonly IUserRepository _userRepository;
	private readonly ITokenService _tokenService;

	public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService)
	{
		_userRepository = userRepository;
		_tokenService = tokenService;
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

		JwtSecurityToken jwtSecurityToken = await _tokenService.GenerateAccessTokenAsync(user);
		user.AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
		user.AccessTokenExpirationDate = jwtSecurityToken.ValidTo;

		string refreshToken = _tokenService.GenerateRefreshToken();
		user.RefreshToken = refreshToken;
		user.RefreshTokenExpirationDate = DateTime.UtcNow.AddDays(1);

		await _userRepository.UpdateAsync(user);

		LoginResponse response = new LoginResponse
		{
			UserId = user.Id,
			UserName = user.UserName,
			Email = user.Email,
			AccessToken = user.AccessToken,
			RefreshToken = user.RefreshToken
		};

		return response;
	}
}
