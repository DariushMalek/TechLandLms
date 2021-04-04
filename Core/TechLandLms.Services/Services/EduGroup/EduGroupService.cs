using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common;
using TechLandTools.Common.Data;
using TechLandTools.Common.TechLandLog;

namespace TechLandLms.Services
{
    public class EduGroupService : ServiceBase<EduGroup, LogInfo>, IEduGroupService
    {
        public EduGroupService(IAsyncRepository<EduGroup> entityRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, ITechLandLogger<LogInfo> techLandLogger) : base(entityRepository, httpContextAccessor, mapper, techLandLogger)
        {

        }

        public EduGroup CreateEduGroupDefault(int ownerId, Course entity)
        {
            var defaultEduGroup = new EduGroup()
            {
                OwnerId = ownerId,
                EduGroupTitle = entity.CourseTitle,
                MaxMemberCount = 10
            };
            var submitRes = DoSubmit(defaultEduGroup);
            if (submitRes.IsOk())
                return defaultEduGroup;
            else
                return null;
        }
    }
}
