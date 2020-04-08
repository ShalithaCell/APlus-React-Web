using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.API.Domain.APIReqModels;
using Portal.API.Domain.DataBaseModels;
using Portal.API.Domain.IdentityModel;
using Portal.API.Infrastructure;
using Portal.API.Infrastructure.DAL.DatabaseContext;
using System;
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
    }
}