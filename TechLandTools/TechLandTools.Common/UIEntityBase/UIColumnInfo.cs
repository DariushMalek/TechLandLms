using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandTools.Common.UIEntityBase
{
    public class UIColumnInfo
    {
        public string ColumnTitle { get; set; }
        public string ColumnName { get; set; }
        public bool IsVisible { get; set; }
        public int? Width{ get; set; }
        public bool IsImage { get; set; }
    }
}
