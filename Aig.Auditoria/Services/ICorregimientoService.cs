using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface ICorregimientoService
    {
        Task<GenericModel<CorregimientoTB>> FindAll(GenericModel<CorregimientoTB> model);
        Task<List<CorregimientoTB>> GetAll();
        Task<CorregimientoTB> Get(long id);
        Task<CorregimientoTB> Save(CorregimientoTB data);
        Task<CorregimientoTB> Delete(long id);
        Task<int> Count();
    }
}
