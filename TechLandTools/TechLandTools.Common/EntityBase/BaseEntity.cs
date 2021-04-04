using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using TechLandTools.Common.Helper;

namespace TechLandTools.Common
{
    public class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }

        public void Merge(object entity)
        {
            var thisProps = this.GetType().GetProperties();
            foreach (var prop in thisProps)
            {
                if (entity.GetType().GetProperty(prop.Name) != null)
                {
                    var value = entity.GetType().GetProperty(prop.Name).GetValue(entity);
                    this.GetType().GetProperty(prop.Name).SetValue(this, value);
                }
            }
        }

        public static T Merge<T>(T mainObj, object secObj)
            where T : class, new()
        {
            T result = mainObj;
            var thisProps = typeof(T).GetProperties();
            foreach (var prop in thisProps)
            {
                if (secObj.GetType().GetProperty(prop.Name) != null)
                {
                    var value = secObj.GetType().GetProperty(prop.Name).GetValue(secObj);
                    typeof(T).GetProperty(prop.Name).SetValue(result, value);
                }
            }

            return result;
        }

        public static T Merge<T>(object secObj)
            where T : class, new()
        {
            T result = new T();

            return Merge(result, secObj);
        }

        //public IdentityDbContext GetDbContext()
        //{
        //    return DbContextHelper.GetDbContextFromEntity(this);

        //}
    }
}
