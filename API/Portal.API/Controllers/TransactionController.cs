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
        [HttpGet("viewTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transList = _context.TransactionDetails.Select(o => new
            {

                ID = o.ID,
                RegistedDate = DateTime.Now,
                IsActive = true,
                description = o.Description,
                user_ID = o.User_ID,
                date = o.Date,
                time = o.Time,
                quantity = o.Quantity,
                unit_price = o.Unit_price,
                total = o.Total

            }).OrderBy(o => o.ID).ToList();
            return Ok(transList);
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addTransaction")]
        public async Task<IActionResult> AddNewTransaction([FromBody] NewTransactionModel dataModel)
        {
            try
            {
                TransactionDetails transactionDetails = new TransactionDetails()
                {
                    RegistedDate = DateTime.Now,
                    IsActive = true,
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
            catch (Exception e)
            {
                throw e;
            }
        }


        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getTransactionInfomation")]
        public async Task<IActionResult> GetTransactionInformation()
        {
            var transactions = _context.TransactionDetails.Where(o => o.IsActive == true).ToList();

            return Ok(transactions);

        }
        //[Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        //[HttpPost("updateTransactions")]
        //public async Task<IActionResult> UpdateTransactionInformation(string id, [FromBody] NewTransactionModel dataModel)
        //{
        //try
        //{
        //    try
        //    {
        //        TransactionDetails transactionDetails = new TransactionDetails()
        //        {
        //            Transaction_ID = dataModel.Transaction_ID
        //        };
        //        dataModel.Transaction_ID = id;

        //        _context.Entry(dataModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        _context.TransactionDetails.Update(transactionDetails);
        //        _ = _context.SaveChangesAsync();

        //        return Ok();
        //    }
        //    catch
        //    {
        //        if (dataModel.Transaction_ID != id)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //}
        //catch (Exception e)
        //{
        //    throw e;
        //}
        //  }
        //[Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        //[HttpPost("deleteTransactions")]
        //public async Task<IActionResult> RemoveTransaction([FromBody]JObject transRes)
        //{
        //    NewTransactionModel transaction = _context.TransactionDetails.Where(o => o.ID == Convert.ToInt32(transRes["transId"].ToString())).FirstOrDefault();
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TransactionDetails.Remove(transaction);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
    }
}