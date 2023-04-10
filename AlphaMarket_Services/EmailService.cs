using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using MimeKit;
using System.Net.Http.Headers;
using MailKit.Net.Smtp;
using System.Security.Authentication;
using MailKit.Security;
using MailKit;
using Microsoft.Extensions.Configuration;

namespace AlphaMarket_Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        public EmailSettings _emailSettings { get; set; }
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;            
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "noreply@trendmarket.site"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            //25 110/ 465 /587/ 993
            using (var client = new SmtpClient(new ProtocolLogger("smtp.log")))
            {
                _emailSettings = _configuration.GetSection("MailService").Get<EmailSettings>();
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.CheckCertificateRevocation = false;
                client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Ssl2 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls12 | SslProtocols.Tls13;
                await client.ConnectAsync("mail.trendmarket.site", 465, false);

                await client.AuthenticateAsync(_emailSettings.emailusername, _emailSettings.emailpassword);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);                
            }
        }
    }
}
