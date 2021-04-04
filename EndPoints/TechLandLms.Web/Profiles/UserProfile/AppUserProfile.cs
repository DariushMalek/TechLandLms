using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Model.Dto;
using TechLandLms.Model.Models;

namespace TechLandLms.Web.Profiles.UserProfiles
{
    public class AppUserProfile: Profile
    {
        public AppUserProfile()
        {
            CreateMap<SignUpViewModel, AppUser>()
                    .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
                  .ForMember(x => x.UserName, o => o.MapFrom(m => m.UserName))
                  .ForMember(x => x.Email, o => o.MapFrom(m => m.Email))
                  .ForMember(x => x.FirstName, o => o.MapFrom(m => m.FirstName))
                  .ForMember(x => x.LastName, o => o.MapFrom(m => m.LastName))
                  .ForMember(x => x.PhoneNumber, o => o.MapFrom(m => m.PhoneNumber))
                  .ForMember(x => x.Pass, o => o.MapFrom(m => m.Pass));


            CreateMap<AppUserDto, AppUser>()
                    .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
                  .ForMember(x => x.UserName, o => o.MapFrom(m => m.UserName))
                  .ForMember(x => x.Email, o => o.MapFrom(m => m.Email))
                  .ForMember(x => x.FirstName, o => o.MapFrom(m => m.FirstName))
                  .ForMember(x => x.LastName, o => o.MapFrom(m => m.LastName))
                  .ForMember(x => x.PhoneNumber, o => o.MapFrom(m => m.PhoneNumber))
                  .ForMember(x => x.Mobile, o => o.MapFrom(m => m.Mobile))
                  .ForMember(x => x.CityId, o => o.MapFrom(m => m.CityId))
                  .ForMember(x => x.DateOfBirth, o => o.MapFrom(m => m.DateOfBirth))
                  .ForMember(x => x.EducationDegreeId, o => o.MapFrom(m => m.EducationDegreeId))
                  .ForMember(x => x.GenderTypeId, o => o.MapFrom(m => m.GenderTypeId))
                  .ForMember(x => x.IsActive, o => o.MapFrom(m => m.IsActive))
                  .ForMember(x => x.IsAdmin, o => o.MapFrom(m => m.IsAdmin))
                  .ForMember(x => x.PersonalCode, o => o.MapFrom(m => m.PersonalCode))
                  .ForMember(x => x.UserImage, o => o.MapFrom(m => m.UserName));


            CreateMap<AppUser, AppUserDto>()
                   .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
                 .ForMember(x => x.UserName, o => o.MapFrom(m => m.UserName))
                 .ForMember(x => x.Email, o => o.MapFrom(m => m.Email))
                 .ForMember(x => x.FirstName, o => o.MapFrom(m => m.FirstName))
                 .ForMember(x => x.LastName, o => o.MapFrom(m => m.LastName))
                 .ForMember(x => x.PhoneNumber, o => o.MapFrom(m => m.PhoneNumber))
                 .ForMember(x => x.Mobile, o => o.MapFrom(m => m.Mobile))
                 .ForMember(x => x.CityId, o => o.MapFrom(m => m.CityId))
                 .ForMember(x => x.DateOfBirth, o => o.MapFrom(m => m.DateOfBirth))
                 .ForMember(x => x.EducationDegreeId, o => o.MapFrom(m => m.EducationDegreeId))
                 .ForMember(x => x.GenderTypeId, o => o.MapFrom(m => m.GenderTypeId))
                 .ForMember(x => x.IsActive, o => o.MapFrom(m => m.IsActive))
                 .ForMember(x => x.IsAdmin, o => o.MapFrom(m => m.IsAdmin))
                 .ForMember(x => x.PersonalCode, o => o.MapFrom(m => m.PersonalCode))
                 .ForMember(x => x.UserImage, o => o.MapFrom(m => m.UserName));
        }

}
}
