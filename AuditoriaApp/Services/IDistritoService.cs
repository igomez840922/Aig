using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace AuditoriaApp.Services
{
    public interface IDistritoService
    {
        Task Syncronization();       

        /// <summary>
        /// ////////////////////////////////////////////
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<List<DistritoTB>> GetAll();
        Task<List<DistritoTB>> GetAllByProv(long Id);

    }
}
