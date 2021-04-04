using System;
using System.Collections.Generic;
using System.Text;
using TechLandTools.Web.ViewModels;

namespace TechLandTools.Web.ModelHelper
{
    public static class MetaObjectExtensions
    {
        public static IEnumerable<IModelPropInfo> GetModelPropsInfo(this BaseViewModel modelType)
        {
            return EntityPropInfoManager.GetPropsInfo(modelType.GetType());
        }

        public static IEnumerable<IModelPropInfo> GetModelPropsInfo(Type modelType)
        {
            return EntityPropInfoManager.GetPropsInfo(modelType);
        }
    }
}
