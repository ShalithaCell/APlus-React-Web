using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
        private RequestAddTables requestDelete;

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

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getRequestInfomation")]
        public async Task<IActionResult> GetRequestInformation()
        {
            var requestInfo = _context.requestAddTable.Where(o => o.IsActive == true).ToList();

            return Ok(requestInfo);
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getRequest")]
        public async Task<IActionResult> GetRequest()
        {
            var requests = _context.requestAddTable.Where(o => o.IsActive == true).ToList();
            return Ok(requests);
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("removeRequest")]
        public async Task<IActionResult> RemoveRequest([FromBody] JObject requestRes)
        {

            RequestAddTables request = _context.requestAddTable.Where(o => o.ID == Convert.ToInt32(requestRes["requestId"].ToString())).FirstOrDefault();

            if (request == null)
            {
                return BadRequest();
            }


             _context.requestAddTable.Remove(request);
            _context.SaveChanges(true);

            return Ok();

        }

    }

       
    
    
}