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
                model.FromDate = model.FromDate != null ? new DateTime(model.FromDate.Value.Year, model.FromDate.Value.Month, model.FromDate.Value.Day,0,0,0) : model.FromDate;
                model.ToDate = model.ToDate != null ? new DateTime(model.ToDate.Value.Year, model.ToDate.Value.Month, model.ToDate.Value.Day, 23, 59, 59) : model.ToDate;

                model.Ldata = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter)  || data.LicenseNumber.Contains(model.Filter) || (data.Establecimiento != null && data.Establecimiento.Nombre.Contains(model.Filter)) || (data.InspRetiroRetencion != null && data.InspRetiroRetencion.SeccionOficinaRegional.Contains(model.Filter)))) &&
                               (model.TipoActa != DataModel.Helper.enumAUD_TipoActa.None ? data.TipoActa == model.TipoActa : true) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None? data.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.FromDate !=null? data.FechaInicio >= model.FromDate:true) &&
                               (model.ToDate != null ? data.FechaInicio <= model.ToDate : true)
                               orderby data.FechaInicio
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter) || data.LicenseNumber.Contains(model.Filter) || (data.Establecimiento != null && data.Establecimiento.Nombre.Contains(model.Filter)) || (data.InspRetiroRetencion != null && data.InspRetiroRetencion.SeccionOficinaRegional.Contains(model.Filter)))) &&
                               (model.TipoActa != DataModel.Helper.enumAUD_TipoActa.None ? data.TipoActa == model.TipoActa : true) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None ? data.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.FromDate != null ? data.FechaInicio >= model.FromDate : true) &&
                               (model.ToDate != null ? data.FechaInicio <= model.ToDate : true)
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
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"),DateTime.Now.ToString("yyyy"),data.TipoActa.ToString(),data.Establecimiento?.TipoEstablecimiento.ToString()??"NA",data.Establecimiento?.Provincia?.Codigo??"0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
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
                var startDate = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                var endDate = new DateTime(startDate.Year, 12, 31, 23, 59, 59);

                return ((from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                        where data.CreatedDate >= startDate && data.CreatedDate <= endDate
                        select data).Max(x=>x.IntNumActa));
            }
            catch { }
            return 0;
        }
    }

}
