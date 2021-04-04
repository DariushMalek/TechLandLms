using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Model.Dto;

namespace TechLandLms.Web.Profiles.Base
{
    public class MenuConfigProfile : Profile
    {
        public MenuConfigProfile()
        {
            CreateMap<MenuConfig, MenuItem>()
                    .ForMember(x => x.MenuId, o => o.MapFrom(m => m.Id))
                  .ForMember(x => x.Title, o => o.MapFrom(m => !m.IsSection ? m.Title : null))
                  .ForMember(x => x.Root, o => o.MapFrom(m => m.IsRoot))
                  .ForMember(x => x.Icon, o => o.MapFrom(m => m.Icon))
                  .ForMember(x => x.Page, o => o.MapFrom(m => m.PageRoute))
                  .ForMember(x => x.Translate, o => o.MapFrom(m => m.TranslateStr))
                  .ForMember(x => x.Bullet, o => o.MapFrom(m => m.Bullet))
                  .ForMember(x => x.Permission, o => o.MapFrom(m => m.Permission))
                  .ForMember(x => x.Alignment, o => o.MapFrom(m => m.Alignment))
                  .ForMember(x => x.Toggle, o => o.MapFrom(m => m.Toggle))
                  .ForMember(x => x.Svg, o => o.MapFrom(m => m.Svg))
                  .ForMember(x => x.Section, o => o.MapFrom(m => m.IsSection ? m.Title : ""));

        }
    }
}
