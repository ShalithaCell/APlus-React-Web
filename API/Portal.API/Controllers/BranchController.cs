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
    public class BranchController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;

        public BranchController(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("addBranch")]
        public async Task<IActionResult> AddBranch([FromBody] BranchModel b)
        {
            try
            {
                Branch branch = new Branch
                {

                    RegistedDate = DateTime.Now,
                    IsActive = true,
                    BranchName = b.B_Name,
                    OrgName = b.Org_Name,
                    BranchLocation = b.B_Location,
                    BranchPhone = b.B_Phone,
                    NoofEmployees = b.B_Employee,
                    OrganizationFK = 1
                };

                _context.branches.Add(branch);
                await _context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {
                throw e;
            }
        }



        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("deleteBranch")]
        public async Task<IActionResult> DeleteBranch([FromBody] JObject branchRes)
        {
            Branch branch = _context.branches.Where(o => o.ID == Convert.ToInt32(branchRes["branchId"].ToString())).FirstOrDefault();

            if (branch == null)
            {
                return BadRequest();
            }

            _context.branches.Remove(branch);
            await _context.SaveChangesAsync();

            return Ok();


        }


        [Authorize(Roles = Const.RoleAdminOrSuperAdmin)]
        [HttpPost("updateBranch")]
        public async Task<IActionResult> UpdateBranch(int id, BranchView branchView)
        {
            if (id != branchView.Id)
            {
                return BadRequest();
            }

            var branchUpdate = await _context.branches.FindAsync(id);
            if (branchUpdate == null)
            {
                return NotFound();
            }
            branchUpdate.ID = branchView.Id;
            branchUpdate.BranchName = branchView.BranchName;
            branchUpdate.BranchLocation = branchView.BranchLocation;
            branchUpdate.BranchPhone = branchView.BranchPhone;
            branchUpdate.NoofEmployees = branchView.NoofEmployees;

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
        [HttpGet("getBranch")]
        public async Task<IActionResult> GetBranch()
        {
            var branchers = _context.branches.Where(o => o.IsActive == true).ToList();

            return Ok(branchers);
        }

        private ActionResult<BranchView> BranchView(Branch getbranch)
        {
            throw new NotImplementedException();
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
