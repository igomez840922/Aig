using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class ProvicesService : IProvicesService
    {
        private readonly IDalService DalService;
        public ProvicesService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<ProvinciaTB>> FindAll(GenericModel<ProvinciaTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<ProvinciaTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Codigo.Contains(model.Filter))) &&
                              (model.ParentId > 0?data.PaisId == model.ParentId:true)
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<ProvinciaTB>()
                             where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Codigo.Contains(model.Filter))) &&
                              (model.ParentId > 0 ? data.PaisId == model.ParentId : true)
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<ProvinciaTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<ProvinciaTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<ProvinciaTB> Get(long Id)
        {
            var result = DalService.Get<ProvinciaTB>(Id);
            return result;
        }

        public async Task<ProvinciaTB> Save(ProvinciaTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<ProvinciaTB> Delete(long Id)
        {
            var data = DalService.Delete<ProvinciaTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<ProvinciaTB>(); }
            catch { }return 0;
        }
    }

}
