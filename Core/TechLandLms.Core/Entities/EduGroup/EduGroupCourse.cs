using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class EduGroupCourse : BaseEntity
    {
        public bool? IsActive { get; set; }
        public int CourseId { get; set; }
        public int EduGroupId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        [ForeignKey("CourseId")]
        public Course CourseEntity { get; set; }
        [ForeignKey("EduGroupId")]
        public EduGroup EduGroupEntity { get; set; }
        [ForeignKey("UserId")]
        public AppUser AppUserEntity { get; set; }
    }
}
