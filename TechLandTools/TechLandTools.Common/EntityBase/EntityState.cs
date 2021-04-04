using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechLandTools.Common.DtoBase;
using TechLandTools.Common.Extension;
using TechLandTools.Common.Helper;

namespace TechLandTools.Common.EntityBase
{
    public class EntityState
    {
        public JsonElement Filter { get; set; }
        public PaginatorState Paginator { get; set; }
        public SortState Sorting { get; set; }
        public string SearchTerm { get; set; }
        public int? EntityId { get; set; }

        public string GetCriteriaAsSql<TDto>()
            where TDto : BaseDto, new()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                var typeProps = BaseDto.GetModelPropsInfo<TDto>().Where(n => n.IsDbColumn);
                var criteria = string.Join(" or ", typeProps.Where(n => !n.DataType.IsNumericType())
                                                                .Select(n => n.Name + " like " + $"''%{SearchTerm}%''").ToList());

                if (SearchTerm.IsNumeric())
                {
                    var criteria2 = string.Join(" or ", typeProps.Where(n => n.DataType.IsNumericType())
                                                                .Select(n => n.Name + " = " + $"{SearchTerm}").ToList());
                    if (!string.IsNullOrEmpty(criteria2))
                    {
                        criteria += " or " + criteria2;
                    }
                }
                return " where " + criteria;
            }
            return "";
        }
        public string GetSortingAsSql<TDto>()
            where TDto : BaseDto, new()
        {
            if (Sorting != null)
            {
                return $"order by {Sorting.Column} {Sorting.Direction}";
            }
            return "order by Id";
        }
        public string GetPagingAsSql<TDto>()
            where TDto : BaseDto, new()
        {
            if (Paginator != null)
            {
                var fromOffset = (Paginator.Page - 1) * Paginator.PageSize;
                return $"OFFSET {fromOffset} ROWS FETCH NEXT {Paginator.PageSize} ROWS ONLY";
            }
            return "OFFSET 0 ROWS FETCH NEXT 200 ROWS ONLY";
        }
    }
}
