using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.API.Domain.APIReqModels;
using Portal.API.Domain.DataBaseModels;
using Portal.API.Domain.IdentityModel;
using Portal.API.Infrastructure;
using Portal.API.Infrastructure.DAL.DatabaseContext;

namespace Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestAddController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public RequestAddController(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addRequests")]
        public async Task<IActionResult> AddRequests([FromBody] NewAddRequestModel dataAddRequest)
        {
         
            
                RequestAddTables requestsAdd = new RequestAddTables
                {
                    IsActive = true,
                    RegistedDate = DateTime.Now,
                    FirstName = dataAddRequest.fname,
                    LastName = dataAddRequest.lname,
                    Email = dataAddRequest.email,
                    Address = dataAddRequest.address,
                    PhoneNumber = dataAddRequest.phoneno,
                    Role = dataAddRequest.role,
                    password = dataAddRequest.pw,
                    passwordConfirm = dataAddRequest.pwconfirm,
                };
                _context.requestAddTable.Add(requestsAdd);
                _context.SaveChanges(true);
                return Ok();

            }
            
        }

       

    
}