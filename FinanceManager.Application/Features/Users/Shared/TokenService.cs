using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Models.Identity;
using FinanceManager.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FinanceManager.Application.Features.Users.Shared;

public class TokenService : ITokenService
{
	private readonly JwtSettings _jwtSettings;
	private readonly IRoleRepository _roleRepository;

	public TokenService(IOptions<JwtSettings> jwtSettings, IRoleRepository roleRepository)
	{
		_jwtSettings = jwtSettings.Value;
		_roleRepository = roleRepository;
	}

	public async Task<string> GenerateAccessTokenAsync(User user)
	{
		IEnumerable<string> roles = await _roleRepository.GetRolesByUserIdAsync(user.Id);

		IEnumerable<Claim> roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));

		IEnumerable<Claim> claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? ""),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
			new Claim("uid", user.Id.ToString())
		}
		.Union(roleClaims);

		SymmetricSecurityKey symmKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

		SigningCredentials signinCredentials = new SigningCredentials(symmKey, SecurityAlgorithms.HmacSha256);

		JwtSecurityToken token = new JwtSecurityToken(
			issuer: _jwtSettings.Issuer,
			audience: _jwtSettings.Audience,
			claims: claims,
			expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
			signingCredentials: signinCredentials);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}

	public string GenerateRefreshToken()
	{
		return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
	}
}
