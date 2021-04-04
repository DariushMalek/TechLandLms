using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TechLandLms.Core.Entities;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common;
using TechLandTools.Common.TechLandLog;
using TechLandTools.Common.Data;
using TechLandLms.Model.Dto;

namespace TechLandLms.Services
{
    public class MenuConfigService : ServiceBase<MenuConfig, LogInfo>, IMenuConfigService
    {
        public MenuConfigService(IAsyncRepository<MenuConfig> entityRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, ITechLandLogger<LogInfo> techLandLogger) : base(entityRepository, httpContextAccessor, mapper, techLandLogger)
        {
        }

        public MenuConfigDto GetMenuConfigViewModel(string userName)
        {
            var result = new MenuConfigDto();
            result.Items = GetMenus(userName);
            return result;
        }

        public IEnumerable<MenuItem> GetMenus(string userName)
        {
            var menuConfigList = GetMenusByPermission(userName).OrderBy(o=>o.MenuOrder).ToList();
            var items = Mapper.Map<IEnumerable<MenuItem>>(menuConfigList.Where(n => n.IsRoot));
            foreach (var root in items)
            {
                FetchSubMenus(root, menuConfigList);
            }
            return items;
        }

        private void FetchSubMenus(MenuItem menuItem,IEnumerable<MenuConfig> menuConfigs)
        {
            var menuItemList = menuConfigs.Where(n => n.ParentMenuId == menuItem.MenuId);
            menuItem.Submenu = null;
            if (menuItemList.Any())
            {
                menuItem.Submenu = Mapper.Map<IEnumerable<MenuItem>>(menuItemList);
                foreach(var subMenuItem in menuItem.Submenu)
                {
                    FetchSubMenus(subMenuItem, menuConfigs);
                }

            } 
        }

        private IEnumerable<MenuConfig> GetMenusByPermission(string userName)
        {
            var result = EntityRepository.GetByQuery($"select * from dbo.GetMenuByPersmission('{userName}')").Include(n => n.SubMenu).ToList();
            return result;
        }
    }
}
