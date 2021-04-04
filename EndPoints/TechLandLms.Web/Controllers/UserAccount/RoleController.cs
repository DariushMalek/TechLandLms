using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Model.Dto;
using TechLandLms.Services.Interfaces;
using TechLandTools.Web.Api;

namespace TechLandLms.Web.Controllers.UserAccount
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : BaseApiController<Role, RoleDto, IRoleService, LogInfo>
    {
        private IRoleFeatureService _roleFeatureService;
        public RoleController(IRoleService roleService, IRoleFeatureService roleFeatureService)
        {
            _entityService = roleService;
            _roleFeatureService = roleFeatureService;
        }

        [HttpGet("GetFeatureListWithRoleStatus/{roleId}")]
        public async Task<IActionResult> GetFeatureListWithRoleStatus(int roleId)
        {
            var entities = _roleFeatureService.GetFeatureListWithRoleStatus(roleId);
            return Ok(entities);
        }

    }
}
