using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace AuditoriaApp.Services
{
    public interface IPaisService
    {
        Task Syncronization();       

        /// <summary>
        /// ////////////////////////////////////////////
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<List<PaisTB>> GetAll();

    }
}
