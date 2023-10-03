using AuditoriaApp.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AuditoriaApp.Services
{
    public class DalService: IDalService
    {
        public SQLiteAsyncConnection dbContext { get; set; }

        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AuditoriaApp.db02");
               
        public DalService()
        {
            SetUpDb();
        }

        public async Task SetUpDb()
        {
            if (!File.Exists(dbPath))
            {
                dbContext = new SQLiteAsyncConnection(dbPath);
                await dbContext.CreateTableAsync<AccountData>();
            }

            dbContext = dbContext != null ? dbContext : dbContext = new SQLiteAsyncConnection(dbPath);            
        }


    }
}
