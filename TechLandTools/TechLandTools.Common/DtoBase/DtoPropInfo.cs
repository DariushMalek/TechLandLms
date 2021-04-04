using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Common.DtoBase
{
    public class DtoPropInfo : IDtoPropInfo
    {
        public DtoPropInfo()
        {
            IsDbColumn = true;
            IsVisible = true;
        }
        public bool IsDbColumn { get; set; }
        public string Name { get; set ; }
        public Type DataType { get; set ; }
        public bool IsVisible { get; set; }
        public string Title { get; set; }
        public int Width { get; set ; }
        public bool IsImage { get; set; }
    }
}
