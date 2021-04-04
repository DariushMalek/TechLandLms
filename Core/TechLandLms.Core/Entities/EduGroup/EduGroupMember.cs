using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class EduGroupMember : BaseEntity
    {
        public bool? IsActive { get; set; }
        public int MemberId { get; set; }
        public int EduGroupId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        [ForeignKey("MemberId")]
        public AppUser MemberEntity { get; set; }
        [ForeignKey("EduGroupId")]
        public EduGroup EduGroupEntity { get; set; }
        [ForeignKey("UserId")]
        public AppUser AppUserEntity { get; set; }

    }
}
