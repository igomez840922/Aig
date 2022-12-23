using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class ActividadEstablecimientoService : IActividadEstablecimientoService
    {
        private readonly IDalService DalService;
        public ActividadEstablecimientoService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<ActividadEstablecimientoTB>> FindAll(GenericModel<ActividadEstablecimientoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<ActividadEstablecimientoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<ActividadEstablecimientoTB>()
                             where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<ActividadEstablecimientoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<ActividadEstablecimientoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<ActividadEstablecimientoTB> Get(long Id)
        {
            var result = DalService.Get<ActividadEstablecimientoTB>(Id);
            return result;
        }

        public async Task<ActividadEstablecimientoTB> Save(ActividadEstablecimientoTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<ActividadEstablecimientoTB> Delete(long Id)
        {
            var data = DalService.Delete<ActividadEstablecimientoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<ActividadEstablecimientoTB>(); }
            catch { }return 0;
        }
    }

}
