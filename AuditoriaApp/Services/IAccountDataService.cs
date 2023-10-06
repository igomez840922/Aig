
using DataModel;

namespace AuditoriaApp.Services
{
    public interface IAccountDataService
    {
        Task<APP_Account> Save(APP_Account data);
        Task<APP_Account> Delete(long Id);
        Task<List<APP_Account>> GetAll();
        Task<APP_Account> GetByID(long Id);
        Task<APP_Account> First();
        Task<APP_Updates> SaveLastUpdate(APP_Updates data);
        Task<APP_Updates> FirstLastUpdate();
    }
}
