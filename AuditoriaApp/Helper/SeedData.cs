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
            }
        }


    }

}
