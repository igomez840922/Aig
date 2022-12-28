using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class CorrespondenciaService : ICorrespondenciaService
    {
        private readonly IDalService DalService;
        public CorrespondenciaService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_CorrespondenciaTB>> FindAll(GenericModel<AUD_CorrespondenciaTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<AUD_CorrespondenciaTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Establecimiento.Contains(model.Filter) || data.NumDocRecibido.Contains(model.Filter) || data.NombreRecibido.Contains(model.Filter) || data.NumDocRespuesta.Contains(model.Filter)))
                              orderby data.CreatedDate descending
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_CorrespondenciaTB>()
                             where data.Deleted == false &&
                             (string.IsNullOrEmpty(model.Filter) ? true : (data.Establecimiento.Contains(model.Filter) || data.NumDocRecibido.Contains(model.Filter) || data.NombreRecibido.Contains(model.Filter) || data.NumDocRespuesta.Contains(model.Filter)))
                             select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<AUD_CorrespondenciaTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_CorrespondenciaTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_CorrespondenciaTB> Get(long Id)
        {
            var result = DalService.Get<AUD_CorrespondenciaTB>(Id);
            return result;
        }

        public async Task<AUD_CorrespondenciaTB> Save(AUD_CorrespondenciaTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<AUD_CorrespondenciaTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_CorrespondenciaTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_CorrespondenciaTB>(); }
            catch { }return 0;
        }
    }

}
