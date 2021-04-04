using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.Annotations;
using TechLandTools.Common.DtoBase;

namespace TechLandLms.Model.Dto
{
    public class RoleFeatureNode
    {
        public string FeatureName { get; set; }
        public string FeatureTitle { get; set; }
        public int? ParentFeatureId { get; set; }
        public int FeatureId { get; set; }
        public int RoleId { get; set; }
        public bool CanInsert { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanExecute { get; set; }
        public bool CanRead { get; set; }
        public IList<RoleFeatureNode> SubFeatures { get; set; }
    }
}
