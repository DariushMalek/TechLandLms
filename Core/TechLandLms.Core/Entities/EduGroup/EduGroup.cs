using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class EduGroup : BaseEntity
    {
        public string EduGroupTitle { get; set; }
        public int? MaxMemberCount { get; set; }
        public int OwnerId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        [ForeignKey("OwnerId")]
        public AppUser OwnerEntity { get; set; }
        [ForeignKey("UserId")]
        public AppUser AppUserEntity { get; set; }
        public ICollection<Course> CourseList { get; set; }
        public ICollection<EduGroupCourse> EduGroupCourseList { get; set; }
        public ICollection<EduGroupMember> EduGroupMemberList { get; set; }
        public ICollection<EduGroupMeeting> EduGroupMeetingList { get; set; }
    }
}
