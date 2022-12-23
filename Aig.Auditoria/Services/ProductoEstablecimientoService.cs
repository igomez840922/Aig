using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class ProductoEstablecimientoService : IProductoEstablecimientoService
    {
        private readonly IDalService DalService;
        public ProductoEstablecimientoService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<ProductoEstablecimientoTB>> FindAll(GenericModel<ProductoEstablecimientoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<ProductoEstablecimientoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<ProductoEstablecimientoTB>()
                             where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<ProductoEstablecimientoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<ProductoEstablecimientoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<ProductoEstablecimientoTB> Get(long Id)
        {
            var result = DalService.Get<ProductoEstablecimientoTB>(Id);
            return result;
        }

        public async Task<ProductoEstablecimientoTB> Save(ProductoEstablecimientoTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<ProductoEstablecimientoTB> Delete(long Id)
        {
            var data = DalService.Delete<ProductoEstablecimientoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<ProductoEstablecimientoTB>(); }
            catch { }return 0;
        }
    }

}
