using DataAccess.Auditoria;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class CorregimientoService : ICorregimientoService
    {
        private readonly IDalService DalService;
        public CorregimientoService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<CorregimientoTB>> FindAll(GenericModel<CorregimientoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<CorregimientoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Codigo.Contains(model.Filter))) &&
                              (model.ParentId > 0?data.DistritoId == model.ParentId:true) &&
                              (model.Parent2Id > 0 ? data.Distrito.ProvinciaId == model.Parent2Id : true)&&
                              (model.Parent3Id > 0 ? data.Distrito.Provincia.PaisId == model.Parent3Id : true)
                                orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<CorregimientoTB>()
                             where data.Deleted == false &&
                             (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Codigo.Contains(model.Filter))) &&
                              (model.ParentId > 0 ? data.DistritoId == model.ParentId : true) &&
                              (model.Parent2Id > 0 ? data.Distrito.ProvinciaId == model.Parent2Id : true) &&
                              (model.Parent3Id > 0 ? data.Distrito.Provincia.PaisId == model.Parent3Id : true)
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<CorregimientoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<CorregimientoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<CorregimientoTB> Get(long Id)
        {
            var result = DalService.Get<CorregimientoTB>(Id);
            return result;
        }

        public async Task<CorregimientoTB> Save(CorregimientoTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<CorregimientoTB> Delete(long Id)
        {
            var data = DalService.Delete<CorregimientoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<DistritoTB>(); }
            catch { }return 0;
        }
    }

}
