using TechLandTools.Common;
using System.Collections.Generic;

namespace TechLandLms.Core.Entities
{
    public class MenuConfig : BaseEntity
    {
		public short? MenuType { get; set; }
		public string Title { get; set; }
		public bool IsRoot { get; set; }
		public string Icon { get; set; }
		public string PageRoute { get; set; }
		public string TranslateStr { get; set; }
		public string Bullet { get; set; }
		public string Permission { get; set; }
		public bool IsSection { get; set; }
		public int? ParentMenuId { get; set; }
		public string Alignment { get; set; }
		public string Toggle { get; set; }
		public string MenuName { get; set; }
		public short? MenuOrder { get; set; }
		public bool? IsActive { get; set; }
		public string Svg { get; set; }
		public MenuConfig ParentMenu { get; set; }
		public ICollection<MenuConfig> SubMenu { get; set; }
	}
}
