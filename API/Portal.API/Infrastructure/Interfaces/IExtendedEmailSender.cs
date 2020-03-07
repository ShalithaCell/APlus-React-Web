using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Infrastructure.Interfaces
{
    /// <summary>
    /// Extended the IEmailSender interface
    /// </summary>
    /// <author>
    /// Developed by - Shalitha Senanayaka
    /// Modified by - 
    /// </author>
    public interface IExtendedEmailSender : IEmailSender
    {
        /// <summary>
        /// Send email to multiple receivers 
        /// </summary>
        /// <param name="emails"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        /// <returns></returns>
        Task SendBulkEmailAsync(string[] emails, string subject, string htmlMessage);
    }
}
