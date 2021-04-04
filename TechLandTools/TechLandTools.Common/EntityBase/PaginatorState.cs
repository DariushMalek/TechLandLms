using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandTools.Common.EntityBase
{
    public class PaginatorState
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int[] PageSizes { get; set; }
    }
}
