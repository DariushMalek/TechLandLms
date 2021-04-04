using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Model.Dto;

namespace TechLandLms.Web.Profiles.UserProfile
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            //CreateMap<Feature, RoleFeatureDto>()
            //        .ForMember(x => x.FeatureId, o => o.MapFrom(m => m.Id))
            //      .ForMember(x => x.FeatureName, o => o.MapFrom(m => m.FeatureName))
            //      .ForMember(x => x.FeatureTitle, o => o.MapFrom(m => m.Title))
            //      .ForMember(x => x.ParentFeatureId, o => o.MapFrom(m => m.ParentFeatureId));
        }

    }
}
