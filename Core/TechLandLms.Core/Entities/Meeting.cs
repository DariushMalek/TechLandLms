using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class Meeting : BaseEntity
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public DateTime? MeetingDate { get; set; }
        public int? MeetingCapacity { get; set; }
        public int? MeetingTypeId { get; set; }
        public int? Duration { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        [ForeignKey("UserId")]
        public AppUser AppUserEntity { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher TeacherEntity { get; set; }
        [ForeignKey("CourseId")]
        public Course CourseEntity { get; set; }
        [ForeignKey("MeetingTypeId")]
        public Constant ConstantEntity { get; set; }
        public ICollection<EduGroupMeeting> EduGroupMeetingList { get; set; }

    }
}
