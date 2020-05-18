using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Portal.API.Domain.APIReqModels;
using Portal.API.Domain.DataBaseModels;
using Portal.API.Domain.DataTransactionModels;
using Portal.API.Domain.IdentityModel;
using Portal.API.Infrastructure;
using Portal.API.Infrastructure.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrgController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public OrgController(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addOrg")]
        public async Task<IActionResult> AddOrg([FromBody] OrgModel b)
        {
            try
            {
                Organization org = new Organization
                {

                    RegistedDate = DateTime.Now,
                    IsActive = true,
                    OrgName = b.Org_Name,
                    OrgLocation = b.Org_Location,
                   };

                _context.organizations.Add(org);
                await _context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {
                throw e;
            }
        }



        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("deleteOrg")]
        public async Task<IActionResult> DeleteOrg([FromBody] JObject orgRes)
        {
            Organization org = _context.organizations.Where(o => o.ID == Convert.ToInt32(orgRes["orgId"].ToString())).FirstOrDefault();

            if (org == null)
            {
                return BadRequest();
            }

            _context.organizations.Remove(org);
            await _context.SaveChangesAsync();

            return Ok();


        }


        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("updateOrg")]
        public async Task<IActionResult> UpdateBranch(int id, OrgModel orgView)
        {
            if (id != orgView.Id)
            {
                return BadRequest();
            }

            var branchUpdate = await _context.branches.FindAsync(id);
            if (branchUpdate == null)
            {
                return NotFound();
            }
            branchUpdate.ID = orgView.Id;
            branchUpdate.BranchName = orgView.Org_Name;
            branchUpdate.BranchLocation = orgView.Org_Location;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return NoContent();
        }


        /*        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
                [HttpGet]
                public async Task<ActionResult<IEnumerable<BranchView>>> GetBranches()
                {
                    return await _context.branches
                        .Select(x => BranchView(x))
                        .ToListAsync();
                }*/


        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpGet("getOrg")]
        public async Task<IActionResult> GetOrg()
        {
            var orgs = _context.organizations.Where(o => o.IsActive == true).ToList();

            return Ok(orgs);
        }

        

        //[Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        //[HttpGet("getBranches")]
        //public async Task<IActionResult> GetAllBranchList()
        //{
        //    var branchList = _context.branches.Select(o => new
        //    {
        //        ID = o.ID,
        //        roleName = o.Name,
        //        roleDisplayName = o.DisplayName,
        //        Editable = o.Editable
        //    }).OrderBy(o => o.ID).ToList();
        //    return Ok(branchList);
        //}

        //[Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        //[HttpPost("updateBranch")]
        //public async Task<IActionResult> UpdateBranch([FromBody] BranchModel b)
        //{







        //}


    }

}