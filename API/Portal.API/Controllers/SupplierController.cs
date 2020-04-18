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
    public class SupplierController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public SupplierController(ApplicationDbContext context, RoleManager<AppRole> roleManager) 
        {
            _context = context;
            _roleManager = roleManager;
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addSupplier")]

        public async Task<IActionResult> AddSupplier([FromBody] SupplierModel sup)
        {
            SupplierDetailsTable supplier = new SupplierDetailsTable
            {
                IsActive = true,
                RegistedDate = DateTime.Now,
                fname = sup.Finame,
                lname = sup.Laname,
                Email = sup.email,
                category = sup.CAtegory,
                area = sup.ARea,
                phoNumber = sup.PHoNumber

            };

            _context.supplierDetailsTables.Add(supplier);
            _= _context.SaveChangesAsync();

            return Ok("Added Supplier");
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("removeSupplier")]
        public async Task<IActionResult> DeleteSupplier([FromBody] JObject suppliers)
        {
            SupplierDetailsTable supplier = _context.supplierDetailsTables.Where(o => o.ID == Convert.ToInt32(suppliers["supplierId"].ToString())).FirstOrDefault();

            if (supplier == null)
            {
                return BadRequest();
            }

            _context.supplierDetailsTables.Remove(supplier);
            await _context.SaveChangesAsync();

            return Ok();


        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getSupplier")]
        public async Task<IActionResult> GetSupplier()
        {
            var suppliers = _context.supplierDetailsTables.Where(o => o.IsActive == true).ToList();

            return Ok(suppliers);
        }

    }
}