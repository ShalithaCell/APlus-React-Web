using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class TransactionController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public TransactionController(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addTransaction")]
        public async Task<IActionResult> AddNewTransaction([FromBody] NewTransactionModel dataModel)
        {
            try { 
                TransactionDetails transactionDetails = new TransactionDetails
                {
                    Transaction_ID = dataModel.Transaction_ID,
                    Description = dataModel.Description,
                    User_ID = dataModel.User_ID,
                    Date = dataModel.Date,
                    Time = dataModel.Time,
                    Quantity = dataModel.Quantity,
                    Unit_price = dataModel.Unit_price,
                    Total = dataModel.Total,
                };

                _context.TransactionDetails.Add(transactionDetails);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        }
   
}