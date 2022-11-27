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
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter)  || data.LicenseNumber.Contains(model.Filter) || (data.Establecimiento != null && data.Establecimiento.Nombre.Contains(model.Filter)))) &&
                               (model.TipoActa != DataModel.Helper.enumAUD_TipoActa.None ? data.TipoActa == model.TipoActa : true) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None? data.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.FromDate !=null? data.FechaInicio >= model.FromDate:true) &&
                               (model.ToDate != null ? data.FechaInicio <= model.ToDate : true)
                               orderby data.FechaInicio
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                               where data.Deleted == false &&
                                (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter) || data.LicenseNumber.Contains(model.Filter) || (data.Establecimiento != null && data.Establecimiento.Nombre.Contains(model.Filter)))) &&
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
            if(result != null)
            {
                if (result.InspRetiroRetencion != null)
                {
                    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosAtendidosPor).IsModified = true;

                    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspAperCambUbicFarm != null)
                {
                    //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosSolicitante).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosEstructuraOrganizacional).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosInfraEstructura).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaFisica).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosPreguntasGenericas).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosSenalizacionAvisos).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaProductosControlados).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaAlmacenamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAtendidosPor).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspAperCambUbicAgen != null)
                {
                    //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosSolicitante).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosCondicionesLocal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosAtendidosPor).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosActProd).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspAperFabricante != null)
                {
                    //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosSolicitante).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosDocumentacion).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosProcedimientoPrograma).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAutoInspeccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosProdAnalisisContrato).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosReclamoProductoRetirado).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosLocal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaProduccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosEquipos).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaLabCtrCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaAlmacenamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaAuxiliares).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspRutinaVigFarmacia != null)
                {
                    //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;                    
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosGeneralesFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosFarmaceutico).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosPersonalTecnico).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosExpedienteColaborador).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosEstructuraFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosEquipoRegistroFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosAnuncioFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRegMovimientoExistenciaFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosAlmacenProductosFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosProcedimientoFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
            }
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
