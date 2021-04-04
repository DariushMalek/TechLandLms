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
    public class RelatedQuestionService :ServiceBase<RelatedQuestion, LogInfo>, IRelatedQuestionService
    {
        public RelatedQuestionService(IAsyncRepository<RelatedQuestion> entityRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, ITechLandLogger<LogInfo> techLandLogger) : base(entityRepository, httpContextAccessor, mapper, techLandLogger)
        {

        }
    }
}
