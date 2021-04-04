using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Web.ModelHelper
{
    public class ModelPropInfo : IModelPropInfo
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public bool IsVisibleInGrid { get; set; }
        public bool IsLookUp { get; set; }
        public Type LookUpType { get; set; }
        public Type DataType { get; set; }
        public string LookUpName { get; set; }
        public bool IsShDate { get; set; }
        public string LookupDisplayColumnName { get; set; }
    }
}
