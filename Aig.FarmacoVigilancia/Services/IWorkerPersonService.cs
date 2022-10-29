using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IWorkerPersonService
    {
        Task<GenericModel<PersonalTrabajadorTB>> FindAll(GenericModel<PersonalTrabajadorTB> model);
        Task<List<PersonalTrabajadorTB>> GetAll();
        Task<PersonalTrabajadorTB> Get(long id);
        Task<PersonalTrabajadorTB> Save(PersonalTrabajadorTB data);
        Task<PersonalTrabajadorTB> Delete(long id);
        Task<int> Count();
    }

   
}
