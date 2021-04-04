using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.Annotations;
using TechLandTools.Common.DtoBase;

namespace TechLandLms.Model.Dto
{
    public class AppUserDto : BaseDto
    {
        [ColumnInfo(Title = "کد کاربر", Width = 100)]
        public int Id { get; set; }
        [ColumnInfo(Title = "نام کاربری")]
        public string UserName { get; set; }
        [ColumnInfo(Title = "ایمیل")]
        public string Email { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public string Pass { get; set; }
        [ColumnInfo(Title = "نام")]
        public string FirstName { get; set; }
        [ColumnInfo(Title = "نام خانوادگی")]
        public string LastName { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public string PhoneNumber { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public string Mobile { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public DateTime? DateOfBirth { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public DateTime? CreateDate { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public string PersonalCode { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public string UserAddress { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public bool? IsActive { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public bool? IsAdmin { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public string UserImage { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public string JobTitle { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public bool? EmailConfirmed { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public bool? MobileConfirmed { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public int? EducationDegreeId { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public int? GenderTypeId { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public int? CityId { get; set; }
        [ColumnInfo(IsVisible = false, Title = "")]
        public int? UserId { get; set; }
       
    }
}
