using MD.PersianDateTime.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.Annotations;
using TechLandTools.Common.DtoBase;

namespace TechLandLms.Model.Dto
{
    public class CourseDto : BaseDto
    {
        [ColumnInfo(Title = "کد دوره", Width = 100)]
        public int Id { get; set; }
        [ColumnInfo(Title = "عنوان دوره")]
        public string CourseTitle { get; set; }
        [ColumnInfo(Title = "موضوع")]
        public string SubjectText { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public bool IsActive { get; set; }
        [ColumnInfo(Title = "تعداد جلسات")]
        public int? NumberOfSessions { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public DateTime? StartDate { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public DateTime? EndDate { get; set; }
        [ColumnInfo(Title = "سرفصل ها")]
        public string CompleteIntroduction { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public decimal? AttendanceCost { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public int? PaymentTypeId { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public string Introduction { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public string Prerequisites { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public string AudiencesDes { get; set; }
        [ColumnInfo( IsVisible = false, Title = "")]
        public string Topics { get; set; }
        [ColumnInfo( Title = "هزینه دوره حضوری")]
        public decimal? OnlineCost { get; set; }
        [ColumnInfo(IsVisible =false, Title = "")]
        public string Description { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public int DefaultGroupId { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public int? UserId { get; set; }
        [ColumnInfo(IsDbColumn = false, Title = "تاریخ شروع")]
        public string StartPersianDate
        {
            get
            {
                return new PersianDateTime(StartDate).ToString();
            }
        }
        [ColumnInfo(IsDbColumn = false, Title = "تاریخ پایان")]
        public string EndPersianDate
        {
            get
            {
                return new PersianDateTime(EndDate).ToString();
            }
        }
    }
}
