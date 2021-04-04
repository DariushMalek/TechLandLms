using System.Collections.Generic;
using TechLandLms.Core.Entities;
using TechLandLms.Model.Dto;
using TechLandTools.Common;

namespace TechLandLms.Services.Interfaces
{
    public interface IMenuConfigService : IServiceBase<MenuConfig, LogInfo>
    {
        MenuConfigDto GetMenuConfigViewModel(string userName);
    }
}
