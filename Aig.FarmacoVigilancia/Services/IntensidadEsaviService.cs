using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class IntensidadEsaviService : IIntensidadEsaviService
    {
        private readonly IDalService DalService;
        public IntensidadEsaviService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<IntensidadEsaviTB>> FindAll(GenericModel<IntensidadEsaviTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<IntensidadEsaviTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Gravedad.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<IntensidadEsaviTB>()
                             where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Gravedad.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<IntensidadEsaviTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<IntensidadEsaviTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<IntensidadEsaviTB> Get(long Id)
        {
            var result = DalService.Get<IntensidadEsaviTB>(Id);
            return result;
        }

        public async Task<IntensidadEsaviTB> Save(IntensidadEsaviTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<IntensidadEsaviTB> Delete(long Id)
        {
            var data = DalService.Delete<IntensidadEsaviTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<IntensidadEsaviTB>(); }
            catch { }return 0;
        }
    }

}
