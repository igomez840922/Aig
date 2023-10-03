
using AuditoriaApp.Data;

namespace AuditoriaApp.Services
{
    public interface IAccountDataService
    {
        Task<AccountData> First();
        Task<List<AccountData>> GetAll();
        Task<AccountData> GetByID(int Id);
        Task<int> Save(AccountData data);
        Task<int> Delete(AccountData data);
    }
}
