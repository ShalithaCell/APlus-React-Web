using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Portal.API.ApplicationCore.service.CommonServices;
using Portal.API.Domain.APIReqModels;
using Portal.API.Domain.DataBaseModels;
using Portal.API.Domain.DataTransactionModels;
using Portal.API.Domain.IdentityModel;
using Portal.API.Domain.ResultModels;
using Portal.API.Domain.SystemModels;
using Portal.API.Infrastructure;
using Portal.API.Infrastructure.DAL.DatabaseContext;
using Portal.API.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthenticationServices _authenticationServices;
        private readonly IExtendedEmailSender _emailSender;
        private readonly IOptions<ConfigurationParams> _config;
        private readonly IOptions<TemplateParams> _templateParams;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UsersController(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IAuthenticationServices authenticationServices
                                            ,IOptions<ConfigurationParams> config, IOptions<TemplateParams> templateParams, IHostingEnvironment hostingEnvironment, IExtendedEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationServices = authenticationServices;
            _config = config;
            _templateParams = templateParams;
            _hostingEnvironment = hostingEnvironment;
            _emailSender = emailSender;
            _roleManager = roleManager;
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
                return Ok(authenticatedResult);
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
                authenticatedResult.ErrorMessages = new List<string> { "Incorrect email or password." };
                return Ok(authenticatedResult);
            }

            
        }

        [AllowAnonymous]
        [HttpPost("resetPassword")]
        public async Task<IActionResult> SendPasswordResetLink([FromBody] ForgotPasswordReq model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return NotFound("Email address is not registered or wrong email.");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));


                //insert to database
                PasswordResetToken passwordResetToken = new PasswordResetToken
                {
                    UserID = user.Id,
                    IsActive = true,
                    RegistedDate = DateTime.Now,
                    Token = code
                };

                _context.passwordResetTokens.Add(passwordResetToken);
                _ = _context.SaveChangesAsync();

                ForgotEmailData forgotEmailData = new ForgotEmailData
                {
                    Company = _config.Value.CompanyName,
                    Email = model.Email,
                    PasswordResetUrl = _config.Value.ResetEmailUrl + "?token=" + code,
                    SiteName = _config.Value.SolutionName,
                    SiteUrl = _config.Value.BaseURL
                };

                await _emailSender.SendEmailAsync(model.Email, "APlus Account Password Reset", DataFormatManager.GetFormatedForgotPasswordEmailTemplate(forgotEmailData, _hostingEnvironment.ContentRootPath + _templateParams.Value.ForgotPasswordMailTemplate));

                return Ok("Email sent successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("getAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromBody] JObject role)
        {
            int roleID = Convert.ToInt32(role["roleId"].ToString());
            List<AppUser> users = _context.Users
        }



    }
}
