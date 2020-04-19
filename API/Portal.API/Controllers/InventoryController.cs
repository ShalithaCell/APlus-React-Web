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
    }
}