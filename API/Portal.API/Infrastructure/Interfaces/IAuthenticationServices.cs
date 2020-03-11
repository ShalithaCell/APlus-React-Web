using Portal.API.Domain.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Infrastructure.Interfaces
{
    public interface IAuthenticationServices
    {
        public AuthenticatedResult GenerateJWT(AuthenticatedResult authenticatedResult);
    }
}
