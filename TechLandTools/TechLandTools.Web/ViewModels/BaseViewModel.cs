
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using TechLandTools.Web.Annotations;
using TechLandTools.Web.ModelHelper;

namespace TechLandTools.Web.ViewModels
{

    public class BaseViewModel
    {
        public int Id { get; set; }

        public object this[string name] => this.GetType().GetProperty(name).GetValue(this, null);


        public static IEnumerable<IModelPropInfo> GetModelPropsInfo(Type modelType)
        {
            return EntityPropInfoManager.GetPropsInfo(modelType);
        }

        public static string GetPageTitle(Type modelType)
        {
            return modelType.CustomAttributes.FirstOrDefault(n => n.AttributeType.Name == "DisplayAttribute")?.NamedArguments.FirstOrDefault(n => n.MemberName == "Description").TypedValue.Value?.ToString();
        }

        public static string GetIndexActionNameFromVM(Type modelType)
        {
            return GetActionStringFromVM(modelType, "Index");
        }
        public static string GetCreateActionNameFromVM(Type modelType)
        {
            return GetActionStringFromVM(modelType, "Create");
        }

        public static string GetEditActionNameFromVM(Type modelType)
        {
            return GetActionStringFromVM(modelType, "Edit");
        }

        public static string GetDeleteActionNameFromVM(Type modelType)
        {
            return GetActionStringFromVM(modelType, "Delete");
        }

        public static string GetDetailActionNameFromVM(Type modelType)
        {
            return GetActionStringFromVM(modelType, "Detail");
        }

        public static string GetActionStringFromVM(Type modelType, string action)
        {
            var methodName = modelType.Name.Replace("ViewModel", action);
            return modelType.GetMethods().Any(n => n.Name == methodName) ? methodName : action;
        }
        public object GetLookupDisplayValue(string name)
        {
            var displayAttribute = GetModelPropsInfo(this.GetType()).First(p => p.Name == name);
            var navProperty = this.GetType().GetProperties().First(p =>
            {
                var attribute = p.GetCustomAttributes<NavAttribute>().FirstOrDefault(a => a.ThisKey == name && p.PropertyType == displayAttribute.LookUpType);
                return attribute != null;
            }
            );
            var navObject = navProperty.GetValue(this, null);
            var displayColumnName = displayAttribute.LookupDisplayColumnName;
            return (navObject as BaseViewModel)[displayColumnName];

        }
    }
}
