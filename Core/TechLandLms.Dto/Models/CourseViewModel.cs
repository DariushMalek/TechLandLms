using MD.PersianDateTime.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandLms.Dto.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
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
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DefaultGroupId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string StartPersianDate
        {
            get
            {
                return new PersianDateTime(StartDate).ToString();
            }
        }
        public string EndPersianDate
        {
            get
            {
                return new PersianDateTime(EndDate).ToString();
            }
        }


    }
}
