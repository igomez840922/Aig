using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IInspeccionService
    {
        Task<GenericModel<AUD_InspeccionTB>> FindAll(string filter, int pIdx, int pAmt);
        Task<List<AUD_InspeccionTB>> GetAll();
        Task<AUD_InspeccionTB> Get(long id);
        Task<AUD_InspeccionTB> Save(AUD_InspeccionTB data);
        Task<AUD_InspeccionTB> Delete(long id);
        Task<int> Count();
    }
}
