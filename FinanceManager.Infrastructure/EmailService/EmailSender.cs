using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using FinanceManager.Application.Contracts.Email;
using FinanceManager.Application.Models.Email;

namespace FinanceManager.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
	public EmailSettings _emailSettings { get; }

	public EmailSender(IOptions<EmailSettings> emailSettings)
	{
		_emailSettings = emailSettings.Value;
	}

	public async Task SendEmailAsync(EmailMessage email)
	{
		SmtpClient client = new SmtpClient(_emailSettings.Smtp, _emailSettings.Port)
		{
			EnableSsl = true,
			Credentials = new NetworkCredential(_emailSettings.FromMail, _emailSettings.FromPassword)
		};

		await client.SendMailAsync(_emailSettings.FromMail, email.ToMail, email.Subject, email.Message);
	}
}
