using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class CorrespondenciaRespRevisionService : ICorrespondenciaRespRevisionService
    {
        private readonly IDalService DalService;
        public CorrespondenciaRespRevisionService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_CorrespondenciaRespRevisionTB>> FindAll(GenericModel<AUD_CorrespondenciaRespRevisionTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<AUD_CorrespondenciaRespRevisionTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Cargo.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_CorrespondenciaRespRevisionTB>()
                             where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Cargo.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<AUD_CorrespondenciaRespRevisionTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_CorrespondenciaRespRevisionTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_CorrespondenciaRespRevisionTB> Get(long Id)
        {
            var result = DalService.Get<AUD_CorrespondenciaRespRevisionTB>(Id);
            return result;
        }

        public async Task<AUD_CorrespondenciaRespRevisionTB> Save(AUD_CorrespondenciaRespRevisionTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<AUD_CorrespondenciaRespRevisionTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_CorrespondenciaRespRevisionTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_CorrespondenciaRespRevisionTB>(); }
            catch { }return 0;
        }
    }

}
