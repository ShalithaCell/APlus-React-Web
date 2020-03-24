using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataTransactionModels
{
    public class ForgotEmailData
    {
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string PasswordResetUrl { get; set; }
    }
}
