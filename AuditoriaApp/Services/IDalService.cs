
using AuditoriaApp.Data;
using SQLite;

namespace AuditoriaApp.Services
{
    public interface IDalService
    {
        SQLiteAsyncConnection dbContext { get; set; }
        Task SetUpDb();
    }
}
