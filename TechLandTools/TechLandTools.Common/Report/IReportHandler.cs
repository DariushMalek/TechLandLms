using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TechLandTools.Common.Report
{
    public interface IReportHandler
    {
        T GetReport<T>(IReportInfo model);
        //string GetReportString(Stream stream);
    }
}
