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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public InventoryController(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addInventory")]
        public async Task<IActionResult> AddInventory([FromBody] InventoryModel dataInventory)
        {
                //Insert to Database
                Inventories inventory = new Inventories
                {
                    ProductCode = dataInventory.Pcode,
                    ProductName = dataInventory.PName,
                    Qty = dataInventory.Qty_,
                    SupplireName = dataInventory.SName,
                    SupplireEmail = dataInventory.SEmail,
                    UnitPrice = dataInventory.Uprice
                };

                _context.Inventories.Add(inventory);
                await _context.SaveChangesAsync();

                return Ok();
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("removeInventory")]
        public async Task<IActionResult>RemoveInventory([FromBody] JObject inventoryRes)
        {
            Inventories inventory = _context.Inventories.Where(o => o.ID == Convert.ToInt32(inventoryRes["inventoryId"].ToString())).FirstOrDefault();

            if (inventory == null)
            {
                return BadRequest();
            }

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("updateInventory")]

        public async Task<IActionResult> UpdateInventory([FromBody] JObject inventoryRes)
        {
            Inventories inventory = _context.Inventories.Where(o => o.ProductName == inventoryRes["Pname"].ToString()).FirstOrDefault();

            //add to 

            _context.Inventories.Update(inventory);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize]
        [HttpGet("getInventoryList")]

        public async Task<IActionResult> GetInventoryList()
        {
           var inventoryList = _context.Inventories.Where(o => o.IsActive == true).ToList();

           return Ok(inventoryList);
        }

    }
}