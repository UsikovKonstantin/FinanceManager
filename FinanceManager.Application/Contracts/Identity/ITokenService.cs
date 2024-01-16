using FinanceManager.Domain;

namespace FinanceManager.Application.Contracts.Identity;

public interface ITokenService
{
	Task<string> GenerateAccessTokenAsync(User user);
	string GenerateRefreshToken();
}
