using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class IpsService : IIpsService
    {
        private readonly IDalService DalService;
        public IpsService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_IpsTB>> FindAll(GenericModel<FMV_IpsTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.PrincActivo.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.PrincActivo.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<FMV_IpsTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_IpsTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_IpsTB> Get(long Id)
        {
            var result = DalService.Get<FMV_IpsTB>(Id);
            return result;
        }

        public async Task<FMV_IpsTB> Save(FMV_IpsTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<FMV_IpsTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_IpsTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_IpsTB>(); }
            catch { }return 0;
        }
    }

}
