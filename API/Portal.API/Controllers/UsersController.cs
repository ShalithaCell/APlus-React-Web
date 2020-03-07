using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.API.Domain.APIReqModels;
using Portal.API.Domain.IdentityModel;
using Portal.API.Domain.ResultModels;
using Portal.API.Infrastructure.DAL.DatabaseContext;
using Portal.API.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Controllers
{
    /// <summary>
    /// Control all user base operations
    /// </summary>
    /// <developer>
    /// Developed by Shalitha Senanayaka
    /// </developer>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthenticationServices _authenticationServices;


        public UsersController(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthenticationServices authenticationServices)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationServices = authenticationServices;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            AuthenticatedResult authenticatedResult = new AuthenticatedResult();
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //current user
                var user = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(true);
                // Get the roles for the user
                var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(true);
                var RoleDetails = _context.Roles.Where(o => o.Name == roles[0]).FirstOrDefault();

                authenticatedResult.Authenticated = true;
                authenticatedResult.Email = user.Email;
                authenticatedResult.OrgID = 1;
                authenticatedResult.Role = RoleDetails.DisplayName;
                authenticatedResult.RoleID = RoleDetails.Id;
                authenticatedResult.UserID = user.Id;
                authenticatedResult.UserName = user.UserName;
                authenticatedResult.StatusCode = StatusCodes.Status200OK;
                authenticatedResult = _authenticationServices.GenerateJWT(authenticatedResult);

                return Ok(authenticatedResult);
            }
            else if(result.RequiresTwoFactor)
            {
                authenticatedResult.Authenticated = false;
                authenticatedResult.StatusCode = StatusCodes.Status203NonAuthoritative;
                authenticatedResult.ErrorMessages = new List<string> { "two factor authentication is allowed. " };
                return Ok("vf");
            }
            else if (result.IsLockedOut)
            {
                authenticatedResult.Authenticated = false;
                authenticatedResult.StatusCode = StatusCodes.Status401Unauthorized;
                authenticatedResult.ErrorMessages = new List<string> { "Your account is locked. please contact your system administrator." };
                return Ok(authenticatedResult);
            }
            else
            {
                authenticatedResult.Authenticated = false;
                authenticatedResult.StatusCode = StatusCodes.Status401Unauthorized;
                authenticatedResult.ErrorMessages = new List<string> { "Username or Password is incorrect !" };
                return Ok(authenticatedResult);
            }

            
        }
    }
}
