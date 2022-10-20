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
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter) || (data.Establecimiento != null && data.Establecimiento.Nombre.Contains(model.Filter))))
                               orderby data.FechaInicio
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter) || (data.Establecimiento != null && data.Establecimiento.Nombre.Contains(model.Filter))))
                               select data).Count();

            }
            catch (Exception ex)
            { }

            return model;
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
            //generar el numero de acta
            if(string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

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

        //retrona el numero de acta maximo
        private int GetMaxInspectionActNumber()
        {
            try {
                var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                var endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 23, 59, 59);

                return ((from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                        where data.CreatedDate >= startDate && data.CreatedDate <= endDate
                        select data).Max(x=>x.IntNumActa));
            }
            catch { }
            return 0;
        }
    }

}
