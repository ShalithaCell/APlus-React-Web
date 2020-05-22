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
                    Name = dataModel.name,
                    Designation = dataModel.designation,
                    Eid = dataModel.eid,
                    Basic = dataModel.basic,
                    Bonus = dataModel.bonus,
                    Attendance = dataModel.attendance,
                    For_month = dataModel.for_month,
                    Total = dataModel.total,
                };

                _context.SalaryDetails.Add(salaryDetails);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getSalaryInfomation")]
        public async Task<IActionResult> GetSalaryInformation()
        {
            var salaries = _context.SalaryDetails.Where(o => o.IsActive == true).ToList();

            return Ok(salaries);

        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("viewSalaries")]
        public async Task<IActionResult> GetAllSalaries()
        {
            var salaryList = _context.SalaryDetails.Select(o => new
            {

                ID = o.ID,
                RegistedDate = DateTime.Now,
                IsActive = true,
                name = o.Name,
                designation = o.Designation,
                eid = o.Eid,
                basic = o.Basic,
                bonus = o.Bonus,
                attendance = o.Attendance,
                for_month = o.For_month,
                total = o.Total


            }).OrderBy(o => o.ID).ToList();
            return Ok(salaryList);
        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("deleteSalaries")]
        public async Task<IActionResult> RemoveSalary([FromBody]JObject salaryRes)
        {
            SalaryDetails salaries = _context.SalaryDetails.Where(o => o.ID == Convert.ToInt32(salaryRes["id"].ToString())).FirstOrDefault();
            if (salaries == null)
            {
                return BadRequest();
            }

            _context.SalaryDetails.Remove(salaries);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("updateSalaries")]
        public async Task<IActionResult> UpdateSalaries(NewSalaryModel salaryModel)
        {

            var updateSal = await _context.SalaryDetails.FindAsync(salaryModel.ID);
            if (updateSal == null)
            {
                return NotFound();
            }
            updateSal.ID = salaryModel.ID;
            updateSal.Name = salaryModel.name;
            updateSal.Designation = salaryModel.designation;
            updateSal.Eid = salaryModel.eid;
            updateSal.Basic = salaryModel.basic;
            updateSal.Bonus = salaryModel.bonus;
            updateSal.Attendance = salaryModel.attendance;
            updateSal.For_month = salaryModel.for_month;
            updateSal.Total = salaryModel.total;

            try
            {
                _context.SalaryDetails.Update(updateSal);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return NoContent();

        }
    }
   
}