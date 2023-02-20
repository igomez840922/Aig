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
                               (model.ProvinceId != null ? data.Establecimiento.ProvinciaId == model.ProvinceId : true) &&
                               (model.FromDate !=null? data.FechaInicio >= model.FromDate:true) &&
                               (model.ToDate != null ? data.FechaInicio <= model.ToDate : true)
                               orderby data.FechaInicio
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                               where data.Deleted == false &&
                                (string.IsNullOrEmpty(model.Filter) ? true : (data.NumActa.Contains(model.Filter) || data.LicenseNumber.Contains(model.Filter) || (data.Establecimiento != null && data.Establecimiento.Nombre.Contains(model.Filter)))) &&
                               (model.TipoActa != DataModel.Helper.enumAUD_TipoActa.None ? data.TipoActa == model.TipoActa : true) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None ? data.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.ProvinceId != null ? data.Establecimiento.ProvinciaId == model.ProvinceId : true) &&
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
                data.NumActa = string.Format("{0}-{1}/{2}/{3}({4})", data.IntNumActa.ToString("000"),DateTime.Now.ToString("yyyy"),data.TipoActa.ToString(),data.Establecimiento?.TipoEstablecimiento.ToString()??"NA",data.DatosEstablecimiento?.Provincia?.Codigo??"0"); //DateTime.Now.ToString("yyMMdd") + "-" + data.IntNumActa.ToString("000");
            }

            var result = DalService.Save(data);
            if(result != null)
            {
                
                if (result.DatosEstablecimiento != null)
                {
                    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Establecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Provincia).IsModified = true;
                    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Distrito).IsModified = true;
                    DalService.DBContext.Entry(result.DatosEstablecimiento).Property(b => b.Corregimiento).IsModified = true;
                }
                if (result.InspAperFabricanteCosmetMed != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.DatosEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.OrganizacionPersonal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.Programas).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.ProdAnalisisContrato).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.ReclamosProdRetirados).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.Locales).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.AreaProduccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.Equipo).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.LaboratorioControlCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.AreaAlmacenamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.AreaAuxiliar).IsModified = true;

                    DalService.DBContext.Entry(result.InspAperFabricanteCosmetMed).Property(b => b.DatosConclusiones).IsModified = true;

                }
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
                }
                if (result.InspDisposicionFinal != null)
                {
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosAtendidosPor).IsModified = true;
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.DatosInspeccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspDisposicionFinal).Property(b => b.InventarioMedicamento).IsModified = true;
                }
                if (result.InspRutinaVigAgencia != null)
                {
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.CondCaractEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAdministrativa).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaRecepcionProducto).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaProductosDevueltosVencidos).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaProductosRetiradosMercado).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaDespachoProductos).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenProdReqCadenaFrio).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenProdVolatiles).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenPlaguicidas).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenMateriaPrima).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.AreaAlmacenProdSujetosControl).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Procedimientos).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Transporte).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Actividades).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.Productos).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigAgencia).Property(b => b.InventarioMedicamento).IsModified = true;

                }
                if (result.InspAperturaCosmetArtesanal != null)
                {
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.GeneralesEmpresa).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.Propietario).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.Documentacion).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.Locales).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.AreaAlmacenamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperturaCosmetArtesanal).Property(b => b.DatosConclusiones).IsModified = true;
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
                }
                if (result.InspInvestigacion != null)
                {
                    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DatosAtendidosPor).IsModified = true;
                    DalService.DBContext.Entry(result.InspInvestigacion).Property(b => b.DetallesInvestigacion).IsModified = true;
                }
                if (result.InspRetiroRetencion != null)
                {
                    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspRetiroRetencion).Property(b => b.DatosAtendidosPor).IsModified = true;
                
                }
                if (result.InspAperCambUbicFarm != null)
                {                   
                    //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                    //DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosSolicitante).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosEstructuraOrganizacional).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosInfraEstructura).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaFisica).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosPreguntasGenericas).IsModified = true;
                    //DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosSenalizacionAvisos).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaProductosControlados).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAreaAlmacenamiento).IsModified = true;
                    //DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosConclusiones).IsModified = true;
                    //DalService.DBContext.Entry(result.InspAperCambUbicFarm).Property(b => b.DatosAtendidosPor).IsModified = true;
                }
                if (result.InspAperCambUbicAgen != null)
                {
                    //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosSolicitante).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.CondCaractEstablecimiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAdministrativa).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaRecepcionProducto).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaProductosDevueltosVencidos).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaProductosRetiradosMercado).IsModified = true; 
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaDespachoProductos).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenProdReqCadenaFrio).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenProdVolatiles).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenPlaguicidas).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenMateriaPrima).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaAlmacenProdSujetosControl).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.AreaDesperdicio).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.Requisitos).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.Actividades).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperCambUbicAgen).Property(b => b.Productos).IsModified = true;
                }
                if (result.InspAperFabricante != null)
                {
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.ProdFabrican).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.Personal).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.Instalaciones).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaAlmacenamiento).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaDispMateriaPrima).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaProduccion).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaAcondSecundario).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.ControlCalidad).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.AreaAuxiliares).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.Equipos).IsModified = true;
                    DalService.DBContext.Entry(result.InspAperFabricante).Property(b => b.MaterialesProductos).IsModified = true;
                }
                if (result.InspRutinaVigFarmacia != null)
                {
                    //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;                    
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosRegente).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.DatosFarmaceutico).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.ExpPersonalFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.EstructOrganizFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.EstructFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.AreaFisicaFarmacia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.AreaProdControlados).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.RegMovimientoExistencia).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.AreaAlmacenMedicamentos).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.Procedimientos).IsModified = true;
                    DalService.DBContext.Entry(result.InspRutinaVigFarmacia).Property(b => b.InventarioMedicamento).IsModified = true;
                }
                if (result.InspCierreOperacion != null)
                {
                    //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;                    
                    DalService.DBContext.Entry(result.InspCierreOperacion).Property(b => b.DatosRepresentLegal).IsModified = true;
                    DalService.DBContext.Entry(result.InspCierreOperacion).Property(b => b.DatosInspeccion).IsModified = true;
                }

                DalService.DBContext.SaveChanges();

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

    }

}
