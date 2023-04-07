using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using ClosedXML.Excel;
using DataModel.Helper;
using Aig.Auditoria.Pages.Inspections;
using Duende.IdentityServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Aig.Auditoria.Services
{    
    public class InspectionsService : IInspectionsService
    {
        private readonly IDalService DalService;
        //private DalService DalService;
        public InspectionsService(IDalService dalService, IConfiguration config)
        {
            //DalService = new DalService(new ApplicationDbContext(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")),)); 
            DalService = dalService;
            //DalService.DBContext.de
        }

        public async Task<GenericModel<InspeccionDTO>> BandejaEntrada(GenericModel<InspeccionDTO> model) {
            try {
                model.Ldata = null; model.Total = 0;
                model.FromDate = model.FromDate != null ? new DateTime(model.FromDate.Value.Year, model.FromDate.Value.Month, model.FromDate.Value.Day, 0, 0, 0) : model.FromDate;
                model.ToDate = model.ToDate != null ? new DateTime(model.ToDate.Value.Year, model.ToDate.Value.Month, model.ToDate.Value.Day, 23, 59, 59) : model.ToDate;

                model.Ldata = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter) || data.LicenseNumber.Contains(model.Filter) || data.DatosEstablecimiento.NumLicencia.Contains(model.Filter) || data.DatosEstablecimiento.ReciboPago.Contains(model.Filter) || data.DatosEstablecimiento.AvisoOperaciones.Contains(model.Filter) || data.DatosEstablecimiento.Nombre.Contains(model.Filter) || (data.Establecimiento != null && (data.Establecimiento.Nombre.Contains(model.Filter) || data.Establecimiento.ReciboPago.Contains(model.Filter) || data.Establecimiento.NumLicencia.Contains(model.Filter) || data.Establecimiento.AvisoOperaciones.Contains(model.Filter))))) &&
                               (model.TipoActa != DataModel.Helper.enumAUD_TipoActa.None ? data.TipoActa == model.TipoActa : true) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None ? data.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.ProvinceId != null ? data.DatosEstablecimiento.ProvinciaId == model.ProvinceId : true) &&
                               (model.FromDate != null ? data.FechaInicio >= model.FromDate : true) &&
                               (model.ToDate != null ? data.FechaInicio <= model.ToDate : true)
                               orderby data.FechaInicio
                               select new InspeccionDTO {
                                   Id = data.Id,
                                   NumActa = data.NumActa,
                                   TipoActa = data.TipoActa,
                                   FechaInicio = data.FechaInicio,
                                   StatusInspecciones = data.StatusInspecciones,
                                   NumLicencia = data.DatosEstablecimiento.NumLicencia,
                                   ReciboPago = data.DatosEstablecimiento.ReciboPago,
                                   AvisoOperaciones = data.DatosEstablecimiento.AvisoOperaciones,
                                   Nombre = data.DatosEstablecimiento.Nombre ,
                                   ProvinciaId = data.DatosEstablecimiento.ProvinciaId,
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter) || data.LicenseNumber.Contains(model.Filter) || data.DatosEstablecimiento.NumLicencia.Contains(model.Filter) || data.DatosEstablecimiento.ReciboPago.Contains(model.Filter) || data.DatosEstablecimiento.AvisoOperaciones.Contains(model.Filter) || data.DatosEstablecimiento.Nombre.Contains(model.Filter) || (data.Establecimiento != null && (data.Establecimiento.Nombre.Contains(model.Filter) || data.Establecimiento.ReciboPago.Contains(model.Filter) || data.Establecimiento.NumLicencia.Contains(model.Filter) || data.Establecimiento.AvisoOperaciones.Contains(model.Filter))))) &&
                               (model.TipoActa != DataModel.Helper.enumAUD_TipoActa.None ? data.TipoActa == model.TipoActa : true) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None ? data.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.ProvinceId != null ? data.DatosEstablecimiento.ProvinciaId == model.ProvinceId : true) &&
                               (model.FromDate != null ? data.FechaInicio >= model.FromDate : true) &&
                               (model.ToDate != null ? data.FechaInicio <= model.ToDate : true)
                               select data).Count();

            }
            catch (Exception ex) { }

            return model;
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
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter) || data.LicenseNumber.Contains(model.Filter) || data.DatosEstablecimiento.NumLicencia.Contains(model.Filter) || data.DatosEstablecimiento.ReciboPago.Contains(model.Filter) || data.DatosEstablecimiento.AvisoOperaciones.Contains(model.Filter) || data.DatosEstablecimiento.Nombre.Contains(model.Filter) || (data.Establecimiento != null && (data.Establecimiento.Nombre.Contains(model.Filter) || data.Establecimiento.ReciboPago.Contains(model.Filter) || data.Establecimiento.NumLicencia.Contains(model.Filter) || data.Establecimiento.AvisoOperaciones.Contains(model.Filter))))) &&
                               (model.TipoActa != DataModel.Helper.enumAUD_TipoActa.None ? data.TipoActa == model.TipoActa : true) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None? data.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.ProvinceId != null ? data.DatosEstablecimiento.ProvinciaId == model.ProvinceId : true) &&
                               (model.FromDate !=null? data.FechaInicio >= model.FromDate:true) &&
                               (model.ToDate != null ? data.FechaInicio <= model.ToDate : true)
                               orderby data.FechaInicio
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter) || data.LicenseNumber.Contains(model.Filter) || data.DatosEstablecimiento.NumLicencia.Contains(model.Filter) || data.DatosEstablecimiento.ReciboPago.Contains(model.Filter) || data.DatosEstablecimiento.AvisoOperaciones.Contains(model.Filter) || data.DatosEstablecimiento.Nombre.Contains(model.Filter) || (data.Establecimiento != null && (data.Establecimiento.Nombre.Contains(model.Filter) || data.Establecimiento.ReciboPago.Contains(model.Filter) || data.Establecimiento.NumLicencia.Contains(model.Filter) || data.Establecimiento.AvisoOperaciones.Contains(model.Filter))))) &&
                               (model.TipoActa != DataModel.Helper.enumAUD_TipoActa.None ? data.TipoActa == model.TipoActa : true) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None ? data.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.ProvinceId != null ? data.DatosEstablecimiento.ProvinciaId == model.ProvinceId : true) &&
                               (model.FromDate != null ? data.FechaInicio >= model.FromDate : true) &&
                               (model.ToDate != null ? data.FechaInicio <= model.ToDate : true)
                               select data).Count();

            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<InspeccionDTO> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;

                var Ldata = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter) || data.LicenseNumber.Contains(model.Filter) || (data.Establecimiento != null && (data.Establecimiento.Nombre.Contains(model.Filter) || data.Establecimiento.ReciboPago.Contains(model.Filter) || data.Establecimiento.NumLicencia.Contains(model.Filter) || data.Establecimiento.AvisoOperaciones.Contains(model.Filter))))) &&
                               (model.TipoActa != DataModel.Helper.enumAUD_TipoActa.None ? data.TipoActa == model.TipoActa : true) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None ? data.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.ProvinceId != null ? data.DatosEstablecimiento.ProvinciaId == model.ProvinceId : true) &&
                               (model.FromDate != null ? data.FechaInicio >= model.FromDate : true) &&
                               (model.ToDate != null ? data.FechaInicio <= model.ToDate : true)
                               orderby data.FechaInicio
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();


                if (Ldata?.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "Inspeccion";
                    wb.Properties.Title = "Inspeccion";
                    wb.Properties.Subject = "Inspeccion";

                    var ws = wb.Worksheets.Add("Inspeccion");

                    ws.Cell(1, 1).Value = "Número de Acta";
                    ws.Cell(1, 2).Value = "Tipo de Inspección";
                    ws.Cell(1, 3).Value = "Estatus";
                    ws.Cell(1, 4).Value = "Fecha del Acta";
                    ws.Cell(1, 5).Value = "Número de Licencia";
                    ws.Cell(1, 6).Value = "Aviso de Operaciones";
                    ws.Cell(1, 7).Value = "Establecimientos";

                    for (int row = 1; row <= Ldata.Count; row++)
                    {
                        var prod = Ldata[row - 1];

                        ws.Cell(row + 1, 1).Value = prod.NumActa;
                        ws.Cell(row + 1, 2).Value = DataModel.Helper.Helper.GetDescription(prod.TipoActa);
                        ws.Cell(row + 1, 3).Value = DataModel.Helper.Helper.GetDescription(prod.StatusInspecciones);
                        ws.Cell(row + 1, 4).Value = prod.FechaInicio.ToString("dd/MM/yyyy hh:mm tt");
                        ws.Cell(row + 1, 5).Value = prod.LicenseNumber;
                        ws.Cell(row + 1, 6).Value = prod.AvisoOperacion;
                        ws.Cell(row + 1, 7).Value = prod.Establecimiento?.Nombre ?? "";
                    }

                    MemoryStream XLSStream = new();
                    wb.SaveAs(XLSStream);

                    return XLSStream;
                }
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
            var result = DalService.GetReloaded<AUD_InspeccionTB>(Id);                        

            return result;
        }

        public async Task<AUD_InspeccionTB> Save(AUD_InspeccionTB data)
        {
            //generar el numero de acta
            if(string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"),DateTime.Now.ToString("yyyy"),data.TipoActa.ToString(),data.Establecimiento?.TipoEstablecimiento.ToString()??"NA",data.DatosEstablecimiento?.Provincia?.Codigo??"0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if(result != null)
            {
                //if (result.DatosEstablecimiento != null) {
                //    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Establecimiento).IsModified = true;
                //    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Provincia).IsModified = true;
                //    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Distrito).IsModified = true;
                //    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Corregimiento).IsModified = true;
                //}
                //if (result.InspAperFabricanteCosmetMed != null) {
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.DatosRegente).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.ProdFabrican).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.EstructuraOrganizativa).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.Almacenes).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.Documantacion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.AreasAuxiliares).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.SistemaCriticoApoyo).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.AreaProduccion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.Acondicionamiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.ControlCalidad).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.InspeccionAuditoria).IsModified = true;
                //}
                //if (result.InspGuiaBPM_Bpa != null) {
                //    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.DatosRegente).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.OtrosFuncionarios).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.PropositoInsp).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.DispGenerlestablecimiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.AreasEstablecimiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.Distribucion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.TransProdFarmaceuticos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.AutoInspec).IsModified = true;
                //}
                //if (result.InspGuiaBPMLabAcondicionador != null) {
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.DatosRegente).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.OtrosFuncionarios).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.RequisitosLegales).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ClasifActComerciales).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ClasifEstablecimiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.OrganizacionPersonal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.EdifInstalaciones).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.Almacenes).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.AreaAcondicionamiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.EquiposGeneralidades).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.MatProducts).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.Documentacion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.Acondicionamiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.GarantiaCalidad).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ControlCalidad).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ProdAnalisisContrato).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ValGenerales).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.QuejasReclamos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.AutoInspecAuditCal).IsModified = true;

                //}
                //if (result.InspGuiaBPMFabricanteMed != null) {
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.DatosRegente).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.OtrosFuncionarios).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.RequisitosLegales).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ClasifActComerciales).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ClasifEstablecimiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.OrganizacionPersonal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.EdifInstalaciones).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Almacenes).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AreaDispMatPrima).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AreaProduccion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AreaAcondicionamiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.EquiposGeneralidades).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Equipos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.MatProducts).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Documentacion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Produccion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.GarantiaCalidad).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ControlCalidad).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ProdAnalisisContrato).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ValGenerales).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.QuejasReclamos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AutoInspecAuditCal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_A).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_Gen).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_A2).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_A3).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Lactamicos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ProdCitostatico).IsModified = true;
                //}
                //if (result.InspDisposicionFinal != null) {
                //    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosAtendidosPor).IsModified = true;
                //    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosInspeccion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.InventarioMedicamento).IsModified = true;
                //}
                //if (result.InspRutinaVigAgencia != null) {
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosRegente).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.CondCaractEstablecimiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAdministrativa).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaRecepcionProducto).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenamiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaProductosDevueltosVencidos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaProductosRetiradosMercado).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaDespachoProductos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenProdReqCadenaFrio).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenProdVolatiles).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenPlaguicidas).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenMateriaPrima).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenProdSujetosControl).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Procedimientos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Transporte).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Actividades).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Productos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.InventarioMedicamento).IsModified = true;

                //}
                //if (result.InspAperturaCosmetArtesanal != null) {
                //    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.Documentacion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.Locales).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.AreaAlmacenamiento).IsModified = true;
                //}
                //if (result.InspGuiBPMFabCosmeticoMed != null) {
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.DatosRegente).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.OtrosFuncionarios).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RequisitosLegales).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ClasifActComerciales).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ClasifEstablecimiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AdminInfoGeneral).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.CondExtAlmacenas).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.CondIntAlmacenas).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaRecepMateriaPrima).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AlmacenMateriaPrima).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AlmacenMatAcondicionamineto).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RecepProductoTerminado).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AlmacenProductoTerminado).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ProductoDevueltoRechazado).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.DistProductoTerminado).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ManejoQuejaReclamos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RetiroProcMercado).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.SistemaInstAgua).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.OsmosisInversa).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.SistemaDeIonizacion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.CalibraVerifEquipo).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.Validaciones).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.MantAreaEquipos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaProdCondExternas).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaProdCondInternas).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaOrganizaDocumentacion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaDispensionOrdFab).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.FabProdDesinfectante).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.FabPlaguicida).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.FabCosmeticos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaEnvasado).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaEtiquetadoEmpaque).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.LabControlCalidad).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AnalisisContrato).IsModified = true;
                //    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.InspeccionAudito).IsModified = true;

                //}
                //if (result.InspInvestigacion != null) {
                //    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DatosAtendidosPor).IsModified = true;
                //    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DetallesInvestigacion).IsModified = true;
                //}
                //if (result.InspRetiroRetencion != null) {
                //    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosAtendidosPor).IsModified = true;

                //}
                //if (result.InspAperCambUbicFarm != null) {
                //    ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosEstablecimiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosSolicitante).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosRegente).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosEstructuraOrganizacional).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosInfraEstructura).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaFisica).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosPreguntasGenericas).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosSenalizacionAvisos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaProductosControlados).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaAlmacenamiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosConclusiones).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAtendidosPor).IsModified = true;
                //}
                //if (result.InspAperCambUbicAgen != null) {
                //    ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosSolicitante).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosRegente).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.CondCaractEstablecimiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAdministrativa).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaRecepcionProducto).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenamiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaProductosDevueltosVencidos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaProductosRetiradosMercado).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaDespachoProductos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenProdReqCadenaFrio).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenProdVolatiles).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenPlaguicidas).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenMateriaPrima).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenProdSujetosControl).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaDesperdicio).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.Requisitos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.Actividades).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.Productos).IsModified = true;
                //}
                //if (result.InspAperFabricante != null) {
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosRegente).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.ProdFabrican).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.Personal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.Instalaciones).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaAlmacenamiento).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaDispMateriaPrima).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaProduccion).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaAcondSecundario).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.ControlCalidad).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaAuxiliares).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.Equipos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.MaterialesProductos).IsModified = true;
                //}
                //if (result.InspRutinaVigFarmacia != null) {
                //    ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRegente).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosFarmaceutico).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.ExpPersonalFarmacia).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.EstructOrganizFarmacia).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.EstructFarmacia).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.AreaFisicaFarmacia).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.AreaProdControlados).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.RegMovimientoExistencia).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.AreaAlmacenMedicamentos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.Procedimientos).IsModified = true;
                //    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.InventarioMedicamento).IsModified = true;
                //}
                //if (result.InspCierreOperacion != null) {
                //    ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                //    DalService.DBContext.Entry(result.InspCierreOperacion).Property(b => b.DatosRepresentLegal).IsModified = true;
                //    DalService.DBContext.Entry(result.InspCierreOperacion).Property(b => b.DatosInspeccion).IsModified = true;
                //}

                //DalService.DBContext.SaveChanges();

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


        ///// Cambios para el trabajo por Capitulos///
        ///
        public async Task<AUD_InspeccionTB> Save_GeneralData(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.DatosEstablecimiento = inspeccion.DatosEstablecimiento;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;
            if (data.DatosEstablecimiento != null)
            {
                data.DatosEstablecimiento.ProvinciaId = inspeccion.DatosEstablecimiento?.Provincia?.Id;
            }

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.DatosEstablecimiento != null)
                {
                    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Establecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Provincia).IsModified = true;
                    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Distrito).IsModified = true;
                    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Corregimiento).IsModified = true;
                }
                
                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_Conclusiones(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.DatosConclusiones = inspeccion.DatosConclusiones;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.DatosConclusiones).IsModified = true;

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicFarm.DatosSolicitante = inspeccion.InspAperCambUbicFarm.DatosSolicitante;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicFarm != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosSolicitante).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicFarm.DatosRegente = inspeccion.InspAperCambUbicFarm.DatosRegente;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicFarm != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicFarm.DatosEstructuraOrganizacional = inspeccion.InspAperCambUbicFarm.DatosEstructuraOrganizacional;
            data.InspAperCambUbicFarm.HorariosAtencion = inspeccion.InspAperCambUbicFarm.HorariosAtencion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicFarm != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosEstructuraOrganizacional).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.HorariosAtencion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicFarm.DatosInfraEstructura = inspeccion.InspAperCambUbicFarm.DatosInfraEstructura;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicFarm != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosInfraEstructura).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicFarm.DatosAreaFisica = inspeccion.InspAperCambUbicFarm.DatosAreaFisica;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicFarm != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaFisica).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicFarm.DatosPreguntasGenericas = inspeccion.InspAperCambUbicFarm.DatosPreguntasGenericas;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicFarm != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosPreguntasGenericas).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicFarm.DatosAreaProductosControlados = inspeccion.InspAperCambUbicFarm.DatosAreaProductosControlados;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicFarm != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaProductosControlados).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicFarm.DatosAreaAlmacenamiento = inspeccion.InspAperCambUbicFarm.DatosAreaAlmacenamiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicFarm != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaAlmacenamiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicFarmacia_Frima(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicFarm.DatosSolicitante = inspeccion.InspAperCambUbicFarm.DatosSolicitante;
            data.InspAperCambUbicFarm.DatosRegente = inspeccion.InspAperCambUbicFarm.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspAperCambUbicFarm != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosSolicitante).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.DatosSolicitante = inspeccion.InspAperCambUbicAgen.DatosSolicitante;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosSolicitante).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap3(AUD_InspeccionTB inspeccion)   
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.DatosRegente = inspeccion.InspAperCambUbicAgen.DatosRegente;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.CondCaractEstablecimiento = inspeccion.InspAperCambUbicAgen.CondCaractEstablecimiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.CondCaractEstablecimiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaAdministrativa = inspeccion.InspAperCambUbicAgen.AreaAdministrativa;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAdministrativa).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaRecepcionProducto = inspeccion.InspAperCambUbicAgen.AreaRecepcionProducto;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaRecepcionProducto).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaAlmacenamiento = inspeccion.InspAperCambUbicAgen.AreaAlmacenamiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenamiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaProductosDevueltosVencidos = inspeccion.InspAperCambUbicAgen.AreaProductosDevueltosVencidos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaProductosDevueltosVencidos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaProductosRetiradosMercado = inspeccion.InspAperCambUbicAgen.AreaProductosRetiradosMercado;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaProductosRetiradosMercado).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap10(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaDespachoProductos = inspeccion.InspAperCambUbicAgen.AreaDespachoProductos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaDespachoProductos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap11(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaAlmacenProdReqCadenaFrio = inspeccion.InspAperCambUbicAgen.AreaAlmacenProdReqCadenaFrio;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenProdReqCadenaFrio).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap12(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaAlmacenProdVolatiles = inspeccion.InspAperCambUbicAgen.AreaAlmacenProdVolatiles;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenProdVolatiles).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap13(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaAlmacenPlaguicidas = inspeccion.InspAperCambUbicAgen.AreaAlmacenPlaguicidas;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenPlaguicidas).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap14(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaAlmacenMateriaPrima = inspeccion.InspAperCambUbicAgen.AreaAlmacenMateriaPrima;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenMateriaPrima).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap15(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaAlmacenProdSujetosControl = inspeccion.InspAperCambUbicAgen.AreaAlmacenProdSujetosControl;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenProdSujetosControl).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap16(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.AreaDesperdicio = inspeccion.InspAperCambUbicAgen.AreaDesperdicio;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaDesperdicio).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap17(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.Requisitos = inspeccion.InspAperCambUbicAgen.Requisitos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.Requisitos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap18(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.Actividades = inspeccion.InspAperCambUbicAgen.Actividades;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.Actividades).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Cap19(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.Productos = inspeccion.InspAperCambUbicAgen.Productos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.Productos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperCamUbicAgencia_Frima(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperCambUbicAgen.DatosSolicitante = inspeccion.InspAperCambUbicAgen.DatosSolicitante;
            data.InspAperCambUbicAgen.DatosRegente = inspeccion.InspAperCambUbicAgen.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspAperCambUbicAgen != null)
                {
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosSolicitante).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        
        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.DatosRepresentLegal = inspeccion.InspRutinaVigFarmacia.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.DatosRegente = inspeccion.InspRutinaVigFarmacia.DatosRegente;
            data.InspRutinaVigFarmacia.DatosFarmaceutico = inspeccion.InspRutinaVigFarmacia.DatosFarmaceutico;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosFarmaceutico).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.ExpPersonalFarmacia = inspeccion.InspRutinaVigFarmacia.ExpPersonalFarmacia;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.ExpPersonalFarmacia).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.EstructOrganizFarmacia = inspeccion.InspRutinaVigFarmacia.EstructOrganizFarmacia;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.EstructOrganizFarmacia).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.EstructFarmacia = inspeccion.InspRutinaVigFarmacia.EstructFarmacia;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.EstructFarmacia).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.AreaFisicaFarmacia = inspeccion.InspRutinaVigFarmacia.AreaFisicaFarmacia;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.AreaFisicaFarmacia).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.AreaProdControlados = inspeccion.InspRutinaVigFarmacia.AreaProdControlados;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.AreaProdControlados).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.RegMovimientoExistencia = inspeccion.InspRutinaVigFarmacia.RegMovimientoExistencia;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.RegMovimientoExistencia).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap10(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.AreaAlmacenMedicamentos = inspeccion.InspRutinaVigFarmacia.AreaAlmacenMedicamentos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.AreaAlmacenMedicamentos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap11(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.Procedimientos = inspeccion.InspRutinaVigFarmacia.Procedimientos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.Procedimientos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Cap12(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.InventarioMedicamento = inspeccion.InspRutinaVigFarmacia.InventarioMedicamento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.InventarioMedicamento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaFarmacia_Frima(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigFarmacia.DatosRepresentLegal = inspeccion.InspRutinaVigFarmacia.DatosRepresentLegal;
            data.InspRutinaVigFarmacia.DatosRegente = inspeccion.InspRutinaVigFarmacia.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspRutinaVigFarmacia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.DatosRepresentLegal = inspeccion.InspRutinaVigAgencia.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.DatosRegente = inspeccion.InspRutinaVigAgencia.DatosRegente;
            //data.InspRutinaVigAgencia.DatosFarmaceutico = inspeccion.InspRutinaVigAgencia.DatosFarmaceutico;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosRegente).IsModified = true;
                    //DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosFarmaceutico).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.CondCaractEstablecimiento = inspeccion.InspRutinaVigAgencia.CondCaractEstablecimiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.CondCaractEstablecimiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaAdministrativa = inspeccion.InspRutinaVigAgencia.AreaAdministrativa;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAdministrativa).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaRecepcionProducto = inspeccion.InspRutinaVigAgencia.AreaRecepcionProducto;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaRecepcionProducto).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaAlmacenamiento = inspeccion.InspRutinaVigAgencia.AreaAlmacenamiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenamiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaProductosDevueltosVencidos = inspeccion.InspRutinaVigAgencia.AreaProductosDevueltosVencidos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaProductosDevueltosVencidos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaProductosRetiradosMercado = inspeccion.InspRutinaVigAgencia.AreaProductosRetiradosMercado;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaProductosRetiradosMercado).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap10(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaDespachoProductos = inspeccion.InspRutinaVigAgencia.AreaDespachoProductos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaDespachoProductos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap11(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaAlmacenProdReqCadenaFrio = inspeccion.InspRutinaVigAgencia.AreaAlmacenProdReqCadenaFrio;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenProdReqCadenaFrio).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap12(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaAlmacenProdVolatiles = inspeccion.InspRutinaVigAgencia.AreaAlmacenProdVolatiles;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenProdVolatiles).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap13(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaAlmacenPlaguicidas = inspeccion.InspRutinaVigAgencia.AreaAlmacenPlaguicidas;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenPlaguicidas).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap14(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaAlmacenMateriaPrima = inspeccion.InspRutinaVigAgencia.AreaAlmacenMateriaPrima;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenMateriaPrima).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap15(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.AreaAlmacenProdSujetosControl = inspeccion.InspRutinaVigAgencia.AreaAlmacenProdSujetosControl;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenProdSujetosControl).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap16(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.Procedimientos = inspeccion.InspRutinaVigAgencia.Procedimientos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Procedimientos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap17(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.Transporte = inspeccion.InspRutinaVigAgencia.Transporte;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Transporte).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap18(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.Actividades = inspeccion.InspRutinaVigAgencia.Actividades;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Actividades).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap19(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.Productos = inspeccion.InspRutinaVigAgencia.Productos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Productos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Cap20(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.InventarioMedicamento = inspeccion.InspRutinaVigAgencia.InventarioMedicamento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.InventarioMedicamento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RutinaVigilanciaAgencia_Frima(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRutinaVigAgencia.DatosRepresentLegal = inspeccion.InspRutinaVigAgencia.DatosRepresentLegal;
            data.InspRutinaVigAgencia.DatosRegente = inspeccion.InspRutinaVigAgencia.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_Investigaciones_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspInvestigacion.DatosAtendidosPor = inspeccion.InspInvestigacion.DatosAtendidosPor;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspInvestigacion != null)
                {
                    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DatosAtendidosPor).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_Investigaciones_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspInvestigacion.DetallesInvestigacion = inspeccion.InspInvestigacion.DetallesInvestigacion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspInvestigacion != null)
                {
                    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DetallesInvestigacion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_Investigaciones_Frima(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspInvestigacion.DatosAtendidosPor = inspeccion.InspInvestigacion.DatosAtendidosPor;
            //data.InspInvestigacion.DatosRegente = inspeccion.InspInvestigacion.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspInvestigacion != null)
                {
                    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DatosAtendidosPor).IsModified = true;
                    //DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
                public async Task<AUD_InspeccionTB> Save_RetiroRetencion_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRetiroRetencion.DatosRepresentLegal = inspeccion.InspRetiroRetencion.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRetiroRetencion != null)
                {
                    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RetiroRetencion_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRetiroRetencion.DatosAtendidosPor = inspeccion.InspRetiroRetencion.DatosAtendidosPor;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspRetiroRetencion != null)
                {
                    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosAtendidosPor).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RetiroRetencion_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRetiroRetencion.RetiroRetencionType = inspeccion.InspRetiroRetencion.RetiroRetencionType;
            data.InspRetiroRetencion.LProductos = inspeccion.InspRetiroRetencion.LProductos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_RetiroRetencion_Frima(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspRetiroRetencion.DatosAtendidosPor = inspeccion.InspRetiroRetencion.DatosAtendidosPor;
            data.InspRetiroRetencion.DatosRepresentLegal = inspeccion.InspRetiroRetencion.DatosRepresentLegal;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspRetiroRetencion != null)
                {
                    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosAtendidosPor).IsModified = true;
                    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_CierreOperacion_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspCierreOperacion.DatosRepresentLegal = inspeccion.InspCierreOperacion.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspCierreOperacion != null)
                {
                    DalService.DBContext.Entry(result.InspCierreOperacion).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_CierreOperacion_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspCierreOperacion.DatosInspeccion = inspeccion.InspCierreOperacion.DatosInspeccion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspCierreOperacion != null)
                {
                    DalService.DBContext.Entry(result.InspCierreOperacion).Property(b => b.DatosInspeccion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_CierreOperacion_Frima(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspCierreOperacion.DatosRepresentLegal = inspeccion.InspCierreOperacion.DatosRepresentLegal;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspCierreOperacion != null)
                {
                    DalService.DBContext.Entry(result.InspCierreOperacion).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        
        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_DisposicionFinal_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspDisposicionFinal.DatosAtendidosPor = inspeccion.InspDisposicionFinal.DatosAtendidosPor;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspDisposicionFinal != null)
                {
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosAtendidosPor).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_DisposicionFinal_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspDisposicionFinal.DatosInspeccion = inspeccion.InspDisposicionFinal.DatosInspeccion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspDisposicionFinal != null)
                {
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosInspeccion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_DisposicionFinal_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspDisposicionFinal.InventarioMedicamento = inspeccion.InspDisposicionFinal.InventarioMedicamento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspDisposicionFinal != null)
                {
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.InventarioMedicamento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_DisposicionFinal_Firma(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspDisposicionFinal.DatosAtendidosPor = inspeccion.InspDisposicionFinal.DatosAtendidosPor;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspDisposicionFinal != null)
                {
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosAtendidosPor).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.DatosRepresentLegal = inspeccion.InspAperFabricante.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.DatosRegente = inspeccion.InspAperFabricante.DatosRegente;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.ProdFabrican = inspeccion.InspAperFabricante.ProdFabrican;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.ProdFabrican).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.Personal = inspeccion.InspAperFabricante.Personal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.Personal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.Instalaciones = inspeccion.InspAperFabricante.Instalaciones;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.Instalaciones).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.AreaAlmacenamiento = inspeccion.InspAperFabricante.AreaAlmacenamiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaAlmacenamiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.AreaDispMateriaPrima = inspeccion.InspAperFabricante.AreaDispMateriaPrima;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaDispMateriaPrima).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.AreaProduccion = inspeccion.InspAperFabricante.AreaProduccion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaProduccion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap10(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.AreaAcondSecundario = inspeccion.InspAperFabricante.AreaAcondSecundario;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaAcondSecundario).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap11(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.ControlCalidad = inspeccion.InspAperFabricante.ControlCalidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.ControlCalidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap12(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.AreaAuxiliares = inspeccion.InspAperFabricante.AreaAuxiliares;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaAuxiliares).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap13(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.Equipos = inspeccion.InspAperFabricante.Equipos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.Equipos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Cap14(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.MaterialesProductos = inspeccion.InspAperFabricante.MaterialesProductos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.MaterialesProductos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteMedicamento_Firma(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricante.DatosRepresentLegal = inspeccion.InspAperFabricante.DatosRepresentLegal;
            data.InspAperFabricante.DatosRegente = inspeccion.InspAperFabricante.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.DatosRepresentLegal = inspeccion.InspAperFabricanteCosmetMed.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.DatosRegente = inspeccion.InspAperFabricanteCosmetMed.DatosRegente;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.ProdFabrican = inspeccion.InspAperFabricanteCosmetMed.ProdFabrican;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.ProdFabrican).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.EstructuraOrganizativa = inspeccion.InspAperFabricanteCosmetMed.EstructuraOrganizativa;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.EstructuraOrganizativa).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.Almacenes = inspeccion.InspAperFabricanteCosmetMed.Almacenes;
            data.InspAperFabricanteCosmetMed.Almacenes2 = inspeccion.InspAperFabricanteCosmetMed.Almacenes2;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.Almacenes).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.Almacenes2).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.Documantacion = inspeccion.InspAperFabricanteCosmetMed.Documantacion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.Documantacion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.AreasAuxiliares = inspeccion.InspAperFabricanteCosmetMed.AreasAuxiliares;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.AreasAuxiliares).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.SistemaCriticoApoyo = inspeccion.InspAperFabricanteCosmetMed.SistemaCriticoApoyo;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.SistemaCriticoApoyo).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap10(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.AreaProduccion = inspeccion.InspAperFabricanteCosmetMed.AreaProduccion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.AreaProduccion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap11(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.Acondicionamiento = inspeccion.InspAperFabricanteCosmetMed.Acondicionamiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.Acondicionamiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap12(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.ControlCalidad = inspeccion.InspAperFabricanteCosmetMed.ControlCalidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.ControlCalidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Cap13(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.InspeccionAuditoria = inspeccion.InspAperFabricanteCosmetMed.InspeccionAuditoria;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.InspeccionAuditoria).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperFabricanteCosmeticosDesin_Firma(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperFabricanteCosmetMed.DatosRepresentLegal = inspeccion.InspAperFabricanteCosmetMed.DatosRepresentLegal;
            data.InspAperFabricanteCosmetMed.DatosRegente = inspeccion.InspAperFabricanteCosmetMed.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.DatosRepresentLegal = inspeccion.InspGuiaBPMFabricanteMed.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.DatosRegente = inspeccion.InspGuiaBPMFabricanteMed.DatosRegente;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.OtrosFuncionarios = inspeccion.InspGuiaBPMFabricanteMed.OtrosFuncionarios;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.OtrosFuncionarios).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.RequisitosLegales = inspeccion.InspGuiaBPMFabricanteMed.RequisitosLegales;
            data.InspGuiaBPMFabricanteMed.ClasifActComerciales = inspeccion.InspGuiaBPMFabricanteMed.ClasifActComerciales;
            data.InspGuiaBPMFabricanteMed.ClasifEstablecimiento = inspeccion.InspGuiaBPMFabricanteMed.ClasifEstablecimiento;
            data.InspGuiaBPMFabricanteMed.Observaciones = inspeccion.InspGuiaBPMFabricanteMed.Observaciones;
            data.InspGuiaBPMFabricanteMed.ProcesoVigilanciaSanit = inspeccion.InspGuiaBPMFabricanteMed.ProcesoVigilanciaSanit;
            data.InspGuiaBPMFabricanteMed.FechaUltimaVista = inspeccion.InspGuiaBPMFabricanteMed.FechaUltimaVista;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.OtrosFuncionarios).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ClasifActComerciales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ClasifEstablecimiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.OrganizacionPersonal = inspeccion.InspGuiaBPMFabricanteMed.OrganizacionPersonal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.OrganizacionPersonal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.EdifInstalaciones = inspeccion.InspGuiaBPMFabricanteMed.EdifInstalaciones;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.EdifInstalaciones).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.Almacenes = inspeccion.InspGuiaBPMFabricanteMed.Almacenes;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Almacenes).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.AreaDispMatPrima = inspeccion.InspGuiaBPMFabricanteMed.AreaDispMatPrima;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AreaDispMatPrima).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap10(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.AreaProduccion = inspeccion.InspGuiaBPMFabricanteMed.AreaProduccion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AreaProduccion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap11(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.AreaAcondicionamiento = inspeccion.InspGuiaBPMFabricanteMed.AreaAcondicionamiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AreaAcondicionamiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap12(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.EquiposGeneralidades = inspeccion.InspGuiaBPMFabricanteMed.EquiposGeneralidades;
            data.InspGuiaBPMFabricanteMed.Equipos = inspeccion.InspGuiaBPMFabricanteMed.Equipos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.EquiposGeneralidades).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Equipos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap13(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.MatProducts = inspeccion.InspGuiaBPMFabricanteMed.MatProducts;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.MatProducts).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap14(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.Documentacion = inspeccion.InspGuiaBPMFabricanteMed.Documentacion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Documentacion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap15(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.Produccion = inspeccion.InspGuiaBPMFabricanteMed.Produccion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Produccion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap16(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.GarantiaCalidad = inspeccion.InspGuiaBPMFabricanteMed.GarantiaCalidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.GarantiaCalidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap17(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.ControlCalidad = inspeccion.InspGuiaBPMFabricanteMed.ControlCalidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ControlCalidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap18(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.ProdAnalisisContrato = inspeccion.InspGuiaBPMFabricanteMed.ProdAnalisisContrato;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ProdAnalisisContrato).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap19(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.ValGenerales = inspeccion.InspGuiaBPMFabricanteMed.ValGenerales;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ValGenerales).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap20(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.QuejasReclamos = inspeccion.InspGuiaBPMFabricanteMed.QuejasReclamos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.QuejasReclamos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap21(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.AutoInspecAuditCal = inspeccion.InspGuiaBPMFabricanteMed.AutoInspecAuditCal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AutoInspecAuditCal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap22(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A = inspeccion.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A;
            data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_Gen = inspeccion.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_Gen;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_A).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_Gen).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap23(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A2 = inspeccion.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A2;
            data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A3 = inspeccion.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A3;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_A2).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_A3).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap24(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.Lactamicos = inspeccion.InspGuiaBPMFabricanteMed.Lactamicos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Lactamicos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Cap25(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.ProdCitostatico = inspeccion.InspGuiaBPMFabricanteMed.ProdCitostatico;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ProdCitostatico).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabMededicamentos_Firma(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMFabricanteMed.DatosRepresentLegal = inspeccion.InspGuiaBPMFabricanteMed.DatosRepresentLegal;
            data.InspGuiaBPMFabricanteMed.DatosRegente = inspeccion.InspGuiaBPMFabricanteMed.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        
        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.DatosRepresentLegal = inspeccion.InspGuiaBPMLabAcondicionador.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.DatosRegente = inspeccion.InspGuiaBPMLabAcondicionador.DatosRegente;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.OtrosFuncionarios = inspeccion.InspGuiaBPMLabAcondicionador.OtrosFuncionarios;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.OtrosFuncionarios).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.RequisitosLegales = inspeccion.InspGuiaBPMLabAcondicionador.RequisitosLegales;
            data.InspGuiaBPMLabAcondicionador.ClasifActComerciales = inspeccion.InspGuiaBPMLabAcondicionador.ClasifActComerciales;
            data.InspGuiaBPMLabAcondicionador.ClasifEstablecimiento = inspeccion.InspGuiaBPMLabAcondicionador.ClasifEstablecimiento;
            data.InspGuiaBPMLabAcondicionador.Observaciones = inspeccion.InspGuiaBPMLabAcondicionador.Observaciones;
            data.InspGuiaBPMLabAcondicionador.ProcesoVigilanciaSanit = inspeccion.InspGuiaBPMLabAcondicionador.ProcesoVigilanciaSanit;
            data.InspGuiaBPMLabAcondicionador.FechaUltimaVista = inspeccion.InspGuiaBPMLabAcondicionador.FechaUltimaVista;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.OtrosFuncionarios).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ClasifActComerciales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ClasifEstablecimiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.OrganizacionPersonal = inspeccion.InspGuiaBPMLabAcondicionador.OrganizacionPersonal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.OrganizacionPersonal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.EdifInstalaciones = inspeccion.InspGuiaBPMLabAcondicionador.EdifInstalaciones;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.EdifInstalaciones).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.Almacenes = inspeccion.InspGuiaBPMLabAcondicionador.Almacenes;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.Almacenes).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.AreaAcondicionamiento = inspeccion.InspGuiaBPMLabAcondicionador.AreaAcondicionamiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.AreaAcondicionamiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap10(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.EquiposGeneralidades = inspeccion.InspGuiaBPMLabAcondicionador.EquiposGeneralidades;
            
            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.EquiposGeneralidades).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap11(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.MatProducts = inspeccion.InspGuiaBPMLabAcondicionador.MatProducts;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.MatProducts).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap12(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.Documentacion = inspeccion.InspGuiaBPMLabAcondicionador.Documentacion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.Documentacion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap13(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.Acondicionamiento = inspeccion.InspGuiaBPMLabAcondicionador.Acondicionamiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.Acondicionamiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap14(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.GarantiaCalidad = inspeccion.InspGuiaBPMLabAcondicionador.GarantiaCalidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.GarantiaCalidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap15(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.ControlCalidad = inspeccion.InspGuiaBPMLabAcondicionador.ControlCalidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ControlCalidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap16(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.ProdAnalisisContrato = inspeccion.InspGuiaBPMLabAcondicionador.ProdAnalisisContrato;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ProdAnalisisContrato).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap17(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.ValGenerales = inspeccion.InspGuiaBPMLabAcondicionador.ValGenerales;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ValGenerales).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap18(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.QuejasReclamos = inspeccion.InspGuiaBPMLabAcondicionador.QuejasReclamos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.QuejasReclamos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Cap19(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.AutoInspecAuditCal = inspeccion.InspGuiaBPMLabAcondicionador.AutoInspecAuditCal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.AutoInspecAuditCal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmAcondMedicamentos_Firma(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPMLabAcondicionador.DatosRepresentLegal = inspeccion.InspGuiaBPMLabAcondicionador.DatosRepresentLegal;
            data.InspGuiaBPMLabAcondicionador.DatosRegente = inspeccion.InspGuiaBPMLabAcondicionador.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.DatosRepresentLegal = inspeccion.InspGuiBPMFabCosmeticoMed.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.DatosRegente = inspeccion.InspGuiBPMFabCosmeticoMed.DatosRegente;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.OtrosFuncionarios = inspeccion.InspGuiBPMFabCosmeticoMed.OtrosFuncionarios;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.OtrosFuncionarios).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.RequisitosLegales = inspeccion.InspGuiBPMFabCosmeticoMed.RequisitosLegales;
            data.InspGuiBPMFabCosmeticoMed.ClasifActComerciales = inspeccion.InspGuiBPMFabCosmeticoMed.ClasifActComerciales;
            data.InspGuiBPMFabCosmeticoMed.ClasifEstablecimiento = inspeccion.InspGuiBPMFabCosmeticoMed.ClasifEstablecimiento;
            data.InspGuiBPMFabCosmeticoMed.Observaciones = inspeccion.InspGuiBPMFabCosmeticoMed.Observaciones;
            data.InspGuiBPMFabCosmeticoMed.ProcesoVigilanciaSanit = inspeccion.InspGuiBPMFabCosmeticoMed.ProcesoVigilanciaSanit;
            data.InspGuiBPMFabCosmeticoMed.FechaUltimaVista = inspeccion.InspGuiBPMFabCosmeticoMed.FechaUltimaVista;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.OtrosFuncionarios).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ClasifActComerciales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ClasifEstablecimiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AdminInfoGeneral = inspeccion.InspGuiBPMFabCosmeticoMed.AdminInfoGeneral;
            
            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AdminInfoGeneral).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.CondExtAlmacenas = inspeccion.InspGuiBPMFabCosmeticoMed.CondExtAlmacenas;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.CondExtAlmacenas).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.CondIntAlmacenas = inspeccion.InspGuiBPMFabCosmeticoMed.CondIntAlmacenas;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.CondIntAlmacenas).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AreaRecepMateriaPrima = inspeccion.InspGuiBPMFabCosmeticoMed.AreaRecepMateriaPrima;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaRecepMateriaPrima).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap10(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AlmacenMateriaPrima = inspeccion.InspGuiBPMFabCosmeticoMed.AlmacenMateriaPrima;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AlmacenMateriaPrima).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap11(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AlmacenMatAcondicionamineto = inspeccion.InspGuiBPMFabCosmeticoMed.AlmacenMatAcondicionamineto;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AlmacenMatAcondicionamineto).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap12(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.RecepProductoTerminado = inspeccion.InspGuiBPMFabCosmeticoMed.RecepProductoTerminado;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RecepProductoTerminado).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap13(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AlmacenProductoTerminado = inspeccion.InspGuiBPMFabCosmeticoMed.AlmacenProductoTerminado;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AlmacenProductoTerminado).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap14(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.ProductoDevueltoRechazado = inspeccion.InspGuiBPMFabCosmeticoMed.ProductoDevueltoRechazado;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ProductoDevueltoRechazado).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap15(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.DistProductoTerminado = inspeccion.InspGuiBPMFabCosmeticoMed.DistProductoTerminado;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.DistProductoTerminado).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap16(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.ManejoQuejaReclamos = inspeccion.InspGuiBPMFabCosmeticoMed.ManejoQuejaReclamos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ManejoQuejaReclamos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap17(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.RetiroProcMercado = inspeccion.InspGuiBPMFabCosmeticoMed.RetiroProcMercado;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RetiroProcMercado).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap18(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.SistemaInstAgua = inspeccion.InspGuiBPMFabCosmeticoMed.SistemaInstAgua;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.SistemaInstAgua).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap19(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.OsmosisInversa = inspeccion.InspGuiBPMFabCosmeticoMed.OsmosisInversa;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.OsmosisInversa).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap20(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.SistemaDeIonizacion = inspeccion.InspGuiBPMFabCosmeticoMed.SistemaDeIonizacion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.SistemaDeIonizacion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap21(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.CalibraVerifEquipo = inspeccion.InspGuiBPMFabCosmeticoMed.CalibraVerifEquipo;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.CalibraVerifEquipo).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap22(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.Validaciones = inspeccion.InspGuiBPMFabCosmeticoMed.Validaciones;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.Validaciones).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap23(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.MantAreaEquipos = inspeccion.InspGuiBPMFabCosmeticoMed.MantAreaEquipos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.MantAreaEquipos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap24(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AreaProdCondExternas = inspeccion.InspGuiBPMFabCosmeticoMed.AreaProdCondExternas;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaProdCondExternas).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap25(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AreaProdCondInternas = inspeccion.InspGuiBPMFabCosmeticoMed.AreaProdCondInternas;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaProdCondInternas).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap26(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AreaOrganizaDocumentacion = inspeccion.InspGuiBPMFabCosmeticoMed.AreaOrganizaDocumentacion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaOrganizaDocumentacion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap27(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AreaDispensionOrdFab = inspeccion.InspGuiBPMFabCosmeticoMed.AreaDispensionOrdFab;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaDispensionOrdFab).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap28(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.FabProdDesinfectante = inspeccion.InspGuiBPMFabCosmeticoMed.FabProdDesinfectante;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.FabProdDesinfectante).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap29(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.FabPlaguicida = inspeccion.InspGuiBPMFabCosmeticoMed.FabPlaguicida;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.FabPlaguicida).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap30(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.FabCosmeticos = inspeccion.InspGuiBPMFabCosmeticoMed.FabCosmeticos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.FabCosmeticos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap31(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AreaEnvasado = inspeccion.InspGuiBPMFabCosmeticoMed.AreaEnvasado;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaEnvasado).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap32(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AreaEtiquetadoEmpaque = inspeccion.InspGuiBPMFabCosmeticoMed.AreaEtiquetadoEmpaque;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaEtiquetadoEmpaque).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap33(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.LabControlCalidad = inspeccion.InspGuiBPMFabCosmeticoMed.LabControlCalidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.LabControlCalidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap34(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.AnalisisContrato = inspeccion.InspGuiBPMFabCosmeticoMed.AnalisisContrato;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AnalisisContrato).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Cap35(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.InspeccionAudito = inspeccion.InspGuiBPMFabCosmeticoMed.InspeccionAudito;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.InspeccionAudito).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabCosmeticosDesinf_Firma(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabCosmeticoMed.DatosRepresentLegal = inspeccion.InspGuiBPMFabCosmeticoMed.DatosRepresentLegal;
            data.InspGuiBPMFabCosmeticoMed.DatosRegente = inspeccion.InspGuiBPMFabCosmeticoMed.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.DatosRepresentLegal = inspeccion.InspGuiBPMFabNatMedicina.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.DatosRegente = inspeccion.InspGuiBPMFabNatMedicina.DatosRegente;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.OtrosFuncionarios = inspeccion.InspGuiBPMFabNatMedicina.OtrosFuncionarios;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.OtrosFuncionarios).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.InfoGeneral = inspeccion.InspGuiBPMFabNatMedicina.InfoGeneral;
            
            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.InfoGeneral).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.AuthFuncionamiento = inspeccion.InspGuiBPMFabNatMedicina.AuthFuncionamiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.AuthFuncionamiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.Organizacion = inspeccion.InspGuiBPMFabNatMedicina.Organizacion;
            data.InspGuiBPMFabNatMedicina.Personal = inspeccion.InspGuiBPMFabNatMedicina.Personal;
            data.InspGuiBPMFabNatMedicina.ResponPersonal = inspeccion.InspGuiBPMFabNatMedicina.ResponPersonal;
            data.InspGuiBPMFabNatMedicina.Capacitacion = inspeccion.InspGuiBPMFabNatMedicina.Capacitacion;
            data.InspGuiBPMFabNatMedicina.HigieneSalud = inspeccion.InspGuiBPMFabNatMedicina.HigieneSalud;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Organizacion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Personal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.ResponPersonal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Capacitacion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.HigieneSalud).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.UbicacionDisenoConstruc = inspeccion.InspGuiBPMFabNatMedicina.UbicacionDisenoConstruc;
            data.InspGuiBPMFabNatMedicina.Almacenes = inspeccion.InspGuiBPMFabNatMedicina.Almacenes;
            data.InspGuiBPMFabNatMedicina.AreaRecepLimpieza = inspeccion.InspGuiBPMFabNatMedicina.AreaRecepLimpieza;
            data.InspGuiBPMFabNatMedicina.AreaSecadoMolienda = inspeccion.InspGuiBPMFabNatMedicina.AreaSecadoMolienda;
            data.InspGuiBPMFabNatMedicina.AreaDispensadoMatPrima = inspeccion.InspGuiBPMFabNatMedicina.AreaDispensadoMatPrima;
            data.InspGuiBPMFabNatMedicina.AreaProduccion = inspeccion.InspGuiBPMFabNatMedicina.AreaProduccion;
            data.InspGuiBPMFabNatMedicina.AreaEnvasadoEmpaque = inspeccion.InspGuiBPMFabNatMedicina.AreaEnvasadoEmpaque;
            data.InspGuiBPMFabNatMedicina.AreaAuxiliares = inspeccion.InspGuiBPMFabNatMedicina.AreaAuxiliares;
            data.InspGuiBPMFabNatMedicina.AreaControlCalidad = inspeccion.InspGuiBPMFabNatMedicina.AreaControlCalidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.UbicacionDisenoConstruc).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Almacenes).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.AreaRecepLimpieza).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.AreaSecadoMolienda).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.AreaDispensadoMatPrima).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.AreaProduccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.AreaEnvasadoEmpaque).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.AreaAuxiliares).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.AreaControlCalidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.Generalidades8 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades8;
            data.InspGuiBPMFabNatMedicina.Calibracion = inspeccion.InspGuiBPMFabNatMedicina.Calibracion;
            data.InspGuiBPMFabNatMedicina.SistemaAgua = inspeccion.InspGuiBPMFabNatMedicina.SistemaAgua;
            data.InspGuiBPMFabNatMedicina.SistemaAire = inspeccion.InspGuiBPMFabNatMedicina.SistemaAire;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Generalidades8).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Calibracion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.SistemaAgua).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.SistemaAire).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap10(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.Generalidades9 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades9;
            data.InspGuiBPMFabNatMedicina.DispensadoMatPrima = inspeccion.InspGuiBPMFabNatMedicina.DispensadoMatPrima;
            data.InspGuiBPMFabNatMedicina.MatAcondicionamiento = inspeccion.InspGuiBPMFabNatMedicina.MatAcondicionamiento;
            data.InspGuiBPMFabNatMedicina.ProdAGranel = inspeccion.InspGuiBPMFabNatMedicina.ProdAGranel;
            data.InspGuiBPMFabNatMedicina.ProdTerminados = inspeccion.InspGuiBPMFabNatMedicina.ProdTerminados;
            data.InspGuiBPMFabNatMedicina.ProdRechazados = inspeccion.InspGuiBPMFabNatMedicina.ProdRechazados;
            data.InspGuiBPMFabNatMedicina.ProdDevueltos = inspeccion.InspGuiBPMFabNatMedicina.ProdDevueltos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Generalidades9).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.DispensadoMatPrima).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.MatAcondicionamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.ProdAGranel).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.ProdTerminados).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.ProdRechazados).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.ProdDevueltos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap11(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.Generalidades10 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades10;
            data.InspGuiBPMFabNatMedicina.DocumentosExigido = inspeccion.InspGuiBPMFabNatMedicina.DocumentosExigido;
            data.InspGuiBPMFabNatMedicina.ProcedimientoReg = inspeccion.InspGuiBPMFabNatMedicina.ProcedimientoReg;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Generalidades10).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.DocumentosExigido).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.ProcedimientoReg).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap12(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.ProdControlProceso = inspeccion.InspGuiBPMFabNatMedicina.ProdControlProceso;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.ProdControlProceso).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap13(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.Generalidades12 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades12;
            data.InspGuiBPMFabNatMedicina.GarantiaCalidad = inspeccion.InspGuiBPMFabNatMedicina.GarantiaCalidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Generalidades12).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.GarantiaCalidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap14(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.Generalidades13 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades13;
            data.InspGuiBPMFabNatMedicina.Muestreo = inspeccion.InspGuiBPMFabNatMedicina.Muestreo;
            data.InspGuiBPMFabNatMedicina.MetodologiaAnalitica = inspeccion.InspGuiBPMFabNatMedicina.MetodologiaAnalitica;
            data.InspGuiBPMFabNatMedicina.MaterialesReferencia = inspeccion.InspGuiBPMFabNatMedicina.MaterialesReferencia;
            data.InspGuiBPMFabNatMedicina.Estabilidad = inspeccion.InspGuiBPMFabNatMedicina.Estabilidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Generalidades13).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Muestreo).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.MetodologiaAnalitica).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.MaterialesReferencia).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Estabilidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap15(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.Generalidades14 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades14;
            data.InspGuiBPMFabNatMedicina.Retiros = inspeccion.InspGuiBPMFabNatMedicina.Retiros;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Generalidades14).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Retiros).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap16(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.Generalidades15 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades15;
            data.InspGuiBPMFabNatMedicina.Contratante = inspeccion.InspGuiBPMFabNatMedicina.Contratante;
            data.InspGuiBPMFabNatMedicina.Contratista = inspeccion.InspGuiBPMFabNatMedicina.Contratista;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Generalidades15).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Contratante).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.Contratista).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Cap17(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.AuditoriaCalidad = inspeccion.InspGuiBPMFabNatMedicina.AuditoriaCalidad;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                if (result.InspGuiBPMFabNatMedicina != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.AuditoriaCalidad).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmFabNaturalesMed_Firma(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiBPMFabNatMedicina.DatosRepresentLegal = inspeccion.InspGuiBPMFabNatMedicina.DatosRepresentLegal;
            data.InspGuiBPMFabNatMedicina.DatosRegente = inspeccion.InspGuiBPMFabNatMedicina.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabNatMedicina).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        /////////////////////////////
        ///
        public async Task<AUD_InspeccionTB> Save_BpmBPA_Cap2(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPM_Bpa.DatosRepresentLegal = inspeccion.InspGuiaBPM_Bpa.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPM_Bpa != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmBPA_Cap3(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPM_Bpa.DatosRegente = inspeccion.InspGuiaBPM_Bpa.DatosRegente;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPM_Bpa != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmBPA_Cap4(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPM_Bpa.OtrosFuncionarios = inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPM_Bpa != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.OtrosFuncionarios).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmBPA_Cap5(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPM_Bpa.ActComercialAprobada = inspeccion.InspGuiaBPM_Bpa.ActComercialAprobada;
            data.InspGuiaBPM_Bpa.FechaUltimaInspeccion = inspeccion.InspGuiaBPM_Bpa.FechaUltimaInspeccion;
            data.InspGuiaBPM_Bpa.PropositoInsp = inspeccion.InspGuiaBPM_Bpa.PropositoInsp;
            data.InspGuiaBPM_Bpa.HorarioEstFarmaceutico = inspeccion.InspGuiaBPM_Bpa.HorarioEstFarmaceutico;
            data.InspGuiaBPM_Bpa.HorarioRegFarmaceutica = inspeccion.InspGuiaBPM_Bpa.HorarioRegFarmaceutica;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPM_Bpa != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.PropositoInsp).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmBPA_Cap6(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPM_Bpa.DispGenerlestablecimiento = inspeccion.InspGuiaBPM_Bpa.DispGenerlestablecimiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPM_Bpa != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.DispGenerlestablecimiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmBPA_Cap7(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPM_Bpa.AreasEstablecimiento = inspeccion.InspGuiaBPM_Bpa.AreasEstablecimiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPM_Bpa != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.AreasEstablecimiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmBPA_Cap8(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPM_Bpa.Distribucion = inspeccion.InspGuiaBPM_Bpa.Distribucion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPM_Bpa != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.Distribucion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmBPA_Cap9(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPM_Bpa.TransProdFarmaceuticos = inspeccion.InspGuiaBPM_Bpa.TransProdFarmaceuticos;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPM_Bpa != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.TransProdFarmaceuticos).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmBPA_Cap10(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPM_Bpa.AutoInspec = inspeccion.InspGuiaBPM_Bpa.AutoInspec;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {

                if (result.InspGuiaBPM_Bpa != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.AutoInspec).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_BpmBPA_Firma(AUD_InspeccionTB inspeccion)
        {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspGuiaBPM_Bpa.DatosRepresentLegal = inspeccion.InspGuiaBPM_Bpa.DatosRepresentLegal;
            data.InspGuiaBPM_Bpa.DatosRegente = inspeccion.InspGuiaBPM_Bpa.DatosRegente;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa))
            {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.DatosRegente).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        ////////////////////
        ///////
        ///
        public async Task<AUD_InspeccionTB> Save_AperturaFabCosmeticoArtesanal_Cap2(AUD_InspeccionTB inspeccion) {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperturaCosmetArtesanal.DatosRepresentLegal = inspeccion.InspAperturaCosmetArtesanal.DatosRepresentLegal;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa)) {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null) {

                if (result.InspAperturaCosmetArtesanal != null) {
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperturaFabCosmeticoArtesanal_Cap3(AUD_InspeccionTB inspeccion) {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperturaCosmetArtesanal.Documentacion = inspeccion.InspAperturaCosmetArtesanal.Documentacion;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa)) {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null) {

                if (result.InspAperturaCosmetArtesanal != null) {
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.Documentacion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperturaFabCosmeticoArtesanal_Cap4(AUD_InspeccionTB inspeccion) {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperturaCosmetArtesanal.Locales = inspeccion.InspAperturaCosmetArtesanal.Locales;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa)) {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null) {

                if (result.InspAperturaCosmetArtesanal != null) {
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.Locales).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperturaFabCosmeticoArtesanal_Cap5(AUD_InspeccionTB inspeccion) {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperturaCosmetArtesanal.AreaAlmacenamiento = inspeccion.InspAperturaCosmetArtesanal.AreaAlmacenamiento;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa)) {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null) {

                if (result.InspAperturaCosmetArtesanal != null) {
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.AreaAlmacenamiento).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }
        public async Task<AUD_InspeccionTB> Save_AperturaFabCosmeticoArtesanal_Firma(AUD_InspeccionTB inspeccion) {
            var data = DalService.Get<AUD_InspeccionTB>(inspeccion.Id);

            data.InspAperturaCosmetArtesanal.DatosRepresentLegal = inspeccion.InspAperturaCosmetArtesanal.DatosRepresentLegal;
            data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;

            //generar el numero de acta
            if (string.IsNullOrEmpty(data.NumActa) || string.IsNullOrWhiteSpace(data.NumActa)) {
                data.IntNumActa = GetMaxInspectionActNumber() + 1;
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"), DateTime.Now.ToString("yyyy"), data.TipoActa.ToString(), data.Establecimiento?.TipoEstablecimiento.ToString() ?? "NA", data.DatosEstablecimiento?.Provincia?.Codigo ?? "0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if (result != null) {
                DalService.DBContext.Entry(result).Property(b => b.ParticipantesDNFD).IsModified = true;

                if (result.InspAperturaCosmetArtesanal != null) {
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.DatosRepresentLegal).IsModified = true;
                }

                DalService.DBContext.SaveChanges();
            }
            return result;
        }


    }

}
