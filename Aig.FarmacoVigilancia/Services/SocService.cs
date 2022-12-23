using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class SocService : ISocService
    {
        private readonly IDalService DalService;
        public SocService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_SocTB>> FindAll(GenericModel<FMV_SocTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<FMV_SocTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_SocTB>()
                             where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<FMV_SocTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_SocTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_SocTB> Get(long Id)
        {
            var result = DalService.Get<FMV_SocTB>(Id);
            return result;
        }

        public async Task<FMV_SocTB> Save(FMV_SocTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<FMV_SocTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_SocTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_SocTB>(); }
            catch { }return 0;
        }
    }

}
