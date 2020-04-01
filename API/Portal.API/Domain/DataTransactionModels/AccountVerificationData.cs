using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataTransactionModels
{
    public class AccountVerificationData
    {
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
        public string Title { get; set; }
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
    }
}
