using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class RoleFeature : BaseEntity
    {
        public int FeatureId { get; set; }
        public int RoleId { get; set; }
        public bool CanInsert { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanExecute { get; set; }
        public bool CanRead { get; set; }
        [ForeignKey("FeatureId")]
        public Feature FeatureEntity { get; set; }
        [ForeignKey("RoleId")]
        public Role RoleEntity { get; set; }

    }
}
