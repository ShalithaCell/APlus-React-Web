using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
            await _context.SaveChangesAsync();

            return Ok();
        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getcustomer")]
        public async Task<IActionResult> GetCustomer()
        {

            var customers = _context.customers.Where(o => o.IsActive == true).ToList();

            return Ok(customers);
        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("removecustomer")]
        public async Task<IActionResult> Deletecustomer([FromBody] JObject customerss)
        {
            customer cus = _context.customers.Where(o => o.ID == Convert.ToInt32(customerss["customerId"].ToString())).FirstOrDefault();

            if (cus == null)
            {
                return BadRequest();
            }

            _context.customers.Remove(cus);
            await _context.SaveChangesAsync();

            return Ok();


        }

    }
}   