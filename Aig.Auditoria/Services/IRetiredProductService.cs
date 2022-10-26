using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IRetiredProductService
    {
        Task<Stream> ExportToExcel(GenericModel<AUD_ProdRetiroRetencionTB> model);
        Task<GenericModel<AUD_ProdRetiroRetencionTB>> FindAll(GenericModel<AUD_ProdRetiroRetencionTB> model);
        Task<List<AUD_ProdRetiroRetencionTB>> GetAll();
        Task<AUD_ProdRetiroRetencionTB> Get(long id);
        Task<AUD_ProdRetiroRetencionTB> Save(AUD_ProdRetiroRetencionTB data);
        Task<AUD_ProdRetiroRetencionTB> Delete(long id);
        Task<int> Count();
    }
}
