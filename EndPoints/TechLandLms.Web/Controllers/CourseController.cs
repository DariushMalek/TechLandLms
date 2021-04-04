using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Dto.Models;
using TechLandLms.Model.Dto;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common.DtoBase;
using TechLandTools.Web.Api;

namespace TechLandLms.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : BaseApiController<Course, CourseDto, ICourseService, LogInfo>
    {
        public CourseController(ICourseService courseService)
        {
            _entityService = courseService;
        }
    }
}
