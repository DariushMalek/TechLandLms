using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.DtoBase;

namespace TechLandTools.Common.Annotations
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class ColumnInfoAttribute : Attribute, IDtoPropInfo
    {
        public ColumnInfoAttribute()
        {
            IsDbColumn = true;
            IsVisible = true;
        }
        public bool IsDbColumn { get; set; }
        public string Name { get; set; }
        public Type DataType { get; set; }
        public bool IsVisible { get; set; }
        public string Title { get; set; }
        public int Width { get; set; }
        public bool IsImage { get; set; }
    }
}
