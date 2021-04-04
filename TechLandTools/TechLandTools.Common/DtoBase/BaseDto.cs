using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.Annotations;
using TechLandTools.Common.UIEntityBase;

namespace TechLandTools.Common.DtoBase
{
    public class BaseDto: IBaseDto 
    {
        [ColumnInfo(IsDbColumn = false,IsVisible = false)]
        public object this[string name] => this.GetType().GetProperty(name).GetValue(this, null);

        public static IEnumerable<IDtoPropInfo> GetModelPropsInfo<TDto>()
            where TDto : BaseDto, new()
        {
            return DtoPropInfoManager.GetPropsInfo(typeof(TDto));
        }

        public static string GetDbColumnsString<TDto>()
            where TDto : BaseDto, new()
        {
            var result = string.Join(", ", GetModelPropsInfo<TDto>().Where(n => n.IsDbColumn).Select(n => n.Name).ToList());
            return result;
        }

        public static UIEntityPropsInfo GetEntityPropsInfo<TDto>()
            where TDto : BaseDto, new()
        {
            var columnInfo = BaseDto.GetModelPropsInfo<TDto>().Select(n=>new UIColumnInfo
            {
                ColumnName = n.Name,
                ColumnTitle = n.Title,
                IsVisible = n.IsVisible,
                Width = n.Width,
                IsImage=n.IsImage
            });
            var result = new UIEntityPropsInfo();
            result.ColumnInfoList = columnInfo;
            return result;
        }

        public string GetTableName()
        {
            var attr = this.GetType().GetCustomAttributes(typeof(DtoInfoAttribute), true).FirstOrDefault() as IDtoInfo;
            return attr?.TableName;
        }
    }
}
