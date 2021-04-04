using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandTools.Common.DtoBase
{
    public class TableResponseModel<TDto>
        where TDto : BaseDto, new()
    {
        public IEnumerable<TDto> Items { get; set; }
        public int Total { get; set; }
        public IEnumerable<ColumnInfo> ColumnInfoList { get; set; }
    }

    public class ColumnInfo
    {
        public string ColumnName { get; set; }
        public bool IsVisible { get; set; }
    }
}
