using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class PmrService : IPmrService
    {
        private readonly IDalService DalService;
        public PmrService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_PmrTB>> FindAll(GenericModel<FMV_PmrTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<FMV_PmrTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.PrincActivo.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_PmrTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.PrincActivo.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<FMV_PmrTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_PmrTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_PmrTB> Get(long Id)
        {
            var result = DalService.Get<FMV_PmrTB>(Id);
            return result;
        }

        public async Task<FMV_PmrTB> Save(FMV_PmrTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<FMV_PmrTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_PmrTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_PmrTB>(); }
            catch { }return 0;
        }
    }

}
