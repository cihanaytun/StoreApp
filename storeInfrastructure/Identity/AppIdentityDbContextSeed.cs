using Microsoft.AspNetCore.Identity;
using storeCore.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeInfrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Cihan",
                    Email = "aytuncihan@hotmail.com",
                    UserName = "aytuncihan@hotmail.com",
                    Address = new Address
                    {
                        FirstName = "Cihan",
                        LastName = "Aytun",
                        Street = "Istanbul",
                        City = "Istanbul",
                        State = "Istanbul",
                        ZipCode = "34000"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
