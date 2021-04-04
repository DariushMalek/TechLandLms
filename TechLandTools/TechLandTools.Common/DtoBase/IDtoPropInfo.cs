using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Common.DtoBase
{
    public interface IDtoPropInfo
    {
        bool IsDbColumn { get; set; }
        string Name { get; set; }
        Type DataType { get; set; }
        bool IsVisible { get; set; }
        string Title { get; set; }
        int Width { get; set; }
        bool IsImage { get; set; }

    }
}
