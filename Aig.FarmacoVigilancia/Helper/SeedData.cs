
using DataAccess;
using DataAccess.FarmacoVigilancia;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aig.FarmacoVigilancia.Helper
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
                var dalService = serviceScope.ServiceProvider.GetService<IDalService>();

                if (dalService.Count<LaboratorioTB>() <= 0)
                {
                    LaboratorioTB lab = new LaboratorioTB() { Nombre = "Abbott" };
                    dalService.Save(lab);
                    lab = new LaboratorioTB() { Nombre = "Roche" };
                    dalService.Save(lab);
                    lab = new LaboratorioTB() { Nombre = "GSK" };
                    dalService.Save(lab);
                    lab = new LaboratorioTB() { Nombre = "Novartis" };
                    dalService.Save(lab);
                }
                if (dalService.Count<PersonalTrabajadorTB>() <= 0)
                {
                    PersonalTrabajadorTB lab = new PersonalTrabajadorTB() { NombreCompleto = "Arelis Quintero", Evaluador = true, Registrador = true, Tramitador = true };
                    dalService.Save(lab);
                    lab = new PersonalTrabajadorTB() { NombreCompleto = "Favio Navarro", Evaluador=true, Registrador=true, Tramitador=true };
                    dalService.Save(lab);
                    lab = new PersonalTrabajadorTB() { NombreCompleto = "Idalmis Aguilar", Evaluador = true, Registrador = true, Tramitador = true };
                    dalService.Save(lab);
                    lab = new PersonalTrabajadorTB() { NombreCompleto = "Miguel Díaz" , Evaluador = true, Registrador = true, Tramitador = true };
                    dalService.Save(lab);
                }

                ////Countries
                //if (await countryService.Count() <= 0)
                //{
                //    List<PaisTB> lCountries = null;
                //    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.FarmacoVigilancia.Resources.provincias.json"))
                //    using (StreamReader reader = new StreamReader(stream))
                //    {
                //        var jsonFileContent = reader.ReadToEnd();
                //        lCountries = JsonConvert.DeserializeObject<List<PaisTB>>(jsonFileContent);
                //    }
                //    if (lCountries != null)
                //    {
                //        foreach (var country in lCountries)
                //        {
                //            await countryService.Save(country);
                //        }
                //    }
                //}

                //if (dalService.Count<ProvinciaTB>() <= 0)
                //{
                //    PaisTB pais = dalService.Find<PaisTB>(x => x.Codigo == "PA");
                //    List<Provincium> lProvincial = null;
                //    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.FarmacoVigilancia.Resources.provincias.json"))
                //    using (StreamReader reader = new StreamReader(stream))
                //    {
                //        var jsonFileContent = reader.ReadToEnd();
                //        var mainProv = JsonConvert.DeserializeObject<MainProvincias>(jsonFileContent);
                //        lProvincial = mainProv.provincia;
                //    }
                //    if (lProvincial != null)
                //    {
                //        foreach (var prov in lProvincial)
                //        {
                //            //await countryService.Save(prov);
                //            var provincia = new ProvinciaTB() { Nombre = prov.nombre, Codigo = prov.ced, LDistritos = new List<DistritoTB>(), Pais = pais };
                //            foreach (var dist in prov.distrito)
                //            {
                //                var distrito = new DistritoTB() { Nombre = dist.nombre, Codigo = dist.cabecera, LCorregimientos = new List<CorregimientoTB>() };
                //                provincia.LDistritos.Add(distrito);
                //                foreach (var corr in dist.corregimientos)
                //                {
                //                    var corregimiento = new CorregimientoTB() { Nombre = corr, Codigo = corr };
                //                    distrito.LCorregimientos.Add(corregimiento);
                //                }
                //            }
                //            dalService.Save(provincia);
                //        }
                //    }
                //}


            }

        }


    }
}
