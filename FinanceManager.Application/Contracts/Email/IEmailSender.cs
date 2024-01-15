using FinanceManager.Application.Models.Email;

namespace FinanceManager.Application.Contracts.Email;

public interface IEmailSender
{
	Task SendEmailAsync(EmailMessage email);
}
