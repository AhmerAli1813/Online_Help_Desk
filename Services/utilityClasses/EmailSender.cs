using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.Services.utilityClasses
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    namespace YourNamespace
    {
        public class EmailSender
        {
            private readonly string _smtpServer;
            private readonly int _smtpPort;
            private readonly string _smtpUsername;
            private readonly string _smtpPassword;

            public EmailSender(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
            {
                _smtpServer = smtpServer;
                _smtpPort = smtpPort;
                _smtpUsername = smtpUsername;
                _smtpPassword = smtpPassword;
            }

            public async Task SendEmailAsync(string subject, string body, string sender, string receiver)
            {
                var smtpClient = new SmtpClient
                {
                    Host = _smtpServer,
                    Port = _smtpPort,
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(sender),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(receiver);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }

}
