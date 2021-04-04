using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandTools.Common.Report
{
   public interface IReportParameter
    {
        string Key { get; set; }
        string Value { get; set; }
        string Type { get; set; }
    }
}
