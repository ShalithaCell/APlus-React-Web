using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.SystemModels
{
    public class TemplateParams
    {
        public string ExceptionMailTemplate { get; set; }
        public string ForgotPasswordMailTemplate { get; set; }

        public string AccountVerificationTemplate { get; set; }
    }
}
