using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace AuditoriaApp.Services
{
    public interface ICorregimientoService
    {
        Task Syncronization();       

        /// <summary>
        /// ////////////////////////////////////////////
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<List<CorregimientoTB>> GetAll();
        Task<List<CorregimientoTB>> GetAllByDist(long Id);

    }
}
