using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IProductoEstablecimientoService
    {
        Task<GenericModel<ProductoEstablecimientoTB>> FindAll(GenericModel<ProductoEstablecimientoTB> model);
        Task<List<ProductoEstablecimientoTB>> GetAll();
        Task<ProductoEstablecimientoTB> Get(long id);
        Task<ProductoEstablecimientoTB> Save(ProductoEstablecimientoTB data);
        Task<ProductoEstablecimientoTB> Delete(long id);
        Task<int> Count();
    }

   
}
