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
                    Email = "cihan_aytun@hotmail.com",
                    UserName = "cihan_aytun@hotmail.com",
                    Address = new Address
                    {
                        FirstName = "Cihan",
                        LastName = "Aytun",
                        Street = "Ferah Caddesi Çayırlık Sokak",
                        City = "İstanbul",
                        State = "Üsküdar",
                        ZipCode = "34600"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
