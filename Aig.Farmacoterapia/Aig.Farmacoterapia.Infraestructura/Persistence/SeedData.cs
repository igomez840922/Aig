using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.Persistence;
using Aig.Farmacoterapia.Domain.Extensions;
using Castle.Core;
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
            await SeedRoles(serviceProvider);
            await SeedUsers(serviceProvider);
            await SeedService(serviceProvider);
        }
        static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                foreach (RoleType dt in Enum.GetValues(typeof(RoleType)))
                {
                    var num = (long)dt;
                    var roleName = dt.ToString();
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
        }
        static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                if (userManager.FindByNameAsync("admin@admin.com").Result == null)
                {
                    ApplicationUser user = new ApplicationUser();
                    user.Role = RoleType.Admin;
                    user.FirstName = "Admin";
                    user.LastName = "Test";
                    user.UserName = "admin@admin.com";
                    user.Email = "admin@admin.com";
                    user.PhoneNumber = "3055525252";
                    user.EmailConfirmed = true;
                    user.LockoutEnabled = false;
                    user.PhoneNumberConfirmed = true;
                    user.TwoFactorEnabled = false;
                    IdentityResult result = await userManager.CreateAsync(user, "123");
                    if (result.Succeeded)
                    {
                        var roleName = RoleType.Admin.ToString();
                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
        }
        static async Task SeedService(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var unitOfWork = serviceScope.ServiceProvider.GetService<IUnitOfWork>();
                var item = unitOfWork?.Repository<AigService>().Entities.SingleOrDefault(p=>p.Code== "SYSFARM");
                if (item == null) {
                    //var password = "123".Encrypt();
                    //var plane = password.Decrypt();
                    unitOfWork?.Repository<AigService>().AddAsync(new AigService(){
                        Code = "SYSFARM",
                        Host = "apisysfarm.minsa.gob.pa",
                        Https = true,
                        Port = -1,
                        User = string.Empty,
                        Password = string.Empty,
                        Token = string.Empty,
                        UpdateTime=5,
                        LastRun=null,
                    });
                    _ = await unitOfWork.CommitAsync(default);
                }
                item = unitOfWork?.Repository<AigService>().Entities.SingleOrDefault(p => p.Code == "SIRFAD");
                if (item == null)
                {
                    unitOfWork?.Repository<AigService>().AddAsync(new AigService() {
                        Code = "SIRFAD",
                        Host = "tramites-minsa.panamadigital.gob.pa",
                        Https = true,
                        Port = -1,
                        User = string.Empty,
                        Password = string.Empty,
                        Token = string.Empty,
                        UpdateTime = 5,
                        LastRun = null
                    });
                    _ = await unitOfWork.CommitAsync(default);
                }
            }
        }
    }
}
