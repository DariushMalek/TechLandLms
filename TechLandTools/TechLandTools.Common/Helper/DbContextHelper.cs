using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Common.Helper
{
    public class DbContextHelper
    {
        public static IdentityDbContext GetDbContextFromEntity(object entity)
        {
            var field = entity.GetType().GetField("_entityWrapper");

            if (field == null)
                return null;

            var wrapper = field.GetValue(entity);
            var property = wrapper.GetType().GetProperty("Context");
            var context = (IdentityDbContext)property.GetValue(wrapper, null);

            return context;

            //var object_context = GetObjectContextFromEntity(entity);

            //if (object_context == null || object_context.TransactionHandler == null)
            //    return null;

            //return object_context.TransactionHandler.DbContext;
        }

        //private static ObjectContext GetObjectContextFromEntity(object entity)
        //{
        //    var field = entity.GetType().GetField("_entityWrapper");

        //    if (field == null)
        //        return null;

        //    var wrapper = field.GetValue(entity);
        //    var property = wrapper.GetType().GetProperty("Context");
        //    var context = (ObjectContext)property.GetValue(wrapper, null);

        //    return context;
        //}
    }
}
