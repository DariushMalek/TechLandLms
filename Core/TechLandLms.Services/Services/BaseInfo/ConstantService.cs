using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using TechLandLms.Core.Entities;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common;
using TechLandTools.Common.Data;
using TechLandTools.Common.TechLandLog;

namespace TechLandLms.Services
{
    public class ConstantService : ServiceBase<Constant, LogInfo>, IConstantService
    {
        public ConstantService(IAsyncRepository<Constant> entityRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, ITechLandLogger<LogInfo> techLandLogger) : base(entityRepository, httpContextAccessor, mapper, techLandLogger)
        {

        }

        public IEnumerable<Constant> GetConstanListByType(string constantType)
        {
            var constant = EntityRepository.GetByCriteria(n=> n.ConstantType == constantType).ToList();
            return constant;
        }
    }
}
