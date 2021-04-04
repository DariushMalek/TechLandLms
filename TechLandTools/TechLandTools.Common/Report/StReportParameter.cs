using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Common.Report
{
    public class StReportParameter:IReportParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
