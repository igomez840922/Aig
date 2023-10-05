
using AuditoriaApp.Data;
using SQLite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuditoriaApp.Services
{
    public class AccountDataService : IAccountDataService
    {
        IDalService dalService;
        public AccountDataService(IDalService dalService)
        {
           this.dalService = dalService;
        }
              
        public async Task<int> Save(AccountData data)
        {
            try {
                if (data.Id != 0)
                {
                    return await dalService.dbContext.UpdateAsync(data);
                }
                return await dalService.dbContext.InsertAsync(data);
            }
            catch (Exception e) { }
            return 0;
        }

        public async Task<int> Delete(AccountData data)
        {
           
            try { return await dalService.dbContext.DeleteAsync(data); }
            catch (Exception e) { }
            return 0;
        }
        
        public async Task<List<AccountData>> GetAll()
        {
           
            try { return await dalService.dbContext.Table<AccountData>().ToListAsync(); }
            catch (Exception e) { }
            return null;
        }
        public async Task<AccountData> First()
        {
            try { return await dalService.dbContext.Table<AccountData>().FirstOrDefaultAsync(); }
            catch(Exception e) { }
            return null;
            
        }

        public async Task<AccountData> GetByID(int Id)
        {            
            try {
                var data = await dalService.dbContext.QueryAsync<AccountData>($"Select * From {nameof(AccountData)} where Id={Id} ");
                return data.FirstOrDefault();
            }
            catch (Exception e) { }
            return null;
        }

    }

}
