using Microsoft.AspNetCore.Http;
using Portal.ApplicationCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.ApplicationCore.Services.SessionService
{
    /// <summary>
    /// Manage all session operations, Simply get and set session
    /// </summary>
    public class SessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Set Session
        /// </summary>
        /// <typeparam name="T"> Data Type you want to store</typeparam>
        /// <param name="sessionKey"> Session Key</param>
        /// <param name="sesssionValue"> Session Value </param>
        public void SetSession<T>(string sessionKey, T sesssionValue)
        {

            switch (Type.GetTypeCode(sesssionValue.GetType()))
            {
                case TypeCode.Int32:
                    _session.SetInt32(sessionKey, (int)(object)sesssionValue);
                    break;
                case TypeCode.String:
                    _session.SetString(sessionKey, (string)(object)sesssionValue);
                    break;
                case TypeCode.Boolean:
                    _session.SetBoolean(sessionKey, (bool)(object)sesssionValue);
                    break;
                case TypeCode.Double:
                    _session.SetDouble(sessionKey, (double)(object)sesssionValue);
                    break;
                default:
                    _session.SetObjectAsJson(sessionKey, (T)(object)sesssionValue);
                    break;
            }

        }

        /// <summary>
        /// Get Session
        /// </summary>
        /// <typeparam name="T"> Data Type you want to pull</typeparam>
        /// <param name="sessionKey"> Stored Session Key </param>
        /// <returns></returns>
        public T GetSession<T>(string sessionKey)
        {
            T sessionValue;
            Type type = typeof(T);

            if (type == typeof(int))
                sessionValue = (T)(object)_session.GetInt32(sessionKey);
            else if (type == typeof(string))
                sessionValue = (T)(object)_session.GetString(sessionKey);
            else if (type == typeof(Boolean))
                sessionValue = (T)(object)_session.GetBoolean(sessionKey);
            else if (type == typeof(Double))
                sessionValue = (T)(object)_session.GetDouble(sessionKey);
            else
                sessionValue = (T)(object)_session.GetObjectFromJson<T>(sessionKey);


            return sessionValue;
        }
    }
}
