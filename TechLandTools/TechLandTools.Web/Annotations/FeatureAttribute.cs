using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using TechLandTools.Web.ModelHelper;

namespace TechLandTools.Web.Annotations
{
    public class FeatureAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string FeatureName { get; set; }
        public FeatureAttribute(string featureName)
        {
            FeatureName = featureName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
