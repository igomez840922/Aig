using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace AuditoriaApp.Services
{
    public interface IProvinciaService
    {
        Task Syncronization();       

        /// <summary>
        /// ////////////////////////////////////////////
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<List<ProvinciaTB>> GetAll();

    }
}
