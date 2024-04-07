using DataAccessLayer.Concrete.Helpers;
using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.SeedMethods
{
    public class SeedData
    {
        public static async Task InitializeRoles(IServiceProvider serviceProvider,
            RoleManager<IdentityRole> roleManager)
        {
            foreach (ERole role in Enum.GetValues(typeof(ERole)))
            {
                var roleExists = await roleManager.RoleExistsAsync(role.ToString());

                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(role.ToString()));
                }
            }
        }
    }
}
