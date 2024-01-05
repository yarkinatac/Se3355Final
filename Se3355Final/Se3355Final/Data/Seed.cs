using Microsoft.AspNetCore.Identity;
using Se3355Final.Data;
using Se3355Final.Models;

namespace Se3355Final.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new List<Car>()
                    {
                        new Car()
                        {
                            Make = "Toyota", Model = "Corolla", Transmission = "Automatic", Price = 100, Mileage = 50000, Deposit = 200, Age = 3,  imageUrl= "https://cdn.motor1.com/images/mgl/XB2njV/s1/4x3/yeni-toyota-corolla-turkiye-de-satisa-sunuldu.webp"
                         },
                        new Car()
                        {
                            Make = "Ford", Model = "Focus", Transmission = "Manual", Price = 80, Mileage = 60000, Deposit = 150, Age = 5, imageUrl = "https://cdn.cetas.com.tr/Delivery/Public/Image/-1x-1/1_kl81i4vcks.jpg"
                        },
                        new Car()
                        {
                            Make = "Volkswagen", Model = "Polo", Transmission = "Automatic", Price = 90, Mileage = 30000, Deposit = 250, Age = 2, imageUrl = "https://hips.hearstapps.com/hmg-prod/images/2023-civic-type-r-toyta-gr-corolla-vw-golf-r-012-64062ae3d5333.jpg?crop=0.503xw:0.376xh;0.258xw,0.402xh&resize=1200:*"
                        },
                    });
                    context.SaveChanges();
                }
                
                if (!context.Offices.Any())
                {
                    context.Offices.AddRange(new List<Office>()
                    {
                        new Office()
                        {
                            Name = "Istanbul Office", Address = "Istanbul Street 1", City = "Istanbul", Country = "Turkey", Latitude = 41.0082, Longitude = 28.9784, PhoneNumber = "+905511123442"
                        },
                        new Office()
                        {
                            Name = "Ankara Office", Address = "Ankara Street 2", City = "Ankara", Country = "Turkey", Latitude = 39.9334, Longitude = 32.8597, PhoneNumber = "+905678905432"
                        },
                        new Office()
                        {
                            Name = "Izmir Office", Address = "Izmir Street 3", City = "Izmir", Country = "Turkey", Latitude = 38.4237, Longitude = 27.1428, PhoneNumber = "+901234567123"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
        //     using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //     {
        //         //Roles
        //         var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //
        //         if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //             await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //         if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //             await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        //
        //         //Users
        //         var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //         string adminUserEmail = "teddysmithdeveloper@gmail.com";
        //
        //         var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //         if (adminUser == null)
        //         {
        //             var newAdminUser = new AppUser()
        //             {
        //                 UserName = "teddysmithdev",
        //                 Email = adminUserEmail,
        //                 EmailConfirmed = true,
        //                 Address = new Address()
        //                 {
        //                     Street = "123 Main St",
        //                     City = "Charlotte",
        //                     State = "NC"
        //                 }
        //             };
        //             await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //             await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //         }
        //
        //         string appUserEmail = "user@etickets.com";
        //
        //         var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //         if (appUser == null)
        //         {
        //             var newAppUser = new AppUser()
        //             {
        //                 UserName = "app-user",
        //                 Email = appUserEmail,
        //                 EmailConfirmed = true,
        //                 Address = new Address()
        //                 {
        //                     Street = "123 Main St",
        //                     City = "Charlotte",
        //                     State = "NC"
        //                 }
        //             };
        //             await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //             await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //         }
        //     }
         }
    }
}