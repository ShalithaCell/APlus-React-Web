using Portal.API.ApplicationCore.service.CommonServices;
using Portal.API.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Portal.API.ApplicationCore.service.MailService
{
    public class EmailSender : IExtendedEmailSender
    {
        // Our private configuration variables
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;

        // Get our parameterized configuration
        public EmailSender(string host, int port, bool enableSSL, string userName, string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
        }

        /// <summary>
        /// Send email to one receipt
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        /// <returns></returns>
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, htmlMessage) { IsBodyHtml = true }
            );
        }

        /// <summary>
        /// Send email to multiple receipts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        /// <param name="recipients"></param>
        /// <returns></returns>
        public Task SendBulkEmailAsync(string[] emails, string subject, string htmlMessage)
        {
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };

            MailMessage mailMessage = new MailMessage();
            mailMessage.Body = htmlMessage;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;

            foreach (string emailAdress in emails)
            {
                if (DataValidationManager.CheckIsValiedEmailAddress(emailAdress))
                    mailMessage.To.Add(emailAdress);
            }


            return client.SendMailAsync(mailMessage); ;
        }
    }
}
