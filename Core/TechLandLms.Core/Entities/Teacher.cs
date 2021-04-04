using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class Teacher : BaseEntity
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        [ForeignKey("CourseId")]
        public Course CourseEntity { get; set; }
        [ForeignKey("TeacherId")]
        public AppUser TeacherEntity { get; set; }
        [ForeignKey("UserId")]
        public AppUser AppUserEntity { get; set; }

    }
}
