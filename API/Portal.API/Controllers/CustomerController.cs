using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Portal.API.Domain.APIReqModels;
using Portal.API.Domain.DataBaseModels;
using Portal.API.Domain.DataTransactionModels;
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
            try
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

                _context.customer.Add(Customer);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            

            return Ok();
        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getcustomer")]
        public async Task<IActionResult> GetCustomer()
        {

            var customers = _context.customer.Where(o => o.IsActive == true).ToList();

            return Ok(customers);
        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("removecustomer")]
        public async Task<IActionResult> Deletecustomer([FromBody] JObject customerss)
        {
            customer cus = _context.customer.Where(o => o.ID == Convert.ToInt32(customerss["customerId"].ToString())).FirstOrDefault();

            if (cus == null)
            {
                return BadRequest();
            }

            _context.customer.Remove(cus);
            await _context.SaveChangesAsync();

            return Ok();


        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("updateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerView customerView)
        {
            var customerUpdate  = _context.customer.Where(o => o.ID==customerView.Id).FirstOrDefault() ;
            if (customerUpdate == null)
            {
                return NotFound();
            }

            customerUpdate.ID = customerView.Id;
            customerUpdate.fname = customerView.fname;
            customerUpdate.lname = customerView.lname;
            customerUpdate.email = customerView.email;
            customerUpdate.id_number = customerView.id_number;
            customerUpdate.phone_number = customerView.phone_number;

            try
            {
                _context.customer.Update(customerUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok();
            
        }
    }
}   