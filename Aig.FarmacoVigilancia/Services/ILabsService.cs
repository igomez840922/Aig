using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface ILabsService
    {
        Task<GenericModel<LaboratorioTB>> FindAll(GenericModel<LaboratorioTB> model);
        Task<List<LaboratorioTB>> GetAll();
        Task<LaboratorioTB> Get(long id);
        Task<LaboratorioTB> Save(LaboratorioTB data);
        Task<LaboratorioTB> Delete(long id);
        Task<int> Count();
    }

   
}
