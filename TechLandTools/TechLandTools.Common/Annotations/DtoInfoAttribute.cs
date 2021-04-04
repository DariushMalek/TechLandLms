using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.DtoBase;

namespace TechLandTools.Common.Annotations
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class DtoInfoAttribute : Attribute, IDtoInfo
    {
        public string TableName { get ; set; }
    }
}
