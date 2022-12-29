using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using ClosedXML.Excel;
using DataModel.Helper;

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

        public async Task<Stream> ExportToExcel(GenericModel<AUD_InspeccionTB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;

                model = await FindAll(model);


                if (model.Ldata != null && model.Ldata.Count > 0)
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

                    for (int row = 1; row <= model.Ldata.Count; row++)
                    {
                        var prod = model.Ldata[row - 1];

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
                if (result.InspGuiaBPM_Bpa != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.GeneralesEmpresa).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.RepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.RegenteFarmaceutico).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.PropositoInsp).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.OtrosFuncionarios).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.DispGenerlestablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.AreasEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.Distribucion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.TransProdFarmaceuticos).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.AutoInspec).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPM_Bpa).Property(b => b.DatosConclusiones).IsModified = true;

                    DalService.DBContext.SaveChanges();
                }
                if (result.InspGuiaBPMLabAcondicionador != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.AuditoriaSanitaria).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.RepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.RegenteFarmaceutico).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.OtrosFuncionarios).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.GeneralesEmpresa).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.RespProduccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.RespControlCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.RequisitosLegales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ClasifActComerciales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ClasifEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.OrganizacionPersonal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.EdifInstalaciones).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.Almacenes).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.AreaAcondicionamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.EquiposGeneralidades).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.MatProducts).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.Documentacion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.Acondicionamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.GarantiaCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ControlCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ProdAnalisisContrato).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.ValGenerales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.QuejasReclamos).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.AutoInspecAuditCal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMLabAcondicionador).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspGuiaBPMFabricanteMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AuditoriaSanitaria).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.RepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.RegenteFarmaceutico).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.OtrosFuncionarios).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.GeneralesEmpresa).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.RespProduccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.RespControlCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.RequisitosLegales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ClasifActComerciales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ClasifEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.OrganizacionPersonal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.EdifInstalaciones).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Almacenes).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AreaDispMatPrima).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AreaProduccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AreaAcondicionamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.EquiposGeneralidades).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Equipos).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.MatProducts).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Documentacion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Produccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.GarantiaCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ControlCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ProdAnalisisContrato).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ValGenerales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.QuejasReclamos).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.AutoInspecAuditCal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_A).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_Gen).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_A2).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.FabProdFarmEsteril_A3).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.Lactamicos).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.ProdCitostatico).IsModified = true;

                    DalService.DBContext.Entry(result.InspGuiaBPMFabricanteMed).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspDisposicionFinal != null)
                {
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.GeneralesEmpresa).IsModified = true;
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosResponsable).IsModified = true;
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.InventarioMedicamento).IsModified = true;
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspDisposicionFinal != null)
                {
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.GeneralesEmpresa).IsModified = true;
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosResponsable).IsModified = true;
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.GeneralesEmpresa).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.GenEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaRecepProductos).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaProdDevueltos).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaDespachoProductos).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmCadenaFrio).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaDesperdicio).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaSustanciasControladas).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Procedimientos).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Transporte).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.ActividadDistribucion).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.InventarioMedicamento).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspAperturaCosmetArtesanal != null)
                {
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.GeneralesEmpresa).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.Propietario).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.Documentacion).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.Locales).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.AreaAlmacenamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspGuiBPMFabCosmeticoMed != null)
                {
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AuditoriaSanitaria).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RegenteFarmaceutico).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.OtrosFuncionarios).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.GeneralesEmpresa).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RespProduccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RespControlCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RequisitosLegales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ClasifActComerciales).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ClasifEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ClasifEstablecimiento2).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.GenEstructuraOrganizativa).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.CondExtAlmacenas).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.CondIntAlmacenas).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaRecepMateriaPrima).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AlmacenMateriaPrima).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AlmacenMatAcondicionamineto).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RecepProductoTerminado).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AlmacenProductoTerminado).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ProductoDevueltoRechazado).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.DistProductoTerminado).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.ManejoQuejaReclamos).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.RetiroProcMercado).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.SistemaInstAgua).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.OsmosisInversa).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.SistemaDeIonizacion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.CalibraVerifEquipo).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.Validaciones).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.MantAreaEquipos).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaProdCondExternas).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaProdCondInternas).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaOrganizaDocumentacion).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaDispensionOrdFab).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.FabProdDesinfectante).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.FabPlaguicida).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.FabCosmeticos).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaEnvasado).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AreaEtiquetadoEmpaque).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.LabControlCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.AnalisisContrato).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.InspeccionAudito).IsModified = true;
                    DalService.DBContext.Entry(result.InspGuiBPMFabCosmeticoMed).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
                if (result.InspInvestigacion != null)
                {
                    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DatosEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DatosAtendidosPor).IsModified = true;
                    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DatosConclusiones).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
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
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosProcedimientoPrograma).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAutoInspeccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosProdAnalisisContrato).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosReclamoProductoRetirado).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosLocal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosDocumentacion).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaInterna).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaExterna).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaAlmacenamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaProduccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaAuxiliares).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosEquipos).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaDispensado).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosAreaLabCtrCalidad).IsModified = true;
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
