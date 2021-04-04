using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TechLandTools.Web
{
    public class IdentityHelper<TUser>
        where TUser: IdentityUser
    {
        public static async Task CreateRole(IServiceProvider serviceProvider, string roleName = "Admin")
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //Adding Addmin Role  
            var roleCheck = await roleManager.RoleExistsAsync(roleName);
            if (!roleCheck)
            {
                //create the roles and seed them to the database  
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

        }
        public static async Task CreateUser(IServiceProvider serviceProvider, string userName, string email, string password, string role = "Admin")
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<TUser>>();
            var currentUser = await userManager.FindByEmailAsync(email);
            if (currentUser == null)
            {
                var user = (TUser)Activator.CreateInstance(typeof(TUser));

                user.Email = email;
                user.UserName = userName;
                
                userManager.CreateAsync(user, password).Wait();
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
