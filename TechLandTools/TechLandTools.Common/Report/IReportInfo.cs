using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandTools.Common.Report
{
    
    public interface IReportInfo
    {
         string Report { get; set; }
        IEnumerable<IReportParameter> Parameters { get; set; }
         string Type { get; set; }
        string Connection { get; set; }

    }
}
