using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IActividadEstablecimientoService
    {
        Task<GenericModel<ActividadEstablecimientoTB>> FindAll(GenericModel<ActividadEstablecimientoTB> model);
        Task<List<ActividadEstablecimientoTB>> GetAll();
        Task<ActividadEstablecimientoTB> Get(long id);
        Task<ActividadEstablecimientoTB> Save(ActividadEstablecimientoTB data);
        Task<ActividadEstablecimientoTB> Delete(long id);
        Task<int> Count();
    }

   
}
