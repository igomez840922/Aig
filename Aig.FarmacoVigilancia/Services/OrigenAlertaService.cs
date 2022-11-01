using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class OrigenAlertaService : IOrigenAlertaService
    {
        private readonly IDalService DalService;
        public OrigenAlertaService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_OrigenAlertaTB>> FindAll(GenericModel<FMV_OrigenAlertaTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<FMV_OrigenAlertaTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_OrigenAlertaTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<FMV_OrigenAlertaTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_OrigenAlertaTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_OrigenAlertaTB> Get(long Id)
        {
            var result = DalService.Get<FMV_OrigenAlertaTB>(Id);
            return result;
        }

        public async Task<FMV_OrigenAlertaTB> Save(FMV_OrigenAlertaTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<FMV_OrigenAlertaTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_OrigenAlertaTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_OrigenAlertaTB>(); }
            catch { }return 0;
        }
    }

}
