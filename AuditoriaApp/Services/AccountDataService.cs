using DataModel;
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
              
        public async Task<APP_Account> Save(APP_Account data)
        {
            try {
                return  dalService.Save<APP_Account>(data);
            }
            catch (Exception e) { }
            return null;
        }

        public async Task<APP_Account> Delete(long Id)
        {
           
            try { return  dalService.Delete<APP_Account>(Id); }
            catch (Exception e) { }
            return null;
        }
        
        public async Task<List<APP_Account>> GetAll()
        {
           
            try { return  dalService.GetAll<APP_Account>(); }
            catch (Exception e) { }
            return null;
        }
        public async Task<APP_Account> First()
        {
            try { return dalService.First<APP_Account>(); }
            catch(Exception e) { }
            return null;
            
        }

        public async Task<APP_Account> GetByID(long Id)
        {            
            try {
                return dalService.Get<APP_Account>(Id);
            }
            catch (Exception e) { }
            return null;
        }

    }

}
