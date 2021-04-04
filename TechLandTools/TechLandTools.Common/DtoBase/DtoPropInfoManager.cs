using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TechLandTools.Common.Annotations;
using TechLandTools.Common.EntityBase;
using TechLandTools.Common.Extension;

namespace TechLandTools.Common.DtoBase
{
    public class DtoPropInfoManager
    {
        public static IEnumerable<IDtoPropInfo> GetPropsInfo(Type modelType)
        {
            
            var props = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead);
            var propsAttInfo = props.Select(p => new
            {
                p.PropertyType,
                p.Name,
                CustomAttributes = p.CustomAttributes.Where(c => c.AttributeType == typeof(ColumnInfoAttribute)).Select(n => n.NamedArguments).FirstOrDefault()
            }
                ).ToList();

            var propsInfo = propsAttInfo.Select(n =>
            {
                var propDisplayInfo = GetPropDisplayInfoFromCustomAtt(n.CustomAttributes);
                propDisplayInfo.Name = n.Name;
                propDisplayInfo.DataType = n.PropertyType;
                propDisplayInfo.Title ??= n.Name;
                return propDisplayInfo;

            }).ToList();

            return propsInfo;
        }

        public static IDtoPropInfo GetPropDisplayInfoFromCustomAtt(IEnumerable<CustomAttributeNamedArgument> customAtt)
        {
            var att = new DtoPropInfo();
            if (customAtt != null)
            {
                att.IsDbColumn = (bool?)customAtt.FirstOrDefault(m => m.MemberName == "IsDbColumn").TypedValue.Value ?? true;
                att.IsVisible = (bool?)customAtt.FirstOrDefault(m => m.MemberName == "IsVisible").TypedValue.Value ?? true;
                att.Title = customAtt.FirstOrDefault(m => m.MemberName == "Title").TypedValue.Value?.ToString();
                att.Width = (int?)customAtt.FirstOrDefault(m => m.MemberName == "Width").TypedValue.Value ?? 0;
                att.IsImage = (bool?)customAtt.FirstOrDefault(m => m.MemberName == "IsImage").TypedValue.Value ?? false;
            }
            return att;
        }
    }
}
