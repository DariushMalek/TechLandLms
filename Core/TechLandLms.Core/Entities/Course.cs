using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class Course : BaseEntity
    {
        public string CourseTitle { get; set; }
        public string SubjectText { get; set; }
        public string Introduction { get; set; }
        public string Prerequisites { get; set; }
        public string AudiencesDes { get; set; }
        public string Topics { get; set; }
        public string CompleteIntroduction { get; set; }
        public decimal? OnlineCost { get; set; }
        public decimal? AttendanceCost { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? NumberOfSessions { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? DefaultGroupId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        [ForeignKey("UserId")]
        public AppUser AppUserEntity { get; set; }
        [ForeignKey("PaymentTypeId")]
        public Constant PaymentTypeEntity { get; set; }
        [ForeignKey("DefaultGroupId")]
        public EduGroup DefaultGroupEntity { get; set; }
        public ICollection<EduGroupCourse> EduGroupCourseList { get; set; }
        public ICollection<Teacher> TeacherList { get; set; }
        public ICollection<Meeting> MeetingList { get; set; }
        public ICollection<RelatedProduct> RelatedProductList { get; set; }
        public ICollection<RelatedQuestion> RelatedQuestionList { get; set; }
    }
}
