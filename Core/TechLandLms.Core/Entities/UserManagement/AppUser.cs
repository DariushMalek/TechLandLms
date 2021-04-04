using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Mobile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreateDate { get; set; }
        public string PersonalCode { get; set; }
        public string UserAddress { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAdmin { get; set; }
        public string UserImage { get; set; }
        public string JobTitle { get; set; }
        public bool? EmailConfirmed { get; set; }
        public bool? MobileConfirmed { get; set; }
        public int? EducationDegreeId { get; set; }
        public int? GenderTypeId { get; set; }
        public int? CityId { get; set; }
        public int? UserId { get; set; }
        //[ForeignKey("EducationDegreeId")]
        //public Constant EducationDegreeEntity { get; set; }
        //[ForeignKey("GenderTypeId")]
        //public Constant GenderTypeEntity { get; set; }
        //[ForeignKey("CityId")]
        //public City CityEntity { get; set; }
        //public ICollection<Constant> ConstantList { get; set; }
        //public ICollection<EduGroup> UserEduGroupList { get; set; }
        //public ICollection<EduGroup> OwnerList { get; set; }
        //public ICollection<Course> CourseList { get; set; }
        //public ICollection<EduGroupCourse> EduGroupCourseList { get; set; }
        //public ICollection<EduGroupMember> EduGroupMemberList { get; set; }
        //public ICollection<EduGroupMember> UserEduGroupMemberList { get; set; }
        //public ICollection<Teacher> TeacherList { get; set; }
        //public ICollection<Teacher> UserTeacherList { get; set; }
        //public ICollection<Meeting> MeetingList { get; set; }
        //public ICollection<Meeting> UserMeetingList { get; set; }
        //public ICollection<EduGroupMeeting> EduGroupMeetingList { get; set; }
        //public ICollection<RelatedProduct> RelatedProductList { get; set; }
        //public ICollection<RelatedQuestion> RelatedQuestionList { get; set; }
        public ICollection<UserRole> UserRoleList { get; set; }
    }
}
