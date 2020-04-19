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
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public CustomerController(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addcustomer")]

        public async Task<IActionResult> Addcustomers([FromBody] CustomerModel cu)
        {
            customer Customer = new customer
            {
                IsActive = true,
                RegistedDate = DateTime.Now,
                fname = cu.Fname,
                lname = cu.Lname,
                email = cu.Email,
                id_number = cu.Id_number,
                phone_number = cu.Phone_number
            };

            _context.customers.Add(Customer);
            _ = _context.SaveChangesAsync();

            return Ok();
        }
    }
}