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
using System.Web;

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
                                            , IOptions<ConfigurationParams> config, IOptions<TemplateParams> templateParams, IHostingEnvironment hostingEnvironment, IExtendedEmailSender emailSender)
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
        [HttpGet("forTest")]
        public async Task<IActionResult> ForTest()
        {
            return Ok(true);
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
                var user = await _userManager.FindByNameAsync(model.Email).ConfigureAwait(true);
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
                authenticatedResult.Phone = user.PhoneNumber;
                authenticatedResult.StatusCode = StatusCodes.Status200OK;
                authenticatedResult = _authenticationServices.GenerateJWT(authenticatedResult);

                return Ok(authenticatedResult);
            }
            else if (result.RequiresTwoFactor)
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

        [AllowAnonymous]
        [HttpPost("resetPasswordMobile")]
        public async Task<IActionResult> SendPasswordResetLinkMobile([FromBody] ForgotPasswordReq model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return Ok(false);
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                bool available = true;
                int mCode = 0;

                Random rnd = new Random();
                do
                {

                    mCode = rnd.Next(100000, 999999);
                    var isAvailable = _context.passwordResetTokens.Where(o => o.MobileCode == mCode.ToString()).FirstOrDefault();
                    available = isAvailable == null;
                } while (!available);


                //insert to database
                PasswordResetToken passwordResetToken = new PasswordResetToken
                {
                    UserID = user.Id,
                    IsActive = true,
                    RegistedDate = DateTime.Now,
                    MobileCode = mCode.ToString(),
                    Token = code
                };

                _context.passwordResetTokens.Add(passwordResetToken);
                _ = _context.SaveChangesAsync();

                ForgotEmailDataMobile forgotEmailData = new ForgotEmailDataMobile
                {
                    Company = _config.Value.CompanyName,
                    Email = model.Email,
                    code = mCode.ToString(),
                    SiteName = _config.Value.SolutionName,
                    SiteUrl = _config.Value.BaseURL
                };

                await _emailSender.SendEmailAsync(model.Email, "APlus Account Password Reset", DataFormatManager.GetFormatedForgotPasswordEmailTemplate(forgotEmailData, _hostingEnvironment.ContentRootPath + _templateParams.Value.ForgotPasswordMailTemplateMobile));

                return Ok(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [AllowAnonymous]
        [HttpPost("checkPasswordResetToken")]
        public async Task<IActionResult> PasswordResetTokenValidation([FromBody] JObject objToken)
        {
            string token = objToken["token"].ToString();

            PasswordResetToken passwordResetToken = _context.passwordResetTokens.Where(o => o.Token == token).FirstOrDefault();

            if(passwordResetToken == null)
            {
                return Ok(new { valid = 0 });
            }

            double minites = (DateTime.Now - passwordResetToken.RegistedDate).TotalMinutes;

            if(minites > 10)
            {
                return Ok(new { valid = 0 });
            }

            return Ok(new { valid = 1 });

        }


        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("getAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromBody] JObject role)
        {
            int RoleID = Convert.ToInt32(role["roleId"].ToString());

            List<UserListResult> usersResult = new List<UserListResult>();
            List<AppUser> users = _userManager.Users.ToList();

            UserListResult userResult;
            AppRole roleForUser;
            foreach (AppUser user in users)
            {
                userResult = new UserListResult();

                roleForUser = new AppRole();

                var roleList = await _userManager.GetRolesAsync(user).ConfigureAwait(true);
                var RoleDetails = _context.Roles.Where(o => o.Name == roleList[0]).FirstOrDefault();

                userResult.ID = user.Id;
                userResult.RoleID = RoleDetails.Id;
                userResult.RoleName = RoleDetails.Name;
                userResult.UserName = user.UserName;
                userResult.Email = user.Email;
                userResult.Locked = user.EmailConfirmed ? "YES" : "NO";

                userResult.modifyAllowed = userResult.RoleID >= RoleID;

                usersResult.Add(userResult);
            }

            return Ok(usersResult);
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdminOrAuthUser)]
        [HttpGet("getUserNames")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userNames = _context.Users.Select(o => new { o.UserName , o.Email}).ToList();

            return Ok(userNames);
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdminOrAuthUser)]
        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] NewUserInputModel model)
        {
            // search role
            var role = _roleManager.FindByIdAsync(model.RoleID).Result;

            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                OrganizationID = model.OrgID,
                EmailConfirmed = false,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // code for adding user to role
                await _userManager.AddToRoleAsync(user, role.Name);

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var uriBuilder = new UriBuilder(model.BaseUrl + "/confirm");
                var parameters = HttpUtility.ParseQueryString(string.Empty);
                parameters["userId"] = user.Id.ToString();
                parameters["code"] = code;
                uriBuilder.Query = parameters.ToString();

                Uri finalUrl = uriBuilder.Uri;

                AccountVerificationData verificationData = new AccountVerificationData
                {
                    UserName = model.UserName,
                    SiteName = _config.Value.SolutionName,
                    BaseUrl = finalUrl.AbsoluteUri,
                    Title = "APlus Account Verification",
                    SiteUrl = _config.Value.BaseURL

                };

                await _emailSender.SendEmailAsync(model.Email, "APlus Account Verification", DataFormatManager.GetFormatedAccountVerificationEmailTemplate(verificationData, _hostingEnvironment.ContentRootPath + _templateParams.Value.AccountVerificationTemplate));
                
                return Ok(new
                {
                    result = true,
                    message = ""
                });
            }
            else
            {
                List<string> list = new List<string>();
                foreach (var error in result.Errors)
                {
                    list.Add(error.Description);
                }
                return Ok(new
                {
                    result = false,
                    message = list
                });
            }

        }

        

        [Authorize(Roles = Const.RoleAdminOrSuperAdminOrAuthUser)]
        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUpdateModel model)
        {
            // search role
            var role = _roleManager.FindByIdAsync(model.RoleID).Result;

            AppUser user = await _userManager.FindByEmailAsync(model.Email);

            user.PhoneNumber = model.PhoneNumber;

            await _userManager.UpdateAsync(user);
            
            //update password
            if(model.Password.Length != 0)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, token, model.Password);

            }

            //update role
            var roleList = await _userManager.GetRolesAsync(user).ConfigureAwait(true);
            var RoleDetails = _context.Roles.Where(o => o.Name == roleList[0]).FirstOrDefault(); //current role

            if(role.Name != RoleDetails.Name)
            {
                await _userManager.RemoveFromRoleAsync(user, RoleDetails.Name);
                await _userManager.AddToRoleAsync(user, role.Name);
            }

            return Ok(new
            {
                result = true,
                message = ""
            });
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdminOrAuthUser)]
        [HttpPost("removeUser")]
        public async Task<IActionResult> RemoveUser([FromBody] JObject userID)
        {
            var user = await _userManager.FindByIdAsync(userID["userID"].ToString());
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    result = true
                });
            }
            else
            {
                return Ok(new
                {
                    result = false,
                    message = result.Errors
                }); ;
            }
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdminOrAuthUser)]
        [HttpPost("getSpecificUser")]
        public async Task<IActionResult> GetUser([FromBody] JObject roleRes)
        {
            AppUser user = await _userManager.FindByIdAsync(roleRes["userID"].ToString());

            var role = await _userManager.GetRolesAsync(user).ConfigureAwait(true);
            var RoleDetails = _context.Roles.Where(o => o.Name == role[0]).FirstOrDefault();

            return Ok(new
            {
                UserID = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                RoleID = RoleDetails.Id,
                Phone = user.PhoneNumber
            });
        }

        [AllowAnonymous]
        [HttpPost("confirmEmailAddress")]
        public async Task<IActionResult> ConfirmEmailAddress([FromBody] JObject obj)
        {
            var user = await _userManager.FindByIdAsync(obj["userID"].ToString());

            if (user == null)
                return NotFound("User ID is not valid");

            string code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(obj["code"].ToString()));

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return Ok(new { res = true } );
            }
            else
            {
                return Ok(new { res = false });
            }


        }

        [AllowAnonymous]
        [HttpPost("resentUserPassword")]
        public async Task<IActionResult> RestUserPassword([FromBody] JObject obj)
        {
            string token = obj["token"].ToString();
            string password = obj["password"].ToString();

            var tokenData = _context.passwordResetTokens.Where(o => o.Token == token).FirstOrDefault();

            if(tokenData == null)
            {
                return Ok(new { status = 0 });
            }

            var user = await _userManager.FindByIdAsync(tokenData.UserID.ToString());

            if(user == null)
            {
                return Ok(new { status = 0 });
            }

            double minites = (DateTime.Now - tokenData.RegistedDate).TotalMinutes;

            if(minites > 10)
            {
                return Ok(new { status = 2 });
            }

            var token2 = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token2, password);

            if (result.Succeeded)
            {
                return Ok(new { status = 1 });
            }
            else
            {
                return Ok(new { status = 0 });
            }
        }

        [AllowAnonymous]
        [HttpPost("resentUserPasswordMobile")]
        public async Task<IActionResult> RestUserPasswordMobile([FromBody] JObject obj)
        {
            string token = obj["token"].ToString();
            string password = obj["password"].ToString();

            var tokenData = _context.passwordResetTokens.Where(o => o.MobileCode == token).FirstOrDefault();

            if (tokenData == null)
            {
                return Ok(new { status = 0 });
            }

            var user = await _userManager.FindByIdAsync(tokenData.UserID.ToString());

            if (user == null)
            {
                return Ok(new { status = 0 });
            }

            double minites = (DateTime.Now - tokenData.RegistedDate).TotalMinutes;

            if (minites > 10)
            {
                return Ok(new { status = 2 });
            }

            var token2 = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token2, password);

            if (result.Succeeded)
            {
                return Ok(new { status = 1 });
            }
            else
            {
                return Ok(new { status = 0 });
            }
        }




    }
}
