using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Interfaces.System
{
    /// <summary>
    /// Extended the default email sending method to send bulk emails
    /// https://stackoverflow.com/questions/59135349/can-i-send-emails-to-multiple-receivers-using-iemailsender-interface-in-asp-net
    /// </summary>
    public interface IExtendedEmailSender : IEmailSender
    {
        /// <summary>
        /// Send email to multiple receivers 
        /// </summary>
        /// <param name="emails">Email array</param>
        /// <param name="subject">Subject of the email</param>
        /// <param name="htmlMessage">Email body</param>
        /// <returns></returns>
        Task SendBulkEmailAsync(string[] emails, string subject, string htmlMessage);
    }
}
