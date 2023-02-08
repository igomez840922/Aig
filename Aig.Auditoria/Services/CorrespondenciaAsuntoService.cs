using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class CorrespondenciaAsuntoService : ICorrespondenciaAsuntoService
    {
        private readonly IDalService DalService;
        public CorrespondenciaAsuntoService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_CorrespondenciaAsuntoTB>> FindAll(GenericModel<AUD_CorrespondenciaAsuntoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<AUD_CorrespondenciaAsuntoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_CorrespondenciaAsuntoTB>()
                             where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<AUD_CorrespondenciaAsuntoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_CorrespondenciaAsuntoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_CorrespondenciaAsuntoTB> Get(long Id)
        {
            var result = DalService.Get<AUD_CorrespondenciaAsuntoTB>(Id);
            return result;
        }

        public async Task<AUD_CorrespondenciaAsuntoTB> Save(AUD_CorrespondenciaAsuntoTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<AUD_CorrespondenciaAsuntoTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_CorrespondenciaAsuntoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_CorrespondenciaAsuntoTB>(); }
            catch { }return 0;
        }
    }

}
