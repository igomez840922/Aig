using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class CorrespondenciaContactoService : ICorrespondenciaContactoService
    {
        private readonly IDalService DalService;
        public CorrespondenciaContactoService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_CorrespondenciaContactoTB>> FindAll(GenericModel<AUD_CorrespondenciaContactoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<AUD_CorrespondenciaContactoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Email.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_CorrespondenciaContactoTB>()
                             where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Email.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<AUD_CorrespondenciaContactoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_CorrespondenciaContactoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_CorrespondenciaContactoTB> Get(long Id)
        {
            var result = DalService.Get<AUD_CorrespondenciaContactoTB>(Id);
            return result;
        }

        public async Task<AUD_CorrespondenciaContactoTB> Save(AUD_CorrespondenciaContactoTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<AUD_CorrespondenciaContactoTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_CorrespondenciaContactoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_CorrespondenciaContactoTB>(); }
            catch { }return 0;
        }
    }

}
