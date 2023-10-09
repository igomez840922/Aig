
using AuditoriaApp.Helper;
using DataModel;
using SQLite;
using System.Linq.Expressions;

namespace AuditoriaApp.Services
{
    public interface IDalService
    {
        ApplicationDbContext DBContext { get; set; }
        List<T> GetAll<T>() where T : class;
        List<T> GetAll<T>(int PageIdx, int PageAmt) where T : class, Identity;
        T Get<T>(long Id) where T : class;
        T GetReloaded<T>(long Id) where T : class;
        T Find<T>(Expression<Func<T, bool>> match) where T : class;
        List<T> FindAll<T>(Expression<Func<T, bool>> match) where T : class;
        List<T> FindAll<T>(Expression<Func<T, bool>> match, int PageIdx, int PageAmt) where T : class, Identity;
        T Save<T>(T _Data) where T : class, Identity;
        T UpdateValues<T>(T _Data) where T : class, Identity;
        T Delete<T>(long Id) where T : class;
        int Count<T>() where T : class;
        int Count<T>(Expression<Func<T, bool>> match) where T : class;
        T First<T>() where T : class;
        void Reload();
    }
}
