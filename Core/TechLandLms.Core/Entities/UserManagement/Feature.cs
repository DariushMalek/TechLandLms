
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class Feature : BaseEntity
    {
        public string FeatureName { get; set; }
        public string AppName { get; set; }
        public string FeatureType { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public int? ParentFeatureId { get; set; }
        public virtual Feature ParentEntity { get; set; }
        public ICollection<RoleFeature> RoleFeatureList { get; set; }
        public ICollection<Feature> SubFeatureList { get; set; }
    }
}
