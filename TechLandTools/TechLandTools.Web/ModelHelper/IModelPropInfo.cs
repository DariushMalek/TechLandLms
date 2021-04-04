using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Web.ModelHelper
{
    public interface IModelPropInfo
    {
        string Title { get; set; }
        string Name { get; set; }
        bool IsVisibleInGrid { get; set; }
        bool IsLookUp { get; set; }
        Type LookUpType { get; set; }
        Type DataType { get; set; }
        string LookUpName { get; set; }
        bool IsShDate { get; set; }
        string LookupDisplayColumnName { get; set; }
    }
}
