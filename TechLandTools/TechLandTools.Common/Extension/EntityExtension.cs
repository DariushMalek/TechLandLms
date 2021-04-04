using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TechLandTools.Common.Extension
{
    public static class EntityExtension
    {
        public static T Load<T>(this T entity)
            where T:BaseEntity
        {
            //    entity.enti
            //    context.Entry(blog)
            //.Collection(b => b.Posts)
            //.Load();
            return entity;
        }
    }
}
