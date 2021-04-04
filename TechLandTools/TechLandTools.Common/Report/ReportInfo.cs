using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Common.Report
{
    public class ReportInfo : IReportInfo
    {
        public ReportInfo()
        {
            Type = "pdf";
        }
        public IEnumerable<StReportParameter> Parameters;
        public string Report { get; set; }
        public string Type { get; set; }
        public string Connection { get; set; }
        IEnumerable<IReportParameter> IReportInfo.Parameters
        { get => Parameters; set => Parameters = (IEnumerable<StReportParameter>)value; }
    }
}
