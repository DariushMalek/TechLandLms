using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Model.Dto;
using TechLandTools.Common;

namespace TechLandLms.Services.Interfaces
{
    public interface IRoleFeatureService : IServiceBase<RoleFeature, LogInfo>
    {
        IEnumerable<RoleFeatureNode> GetFeatureListWithRoleStatus(int roleId);
    }
}
