using Pawel.Cms.Domain.Services.Interfaces;
using System;
using System.Net;
using System.Net.Mail;

namespace Pawel.Cms.Domain.Services.Implementation
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string subject, string body, string to = null)
        {
            var senderAccount = "testowekontomvc@gmail.com";
            const string senderAccountPassword = "Mvc753951";

            var fromAddress = new MailAddress(senderAccount, subject);
            var toAddress = new MailAddress(to ?? senderAccount);
            
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, senderAccountPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true               
            })
            {
                smtp.Send(message);
            }
        }

        public string CreateActivationLinkBody(Guid id)
        {
            //get user by id , 

            var baseApiUrlFromConfig = "https://localhost:44331";

            var link = $"{baseApiUrlFromConfig}/api/users/ActivationUser/{id}";

            return $"<h2>Cms - potwierdzenie rejestracji</h2> " +
                $"<br/>" +
                $"<br/>" +
                $"<br/>" +
                $"<br/>" +
                $"<a href='{link}'>Aktywuj konto</a>" +
                $"<br/>" +
                $"<br/>" +
                $"<br/>" +
                $"";
        }
    }
}
