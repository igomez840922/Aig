using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace AuditoriaApp.Services
{
    public interface IDashboardService
    {                
        Task<APP_Dashboard> Get();   
    }
}
