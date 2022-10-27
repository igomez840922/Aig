using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class CountriesService : ICountriesService
    {
        private readonly IDalService DalService;
        public CountriesService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<PaisTB>> FindAll(GenericModel<PaisTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<PaisTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Codigo.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<PaisTB>()
                             where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Codigo.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<PaisTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<PaisTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<PaisTB> Get(long Id)
        {
            var result = DalService.Get<PaisTB>(Id);
            return result;
        }

        public async Task<PaisTB> Save(PaisTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<PaisTB> Delete(long Id)
        {
            var data = DalService.Delete<PaisTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<PaisTB>(); }
            catch { }return 0;
        }
    }

}
