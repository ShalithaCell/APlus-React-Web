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
    public class RolesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public RolesController(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getRoles")]
        public async Task<IActionResult> GetAllRoleList()
        {
            var roleList = _context.Roles.Select(o => new
            {
                ID = o.Id,
                roleName = o.Name,
                roleDisplayName = o.DisplayName,
                Editable = o.Editable
            }).OrderBy(o => o.ID).ToList();
            return Ok(roleList);
        }

        [AllowAnonymous]
        [HttpGet("getRolesMobile")]
        public async Task<IActionResult> GetAllRoleListMobile()
        {
            var roleList = _context.Roles.Select(o => new
            {
                ID = o.Id,
                roleName = o.Name,
                roleDisplayName = o.DisplayName,
                Editable = o.Editable
            }).OrderBy(o => o.ID).ToList();
            return Ok(roleList);
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("registerRole")]
        public async Task<IActionResult> RegisterNewRole([FromBody] NewRoleModel dataModel)
        {
            AppRole newRole = new AppRole()
            {
                Name = dataModel.Name,
                DisplayName = dataModel.DisplayName,
                OrganizationID = dataModel.OrgID,
                Editable = true
            };

            _roleManager.CreateAsync(newRole).Wait();

            AppRole role = _context.Roles.Where(o => o.Name == dataModel.Name).FirstOrDefault();

            if (role == null)
            {
                return BadRequest("Something went wrong in the server side while registering a new role.");
            }

            List<CustomRolePermissionLevelc> customRolePermissions = dataModel.RolePermissionLevels.Select(o => new CustomRolePermissionLevelc
            {
                Allowed = o.Allowed,
                FK_CustomPermisson = o.CustomPermissonID,
                FK_RoleID = role.Id,
                IsActive = true,
                RegistedDate = DateTime.Now
            }).ToList();

            _context.customRolePermissionLevels.AddRange(customRolePermissions);
            _context.SaveChanges(true);


            return Ok();
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("getRoleInfomation")]
        public async Task<IActionResult> GetRoleInformation( [FromBody] RoleInfoReqData roleInfoReq)
        {
            NewRoleModel outputModel = new NewRoleModel();

            AppRole role = _context.Roles.Where(o => o.Id == roleInfoReq.RoleID).FirstOrDefault();

            if (role == null)
            {
                return BadRequest("RoleID id not valid !");
            }

            List<CustomRolePermissionLevelc> customRolePermissions = _context.customRolePermissionLevels.Where(o => o.FK_RoleID == roleInfoReq.RoleID).ToList();

            outputModel.DisplayName = role.DisplayName;
            outputModel.Name = role.Name;
            outputModel.OrgID = role.OrganizationID;
            outputModel.RolePermissionLevels = customRolePermissions.Select(o => new RolePermissionLevel
            {
                CustomPermissonID = o.FK_CustomPermisson,
                Allowed = o.Allowed
            }).ToList();

            return Ok(outputModel);

        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("updateRole")]
        public async Task<IActionResult> UpdateRoleInformation([FromBody] NewRoleModel dataModel)
        {
            AppRole role = _context.Roles.Where(o => o.Name == dataModel.Name).FirstOrDefault();

            role.DisplayName = dataModel.DisplayName;

            await _roleManager.UpdateAsync(role);

            List<CustomRolePermissionLevelc> exisingPermisson = _context.customRolePermissionLevels.Where(o => o.FK_RoleID == role.Id).ToList();

            if (exisingPermisson.Count == 0)
            {
                exisingPermisson = dataModel.RolePermissionLevels.Select(o => new CustomRolePermissionLevelc
                {
                    Allowed = o.Allowed,
                    FK_CustomPermisson = o.CustomPermissonID,
                    FK_RoleID = role.Id,
                    IsActive = true,
                    RegistedDate = DateTime.Now
                }).ToList();
            }
            else
            {
                for (int i = 0; i < dataModel.RolePermissionLevels.Count; i++)
                {
                    var match = exisingPermisson.Where(o => o.FK_CustomPermisson == dataModel.RolePermissionLevels[i].CustomPermissonID).FirstOrDefault();

                    if (match != null)
                    {
                        exisingPermisson.Where(o => o.FK_CustomPermisson == dataModel.RolePermissionLevels[i].CustomPermissonID).Select(c => { c.Allowed = dataModel.RolePermissionLevels[i].Allowed; return c; }).ToList();
                    }
                }
            }

            _context.customRolePermissionLevels.UpdateRange(exisingPermisson);
            _context.SaveChanges();

            return Ok();


        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("removeRole")]
        public async Task<IActionResult> RemoveRole([FromBody] JObject roleRes)
        {

            AppRole role = await _roleManager.FindByIdAsync(roleRes["roleId"].ToString());

            if(role == null)
            {
                return BadRequest();
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return Ok();
            }

            return Conflict(result.Errors.First().ToString());

        }
    }
}