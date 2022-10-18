using DataAccess.Auditoria;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Aig.Auditoria.Services
{    
    public class InspectionsService : IInspectionsService
    {
        private readonly IDalService DalService;
        public InspectionsService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_InspeccionTB>> FindAll(GenericModel<AUD_InspeccionTB> model)
        {
            try
            {
                var result = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Establecimiento!=null && (data.Establecimiento.Nombre.Contains(model.Filter))))
                              orderby data.FechaInicio
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                var count = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                             where data.Deleted == false &&
                             (string.IsNullOrEmpty(model.Filter) ? true : (data.Establecimiento != null && (data.Establecimiento.Nombre.Contains(model.Filter))))
                             select data).Count();

                return new GenericModel<AUD_InspeccionTB>() { Ldata = result, Total = count };
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<List<AUD_InspeccionTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_InspeccionTB> Get(long Id)
        {
            var result = DalService.Get<AUD_InspeccionTB>(Id);
            return result;
        }

        public async Task<AUD_InspeccionTB> Save(AUD_InspeccionTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<AUD_InspeccionTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_InspeccionTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_InspeccionTB>(); }
            catch { }return 0;
        }
    }

}
