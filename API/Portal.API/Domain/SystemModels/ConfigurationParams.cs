using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.SystemModels
{
    public class ConfigurationParams
    {
        public string SolutionName { get; set; }

        public string BaseURL { get; set; }

        public string CompanyName { get; set; }

        public string CompanyURL { get; set; }

        public string ExceptionMailReceiver { get; set; }

        public string DeveloperEmail { get; set; }

        public int SessionTimeout { get; set; }

        public int DefaultOrganizationID { get; set; }
        public string ResetEmailUrl { get; set; }
    }
}
