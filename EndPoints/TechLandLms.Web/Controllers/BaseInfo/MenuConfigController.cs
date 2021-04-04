
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechLandLms.Core.Entities;
using TechLandLms.Model.Dto;
using TechLandLms.Services.Interfaces;
using TechLandTools.Web.Api;

namespace TechLandLms.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuConfigController : BaseApiController<MenuConfig, MenuConfigDto, IMenuConfigService, LogInfo>
    {
        public MenuConfigController(IMenuConfigService menuConfigService)
        {
            _entityService = menuConfigService;
        }

        [HttpGet("GetMenuItems")]
        public ActionResult GetMenuItems()
        {
            var entities = _entityService.GetMenuConfigViewModel(User.Identity.Name);
            return Ok(entities);
        }
    }
}
