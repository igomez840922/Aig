using DataModel;
using DataModel.DTO;
using DataModel.Models;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IEstablishmentsService
    {
        Task<GenericModel<AUD_EstablecimientoTB>> FindAll(GenericModel<AUD_EstablecimientoTB> model);
        Task<List<AUD_EstablecimientoTB>> GetAll();
        Task<AUD_EstablecimientoTB> Get(long id);
        Task<AUD_EstablecimientoTB> Save(AUD_EstablecimientoTB data);
        Task<AUD_EstablecimientoTB> Delete(long id);
        Task<int> Count();

        Task<GenericModel<FarmaceuticoEstablecimientoDto>> RptFarmaceuticos(GenericModel<FarmaceuticoEstablecimientoDto> model);
        Task<GenericModel<RegenteEstablecimientoDto>> RptRegentes(GenericModel<RegenteEstablecimientoDto> model);
        Task<Stream> RptFarmaceuticosExportToExcel(GenericModel<FarmaceuticoEstablecimientoDto> model);
        Task<Stream> RptRegentesExportToExcel(GenericModel<RegenteEstablecimientoDto> model);
    }
}
