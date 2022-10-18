using Aig.Auditoria.Services;
using DataAccess;
using DataAccess.Auditoria;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Auditoria.Helper
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

                foreach (enumUserRoleType dt in Enum.GetValues(typeof(enumUserRoleType)))
                {
                    var roleName = DataModel.Helper.Helper.GetDescription<enumUserRoleType>(dt);
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }                
            }
        }

        public static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                if (userManager.FindByNameAsync("admin").Result == null)
                {
                    ApplicationUser user = new ApplicationUser() { UserProfile = new UserProfileTB() { Languanje = "en-US" } };
                    user.UserRoleType = enumUserRoleType.Admin;
                    user.UserProfile.FirstName = "admin";
                    user.UserProfile.SecondName = "admin";
                    user.UserProfile.SureName = "admin";
                    user.UserProfile.SecondSurName = "admin";
                    user.UserName = "admin";
                    user.Email = "admin@admin.com";
                    user.PhoneNumber = "3055525252";
                    user.EmailConfirmed = true;
                    user.LockoutEnabled = false;
                    user.PhoneNumberConfirmed = true;
                    user.TwoFactorEnabled = false;

                    IdentityResult result = await userManager.CreateAsync(user, "admin");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, DataModel.Helper.Helper.GetDescription<enumUserRoleType>(enumUserRoleType.Admin));
                    }
                }
            }
        }

        public static async Task SeedFirstData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var inspeccionService = serviceScope.ServiceProvider.GetService<IInspectionsService>();

                if (await inspeccionService.Count() <= 0)
                {
                    AUD_InspeccionTB _Inspection = new AUD_InspeccionTB()
                    {
                        FechaInicio = DateTime.Now,
                        //NumActa = 1,
                        TipoActa = DataModel.Helper.enumAUD_TipoActa.AperturaCambioUbicacionFarmacias,
                        InspAperCambUbicFarm = new AUD_InspAperCambUbicFarmTB()
                        {
                            DatosEstablecimiento = new AUD_DatosEstablecimiento() { Corregimiento = "Corregimiento 1", Distrito = "Distrito 1", Provincia = "Provincia 1", Telefono = "62453371", Ubicacion = "Obarrio esquina verde" },
                        }
                    };

                    _Inspection = await inspeccionService.Save(_Inspection);
                }

            }
        }


    }
}
