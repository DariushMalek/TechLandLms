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
    [Route("[controller]")]
    [ApiController]
    public class RelatedProductController : BaseApiController<RelatedProduct, BaseDto, IRelatedProductService, LogInfo>
    {
        public RelatedProductController(IRelatedProductService relatedProductService)
        {
            _entityService = relatedProductService;
        }
    }
}
