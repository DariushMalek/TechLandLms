using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
        public string RoleTitle { get; set; }
        public ICollection<RoleFeature> RoleFeatureList { get; set; }
        public ICollection<UserRole> UserRoleList { get; set; }
    }
}
