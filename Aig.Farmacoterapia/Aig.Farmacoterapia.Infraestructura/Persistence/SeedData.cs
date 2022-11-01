using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aig.Farmacoterapia.Infrastructure.SeedData
{
    public static class SeedData
    {        
        public static async Task UpdateMigrations(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    await dbContext.Database.MigrateAsync();
                }
            }
        }

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var role = "Admin";
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
                //foreach (enumUserRoleType dt in Enum.GetValues(typeof(enumUserRoleType)))
                //{
                //    var roleName = DataModel.Helper.Helper.GetDescription<enumUserRoleType>(dt);
                //    if (!await roleManager.RoleExistsAsync(roleName))
                //    {
                //        await roleManager.CreateAsync(new IdentityRole(roleName));
                //    }
                //}                
            }
        }

        public static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                if (userManager.FindByNameAsync("admin").Result == null)
                {
                    ApplicationUser user = new ApplicationUser();
                    user.UserName = "admin";
                    user.Email = "admin@admin.com";
                    user.PhoneNumber = "3055525252";
                    user.EmailConfirmed = true;
                    user.LockoutEnabled = false;
                    user.PhoneNumberConfirmed = true;
                    user.TwoFactorEnabled = false;

                    //ApplicationUser user = new ApplicationUser() { UserProfile = new UserProfileTB() { Languanje = "en-US" } };
                    //user.UserRoleType = enumUserRoleType.Admin;
                    //user.UserProfile.FirstName = "admin";
                    //user.UserProfile.SecondName = "admin";
                    //user.UserProfile.SureName = "admin";
                    //user.UserProfile.SecondSurName = "admin";
                    //user.UserName = "admin";
                    //user.Email = "admin@admin.com";
                    //user.PhoneNumber = "3055525252";
                    //user.EmailConfirmed = true;
                    //user.LockoutEnabled = false;
                    //user.PhoneNumberConfirmed = true;
                    //user.TwoFactorEnabled = false;

                    IdentityResult result = await userManager.CreateAsync(user, "admin");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
        }

        //public static async Task SeedFirstData(IServiceProvider serviceProvider)
        //{
        //    using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        //    {
        //        var serviceCat = serviceScope.ServiceProvider.GetService<ICategoryService>();
        //        var serviceProd = serviceScope.ServiceProvider.GetService<IProductService>();

        //        if (await serviceCat.Count() <= 0)
        //        {
        //            Category cat = new Category() { Name= "Foods" };
        //            cat = await serviceCat.Save(cat);
        //            if (cat != null)
        //            {
        //                Product prod = new Product() { Name = "Brownie" , Price=(decimal)0.65, CategoryId=cat.Id, InStock=0 };
        //                prod = await serviceProd.Save(prod);
        //                prod = new Product() { Name = "Muffin", Price = (decimal)1.00, CategoryId = cat.Id, InStock = 0 };
        //                prod = await serviceProd.Save(prod);
        //                prod = new Product() { Name = "Cake Pop", Price = (decimal)1.35, CategoryId = cat.Id, InStock = 0 };
        //                prod = await serviceProd.Save(prod);
        //                prod = new Product() { Name = "Apple Tart", Price = (decimal)1.50, CategoryId = cat.Id, InStock = 0 };
        //                prod = await serviceProd.Save(prod);
        //                prod = new Product() { Name = "Water", Price = (decimal)1.50, CategoryId = cat.Id, InStock = 0 };
        //                prod = await serviceProd.Save(prod);
        //            }
        //            cat = new Category() { Name = "Clothes" };
        //            cat = await serviceCat.Save(cat);
        //            if (cat != null)
        //            {
        //                Product prod = new Product() { Name = "Shirt", Price = (decimal)2.00, CategoryId = cat.Id, InStock = 0 };
        //                prod = await serviceProd.Save(prod);
        //                prod = new Product() { Name = "Pants", Price = (decimal)3.00, CategoryId = cat.Id, InStock = 0 };
        //                prod = await serviceProd.Save(prod);
        //                prod = new Product() { Name = "Jacket", Price = (decimal)4.00, CategoryId = cat.Id, InStock = 0 };
        //                prod = await serviceProd.Save(prod);                        
        //            }
        //            cat = new Category() { Name = "Toys" };
        //            cat = await serviceCat.Save(cat);
        //            if (cat != null)
        //            {
        //                Product prod = new Product() { Name = "Toy", Price = (decimal)1.00, CategoryId = cat.Id, InStock = 0 };
        //                prod = await serviceProd.Save(prod);
        //            }
        //        }
                
        //    }
        //}


    }
}
