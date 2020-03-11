using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.ApplicationCore.service.CommonServices
{
    public class DataValidationManager
    {
        public static bool CheckIsValiedEmailAddress(string address)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(address);
                return addr.Address == address;
            }
            catch
            {
                return false;
            }
        }
    }
}
