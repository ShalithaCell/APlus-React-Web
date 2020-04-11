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
    public class SalaryController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public SalaryController(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addSalary")]
        public async Task<IActionResult> AddNewSalary([FromBody] NewSalaryModel dataModel)
        {
            try
            {
                SalaryDetails salaryDetails = new SalaryDetails
                {
                    Salary_ID = dataModel.salary_ID,
                    Name = dataModel.name,
                    Eid = dataModel.eid,
                    Basic = dataModel.basic,
                    Bonus = dataModel.bonus,
                    Attendance = dataModel.attendance,
                    Paid_date = dataModel.paid_date,
                    For_month = dataModel.for_month,
                    Total = dataModel.total,
                };

                _context.SalaryDetails.Add(salaryDetails);
                _ = _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}