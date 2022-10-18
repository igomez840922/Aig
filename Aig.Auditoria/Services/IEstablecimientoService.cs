using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IEstablecimientoService
    {
        Task<GenericModel<AUD_EstablecimientoTB>> FindAll(GenericModel<AUD_EstablecimientoTB> model);
        Task<List<AUD_EstablecimientoTB>> GetAll();
        Task<AUD_EstablecimientoTB> Get(long id);
        Task<AUD_EstablecimientoTB> Save(AUD_EstablecimientoTB data);
        Task<AUD_EstablecimientoTB> Delete(long id);
        Task<int> Count();
    }
}
