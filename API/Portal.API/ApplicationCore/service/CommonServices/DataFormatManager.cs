using Portal.API.Domain.DataTransactionModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.ApplicationCore.service.CommonServices
{
    public static class DataFormatManager
    {
        public static string GetFormatedForgotPasswordEmailTemplate(ForgotEmailData forgotEmailData, string path)
        {
            string text = File.ReadAllText(path);

            text = text.Replace("{siteName}", forgotEmailData.SiteName);
            text = text.Replace("{siteUrl}", forgotEmailData.SiteUrl);
            text  = text.Replace("{email}", forgotEmailData.Email);
            text = text.Replace("{company}", forgotEmailData.Company);
            text = text.Replace("{resetUrl}", forgotEmailData.PasswordResetUrl);

            return text;
        }

        public static string GetFormatedForgotPasswordEmailTemplate(ForgotEmailDataMobile forgotEmailData, string path)
        {
            string text = File.ReadAllText(path);

            text = text.Replace("{siteName}", forgotEmailData.SiteName);
            text = text.Replace("{siteUrl}", forgotEmailData.SiteUrl);
            text = text.Replace("{email}", forgotEmailData.Email);
            text = text.Replace("{company}", forgotEmailData.Company);
            text = text.Replace("{code}", forgotEmailData.code);

            return text;
        }

        public static string GetFormatedAccountVerificationEmailTemplate(AccountVerificationData accountVerificationData, string path)
        {
            string text = File.ReadAllText(path);

            text = text.Replace("{siteName}", accountVerificationData.SiteName);
            text = text.Replace("{siteUrl}", accountVerificationData.SiteUrl);
            text = text.Replace("{title}", accountVerificationData.Title);
            text = text.Replace("{confirmUrl}", accountVerificationData.BaseUrl);
            text = text.Replace("{userName}", accountVerificationData.UserName);

            return text;
        }
    }
}
