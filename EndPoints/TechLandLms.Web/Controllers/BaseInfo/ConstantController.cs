using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common.DtoBase;
using TechLandTools.Web.Api;

namespace TechLandLms.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstantController : BaseApiController<Constant, BaseDto, IConstantService, LogInfo>
    {
        public ConstantController(IConstantService constantService)
        {
            _entityService = constantService;
        }

        [HttpGet("ConstantListByType/{typeName}")]
        public ActionResult<IEnumerable<Constant>> GetByKindName([FromRoute] string typeName)
        {
            var entities = _entityService.GetConstanListByType(typeName);
            if (entities == null)
            {
                return NotFound();
            }
            return Ok(entities);
        }
    }
}
