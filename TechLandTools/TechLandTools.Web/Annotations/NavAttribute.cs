using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Web.Annotations
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class NavAttribute : Attribute
    {
        public string ThisKey { get; set; }
        public string OtherKey { get; set; }
    }
}
