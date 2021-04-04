using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandTools.Common.DtoBase
{
    public static class BaseDtoExtenssion
    {
        public static IEnumerable<IDtoPropInfo> GetModelPropsInfo(this BaseDto baseDto)
        {
            var modelType = baseDto.GetType();
            return DtoPropInfoManager.GetPropsInfo(modelType);
        }

        public static string GetDbColumnsString(this BaseDto baseDto)
        {
            var result = string.Join(",", baseDto.GetModelPropsInfo().Where(n => n.IsDbColumn).Select(n => n.Name).ToList());
            return result;
        }
    }
}
