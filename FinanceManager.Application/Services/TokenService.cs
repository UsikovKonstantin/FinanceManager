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

namespace FinanceManager.Application.Services;

public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;
    private readonly IUserRepository _userRepository;

    public TokenService(IOptions<JwtSettings> jwtSettings, IUserRepository userRepository)
    {
        _jwtSettings = jwtSettings.Value;
		_userRepository = userRepository;
    }

    public async Task<JwtSecurityToken> GenerateAccessTokenAsync(User user)
    {
        IEnumerable<string> roles = await _userRepository.GetRolesByUserIdAsync(user.Id);

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
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenDurationInMinutes),
            signingCredentials: signinCredentials);

        return token;
    }

    public string GenerateRandomToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    public ClaimsPrincipal? GetPrincipalFromAccessToken(string token)
    {
        TokenValidationParameters validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false,
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
        };

        return new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out _);
    }
}
