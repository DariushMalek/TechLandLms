using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TechLandTools.Web.Annotations;

namespace TechLandTools.Web.ModelHelper
{
    public class EntityPropInfoManager
    {
        public static IEnumerable<IModelPropInfo> GetPropsInfo(Type modelType)
        {
            
            var props = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead);
            var propsAttInfo = props.Select(p => new 
            {
                p.PropertyType,
                p.Name,
                CustomAttributes = p.CustomAttributes.Where(c => c.AttributeType == typeof(DisplayInfoAttribute)).Select(n => n.NamedArguments).FirstOrDefault()
            }
                ).ToList();

            var propsInfo = propsAttInfo.Select(n =>
            {
                var propDisplayInfo = GetPropDisplayInfoFromCustomAtt(n.CustomAttributes);
                propDisplayInfo.Name = n.Name;
                propDisplayInfo.DataType = n.PropertyType;
                return propDisplayInfo;

            }).ToList();

            return propsInfo;
        }

        public static IModelPropInfo GetPropDisplayInfoFromCustomAtt(IEnumerable<CustomAttributeNamedArgument> customAtt)
        {
            var att = new ModelPropInfo();
            if (customAtt != null)
            {
                var isLookUp = customAtt.FirstOrDefault(m => m.MemberName == "IsLookUp").TypedValue.Value;
                var isVisibleInGrid = customAtt.FirstOrDefault(m => m.MemberName == "IsVisibleInGrid").TypedValue.Value;
                var isShDate = customAtt.FirstOrDefault(m => m.MemberName == "IsShDate").TypedValue.Value;

                if (isLookUp != null)
                {
                    att.IsLookUp = (bool)isLookUp;
                }
                if (isVisibleInGrid != null)
                {
                    att.IsVisibleInGrid = (bool)isVisibleInGrid;
                }
                if (isShDate != null)
                {
                    att.IsShDate = (bool)isShDate;
                }
                att.Name = customAtt.FirstOrDefault(m => m.MemberName == "Name").TypedValue.Value?.ToString();
                att.Title = customAtt.FirstOrDefault(m => m.MemberName == "Title").TypedValue.Value?.ToString();
                att.LookUpType = (Type)customAtt.FirstOrDefault(m => m.MemberName == "LookUpType").TypedValue.Value;
                att.LookUpName = customAtt.FirstOrDefault(m => m.MemberName == "LookUpName").TypedValue.Value?.ToString();
                att.LookupDisplayColumnName = customAtt.FirstOrDefault(m => m.MemberName == "LookupDisplayColumn").TypedValue.Value?.ToString();
            }
            return att;
        }
    }
}
