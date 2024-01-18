using FinanceManager.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinanceManager.Application.Contracts.Identity;

public interface ITokenService
{
	Task<JwtSecurityToken> GenerateAccessTokenAsync(User user);
	string GenerateRandomToken();
	ClaimsPrincipal? GetPrincipalFromAccessToken(string token);
}