using AuditoriaApp.Services;
using DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriaApp.Helper
{
   
    public static class SeedData
    {
        public static async Task SeedAll(IServiceProvider serviceProvider)
        {
            await UpdateMigrations(serviceProvider);
            //await SeedRoles(serviceProvider);
            //await SeedUsers(serviceProvider);
            await SeedFirstData(serviceProvider);
        }

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

        public static async Task SeedFirstData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {                
                var dalService = serviceScope.ServiceProvider.GetService<IDalService>();                                
                if (dalService.Count<APP_Account>() <= 0)
                {
                    var account = new APP_Account() {  };
                    dalService.Save(account);
                }

                var accountDataService = serviceScope.ServiceProvider.GetService<IAccountDataService>();
                var lastUpdate = await accountDataService.FirstLastUpdate();
                lastUpdate = lastUpdate != null ? lastUpdate : new APP_Updates() { SettingsUpdate = DateTime.Now.AddYears(-5) };
                //lastUpdate.SettingsUpdate = DateTime.Now.AddYears(-5);
                await accountDataService.SaveLastUpdate(lastUpdate);

                var inspectionService = serviceScope.ServiceProvider.GetService<IInspectionService>();
                await inspectionService.InspectionsUpload();
                await inspectionService.InspectionsSync();

                var paisService = serviceScope.ServiceProvider.GetService<IPaisService>();
                await paisService.Syncronization();

                var provinciaService = serviceScope.ServiceProvider.GetService<IProvinciaService>();
                await provinciaService.Syncronization();

                var distritoService = serviceScope.ServiceProvider.GetService<IDistritoService>();
                await distritoService.Syncronization();

                var corregimientoService = serviceScope.ServiceProvider.GetService<ICorregimientoService>();
                await corregimientoService.Syncronization();

                lastUpdate.SettingsUpdate = DateTime.Now;
                await accountDataService.SaveLastUpdate(lastUpdate);

            }
        }


    }

}
