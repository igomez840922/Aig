using DataAccess.Auditoria;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class DistrictService : IDistrictService
    {
        private readonly IDalService DalService;
        public DistrictService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<DistritoTB>> FindAll(GenericModel<DistritoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<DistritoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Codigo.Contains(model.Filter))) &&
                              (model.ParentId > 0?data.ProvinciaId == model.ParentId:true) &&
                              (model.Parent2Id > 0 ? data.Provincia.PaisId == model.Parent2Id : true)
                                orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<DistritoTB>()
                             where data.Deleted == false &&
                             (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Codigo.Contains(model.Filter))) &&
                              (model.ParentId > 0 ? data.ProvinciaId == model.ParentId : true) &&
                              (model.Parent2Id > 0 ? data.Provincia.PaisId == model.Parent2Id : true)
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<DistritoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<DistritoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<DistritoTB> Get(long Id)
        {
            var result = DalService.Get<DistritoTB>(Id);
            return result;
        }

        public async Task<DistritoTB> Save(DistritoTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<DistritoTB> Delete(long Id)
        {
            var data = DalService.Delete<DistritoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<DistritoTB>(); }
            catch { }return 0;
        }
    }

}
