using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Dto.Models;
using TechLandLms.Model.Models;

namespace TechLandLms.Web.Profiles.CourseProfile
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseViewModel, Course>()
                  .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
                  .ForMember(x => x.CourseTitle, o => o.MapFrom(m => m.CourseTitle))
                  .ForMember(x => x.SubjectText, o => o.MapFrom(m => m.SubjectText))
                  .ForMember(x => x.Prerequisites, o => o.MapFrom(m => m.Prerequisites))
                  .ForMember(x => x.Topics, o => o.MapFrom(m => m.Topics))
                  .ForMember(x => x.DefaultGroupId, o => o.MapFrom(m => m.DefaultGroupId))
                  .ForMember(x => x.PaymentTypeId, o => o.MapFrom(m => m.PaymentTypeId))
                  .ForMember(x => x.StartDate, o => o.MapFrom(m => m.StartDate))
                  .ForMember(x => x.EndDate, o => o.MapFrom(m => m.EndDate))
                  .ForMember(x => x.UserId, o => o.MapFrom(m => m.UserId))
                  .ForMember(x => x.CreateDate, o => o.MapFrom(m => m.CreateDate))
                  .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
                  .ForMember(x => x.AudiencesDes, o => o.MapFrom(m => m.AudiencesDes))
                  .ForMember(x => x.AttendanceCost, o => o.MapFrom(m => m.AttendanceCost))
                  .ForMember(x => x.IsActive, o => o.MapFrom(m => m.IsActive))
                  .ForMember(x => x.OnlineCost, o => o.MapFrom(m => m.OnlineCost))
                  .ForMember(x => x.CompleteIntroduction, o => o.MapFrom(m => m.CompleteIntroduction))
                  .ForMember(x => x.Introduction, o => o.MapFrom(m => m.Introduction));
        }

    }
}
