
using AuditoriaApp.Data;
using SQLite;

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
            if(data.Id != 0)
            {
                return await dalService.dbContext.UpdateAsync(data);
            }
            return await dalService.dbContext.InsertAsync(data);
        }

        public async Task<int> Delete(AccountData data)
        {
            return await dalService.dbContext.DeleteAsync(data);
        }
        
        public async Task<List<AccountData>> GetAll()
        {
            return await dalService.dbContext.Table<AccountData>().ToListAsync();
        }
        public async Task<AccountData> First()
        {
            return await dalService.dbContext.Table<AccountData>().FirstOrDefaultAsync();
        }

        public async Task<AccountData> GetByID(int Id)
        {
            var student = await dalService.dbContext.QueryAsync<AccountData>($"Select * From {nameof(AccountData)} where Id={Id} ");
            return student.FirstOrDefault();
        }

    }

}
