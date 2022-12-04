using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class TipoInstitucionService : ITipoInstitucionService
    {
        private readonly IDalService DalService;
        public TipoInstitucionService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<TipoInstitucionTB>> FindAll(GenericModel<TipoInstitucionTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<TipoInstitucionTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<TipoInstitucionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<TipoInstitucionTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<TipoInstitucionTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<TipoInstitucionTB> Get(long Id)
        {
            var result = DalService.Get<TipoInstitucionTB>(Id);
            return result;
        }

        public async Task<TipoInstitucionTB> Save(TipoInstitucionTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<TipoInstitucionTB> Delete(long Id)
        {
            var data = DalService.Delete<TipoInstitucionTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<TipoInstitucionTB>(); }
            catch { }return 0;
        }
    }

}
