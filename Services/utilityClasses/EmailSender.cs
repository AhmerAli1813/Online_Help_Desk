using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OHD.Services.utilityClasses
{
    public interface IEmailSender
    {
         Task SendEmailAsync(string subject, string body, string receiver);
    }
        public class EmailSender : IEmailSender
        {
        
            public async Task SendEmailAsync(string subject, string body, string receiver)
            {
            
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("ohdhrdepartment@outlook.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(receiver);

                    using (var client = new SmtpClient())
                    {
                        client.EnableSsl = true;
                        client.Host = "smtp.office365.com";
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Credentials = new NetworkCredential("ohdhrdepartment@outlook.com", "OHD1234%^&");

                        await client.SendMailAsync(mailMessage);
                    }
        }

    }
    }


