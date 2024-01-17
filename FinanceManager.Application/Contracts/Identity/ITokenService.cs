using FinanceManager.Domain;
using System.IdentityModel.Tokens.Jwt;

namespace FinanceManager.Application.Contracts.Identity;

public interface ITokenService
{
	Task<JwtSecurityToken> GenerateAccessTokenAsync(User user);
	string GenerateRefreshToken();
}