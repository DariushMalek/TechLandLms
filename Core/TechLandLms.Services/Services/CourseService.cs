using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Dto.Models;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common;
using TechLandTools.Common.Data;
using TechLandTools.Common.TechLandLog;

namespace TechLandLms.Services
{
    public class CourseService : ServiceBase<Course, LogInfo>, ICourseService
    {
        readonly IEduGroupService _eduGroupService;
        public CourseService(IAsyncRepository<Course> entityRepository, IEduGroupService eduGroupService, IHttpContextAccessor httpContextAccessor, IMapper mapper, ITechLandLogger<LogInfo> techLandLogger) : base(entityRepository, httpContextAccessor, mapper, techLandLogger)
        {
            _eduGroupService = eduGroupService;
        }

        public override void BeforeSubmit(Course entity)
        {
            base.BeforeSubmit(entity);
            if (!entity.DefaultGroupId.HasValue && HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = int.Parse(HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(n => n.Type == "UserId").Value);
                var eduGroup = _eduGroupService.CreateEduGroupDefault(userId, entity);
                entity.DefaultGroupId = eduGroup.Id;
            }
        }
       
    }
}
