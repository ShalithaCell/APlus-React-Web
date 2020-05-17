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
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public AttendanceController(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addAttendance")]
        public async Task<IActionResult> AddAttendance([FromBody] NewAttendanceModel dataAddAttendance)
        {


            Attendances attendanceAdd = new Attendances
            {
                IsActive = true,
                RegistedDate = DateTime.Now,
                Name = dataAddAttendance.name,
                Role = dataAddAttendance.role,
                ClockOnTime = dataAddAttendance.onTime,
                ClockOutTime = dataAddAttendance.outTime,
                WorkingHours = dataAddAttendance.wHours,


            };
            _context.attendances.Add(attendanceAdd);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getAttendanceInfomation")]
        public async Task<IActionResult> GetAttendanceInformation()
        {
            var attendanceInfo = _context.attendances.Where(o => o.IsActive == true).ToList();

            return Ok(attendanceInfo);
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getAttendance")]
        public async Task<IActionResult> GetAttendance()
        {
            var attendances = _context.attendances.Where(o => o.IsActive == true).ToList();
            return Ok(attendances);
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("removeAttendance")]
        public async Task<IActionResult> RemoveAttendance([FromBody] JObject attendanceRes)
        {

            Attendances attendance = _context.attendances.Where(o => o.ID == Convert.ToInt32(attendanceRes["attendanceId"].ToString())).FirstOrDefault();

            if (attendance == null)
            {
                return BadRequest();
            }


            _context.attendances.Remove(attendance);
            _context.SaveChanges(true);

            return Ok();

        }

    }




}