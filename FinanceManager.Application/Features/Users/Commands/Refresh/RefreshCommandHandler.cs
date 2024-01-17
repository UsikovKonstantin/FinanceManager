using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace FinanceManager.Application.Features.Users.Commands.Refresh;

public class RefreshCommandHandler : IRequestHandler<RefreshCommand, RefreshResponse>
{
	private readonly IUserRepository _userRepository;
	private readonly ITokenService _tokenService;

	public RefreshCommandHandler(IUserRepository userRepository, ITokenService tokenService)
	{
		_userRepository = userRepository;
		_tokenService = tokenService;
	}

	public async Task<RefreshResponse> Handle(RefreshCommand request, CancellationToken cancellationToken)
	{
		RefreshCommandValidator validator = new RefreshCommandValidator();
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid Tokens", validationResult);

		User? user = await _userRepository.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);
		if (user == null)
			throw new NotFoundException(nameof(User), request.RefreshToken);

		JwtSecurityToken jwtSecurityToken = await _tokenService.GenerateAccessTokenAsync(user);
		user.AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
		user.AccessTokenExpirationDate = jwtSecurityToken.ValidTo;

		string refreshToken = _tokenService.GenerateRefreshToken();
		user.RefreshToken = refreshToken;
		user.RefreshTokenExpirationDate = DateTime.UtcNow.AddDays(1);

		await _userRepository.UpdateAsync(user);

		RefreshResponse response = new RefreshResponse
		{
			AccessToken = user.AccessToken,
			RefreshToken = user.RefreshToken
		};
		return response;
	}
}
