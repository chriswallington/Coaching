using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coaching.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coaching.Helpers
{
    public static class SeedTestDatabaseExtensions
    {
        public static IApplicationBuilder SeedTestDatabase(this IApplicationBuilder app,
            IConfiguration configuration)
        {
            app.CreateApplicationRoles().Wait();
            app.CreateSystemApplicationUsers(configuration).Wait();
            return app;
        }

        private static async Task CreateApplicationRoles(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService <IServiceScopeFactory>().CreateScope();
            RoleManager<IdentityRole> roleManager =
                serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!roleManager.Roles.Any(x => x.Name == "Coach"))
                _ = await roleManager.CreateAsync((new IdentityRole("Coach")));
        }

        private static async Task CreateSystemApplicationUsers(this IApplicationBuilder app,
            IConfiguration configuration)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            UserManager<UserModel> userManager =
                serviceScope.ServiceProvider.GetRequiredService<UserManager<UserModel>>();

            if (!userManager.Users.Any(x => x.UserName == "chris"))
            {
                var user = new UserModel
                {
                    Email = "chris@carpedatum.co.uk",
                    UserName = "chris",
                    EmailConfirmed = true,
                    Firstname = "Chris",
                    Surname = "Wallington"
                };

                var result = await userManager.CreateAsync(user, "G1ngk13z!");

                if (result == IdentityResult.Success)
                {
                    // Put the user in the admin role
                    await userManager.AddToRoleAsync(user, "Coach");
                    await userManager.UpdateAsync(user);
                }
            }
        }

    }
}
