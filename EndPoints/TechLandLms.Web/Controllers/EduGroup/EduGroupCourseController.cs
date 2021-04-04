using Microsoft.AspNetCore.Mvc;
using TechLandLms.Core.Entities;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common.DtoBase;
using TechLandTools.Web.Api;

namespace TechLandLms.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EduGroupCourseController : BaseApiController<EduGroupCourse, BaseDto, IEduGroupCourseService, LogInfo>
    {
        public EduGroupCourseController(IEduGroupCourseService cityService)
        {
            _entityService = cityService;
        }
    }
}
