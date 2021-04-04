using System;
using System.Collections.Generic;
using System.Text;
using TechLandTools.Web.ModelHelper;

namespace TechLandTools.Web.Annotations
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class DisplayInfoAttribute:Attribute
    {
        public DisplayInfoAttribute()
        {
            IsVisibleInGrid = false;
            IsLookUp = false;
            IsShDate = false;
        }
        public string Title { get; set; }
        public bool IsVisibleInGrid { get; set; }
        public bool IsLookUp { get; set; }
        public Type LookUpType { get ; set ; }
        public string LookUpName { get; set; }
        public bool IsShDate { get; set; }
        public string LookupDisplayColumn { get; set; }
    }
}
