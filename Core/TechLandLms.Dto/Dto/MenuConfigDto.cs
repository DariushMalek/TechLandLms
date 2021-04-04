using System;
using System.Collections.Generic;
using System.Text;
using TechLandTools.Common.DtoBase;

namespace TechLandLms.Model.Dto
{
    public class MenuConfigDto:BaseDto
    {
		public IEnumerable<MenuItem> Items { get; set; }
	}
	public class MenuItem
    {
		public int MenuId { get; set; }
		public string Title { get; set; }
		public bool Root { get; set; }
		public string Icon { get; set; }
		public string Page { get; set; }
		public string Translate { get; set; }
		public string Bullet { get; set; }
		public string Permission { get; set; }
		public string Alignment { get; set; }
		public string Toggle { get; set; }
		public string Section { get; set; }
		public string MenuName { get; set; }
		public string Svg { get; set; }
		public IEnumerable<MenuItem> Submenu { get; set; }
	}
}
