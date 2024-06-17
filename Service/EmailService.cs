using System;
using System.Threading.Tasks;
using api.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit.Text;

public class EmailSettings
{
    public string FromName { get; set; } = string.Empty;
    public string FromEmail { get; set; } = string.Empty;
    public string SmtpServer { get; set; } = string.Empty;
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; } = string.Empty;
    public string SmtpPass { get; set; } = string.Empty;
    public bool UseSsl { get; set; }
}

namespace api.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.FromEmail));
            emailMessage.To.Add(new MailboxAddress(email, email)); // Sử dụng địa chỉ email của người nhận để tạo MailboxAddress

            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(TextFormat.Html) { Text = message };

            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort,
                    _emailSettings.UseSsl ? SecureSocketOptions.Auto : SecureSocketOptions.StartTls);

                await client.AuthenticateAsync(_emailSettings.SmtpUser, _emailSettings.SmtpPass);

                await client.SendAsync(emailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw; // Ném lại ngoại lệ để xử lý ở mức cao hơn trong stack gọi nếu cần.
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }


        public async Task SendPasswordResetEmail(string email, string resetCode)
        {
            var resetLink = $"http://localhost:3000/reset-password?email={email}&code={resetCode}";
            var message = $"Please reset your password by clicking the following link: {resetLink}";

            await SendEmailAsync(email, "Password Reset Request", message);
        }
    }
}
