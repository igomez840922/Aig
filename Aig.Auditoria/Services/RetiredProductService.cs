using DataAccess.Auditoria;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class RetiredProductService : IRetiredProductService
    {
        private readonly IDalService DalService;
        public RetiredProductService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_ProdRetiroRetencionTB>> FindAll(GenericModel<AUD_ProdRetiroRetencionTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<AUD_ProdRetiroRetencionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.RegSanitario.Contains(model.Filter) || data.PresentacionComercial.Contains(model.Filter) || data.Fabricante.Contains(model.Filter) || data.Lote.Contains(model.Filter) || data.Pais.Contains(model.Filter) || data.Destino.Contains(model.Filter) || data.FrmRetiroRetencion.SeccionOficinaRegional.Contains(model.Filter) || data.FrmRetiroRetencion.SeccionOficinaRegional.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.LicenseNumber.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.NumActa.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.Establecimiento.Nombre.Contains(model.Filter)))
                               orderby data.CreatedDate
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_ProdRetiroRetencionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.RegSanitario.Contains(model.Filter) || data.PresentacionComercial.Contains(model.Filter) || data.Fabricante.Contains(model.Filter) || data.Lote.Contains(model.Filter) || data.Pais.Contains(model.Filter) || data.Destino.Contains(model.Filter) || data.FrmRetiroRetencion.SeccionOficinaRegional.Contains(model.Filter) || data.FrmRetiroRetencion.SeccionOficinaRegional.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.LicenseNumber.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.NumActa.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.Establecimiento.Nombre.Contains(model.Filter)))
                               select data).Count();

            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<AUD_ProdRetiroRetencionTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_ProdRetiroRetencionTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_ProdRetiroRetencionTB> Get(long Id)
        {
            var result = DalService.Get<AUD_ProdRetiroRetencionTB>(Id);
            return result;
        }

        public async Task<AUD_ProdRetiroRetencionTB> Save(AUD_ProdRetiroRetencionTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<AUD_ProdRetiroRetencionTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_ProdRetiroRetencionTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_ProdRetiroRetencionTB>(); }
            catch { }return 0;
        }
    }

}
