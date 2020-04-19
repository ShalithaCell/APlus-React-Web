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
    public class CashierController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public CashierController(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addBill")]

        public async Task<IActionResult> AddBills([FromBody] List<CashierModel> datamdle)
        {
            
            List<CashierData> cashierdata = datamdle.Select(sb => new CashierData
            {
                IsActive = true,
                RegistedDate = DateTime.Now,
                Description = sb.description,
                Qty = sb.qty,
                UnitPrice = sb.unitPrice,
                Sum = sb.sum,
                SubTotal = sb.subTotal,
                Total = sb.total
            }).ToList();

            _context.cashierDatas.AddRange(cashierdata);
            _=_context.SaveChangesAsync();

            return Ok();
        }
    }
}