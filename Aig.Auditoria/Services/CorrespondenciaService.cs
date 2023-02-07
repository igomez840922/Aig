using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;

namespace Aig.Auditoria.Services
{    
    public class CorrespondenciaService : ICorrespondenciaService
    {
        private readonly IDalService DalService;
        public CorrespondenciaService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_CorrespondenciaTB>> FindAll(GenericModel<AUD_CorrespondenciaTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;
                model.FromDate = model.FromDate != null ? new DateTime(model.FromDate.Value.Year, model.FromDate.Value.Month, model.FromDate.Value.Day, 0, 0, 0) : model.FromDate;
                model.ToDate = model.ToDate != null ? new DateTime(model.ToDate.Value.Year, model.ToDate.Value.Month, model.ToDate.Value.Day, 23, 59, 59) : model.ToDate;

                model.Ldata  = (from data in DalService.DBContext.Set<AUD_CorrespondenciaTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Empresa.Contains(model.Filter) || data.NumDocRecibido.Contains(model.Filter) || data.NombreRecibido.Contains(model.Filter) || data.NumDocRespuesta.Contains(model.Filter) || data.Asunto.Contains(model.Filter))) &&
                              (model.FromDate != null ? data.FechaIngreso >= model.FromDate : true) &&
                               (model.ToDate != null ? data.FechaIngreso <= model.ToDate : true) &&
                              (model.RevDateIni != null ? data.FechaRevision >= model.RevDateIni : true) &&
                               (model.RevDateEnd != null ? data.FechaRevision <= model.RevDateEnd : true) &&
                               (model.RecDateIni != null ? data.FechaRecibo >= model.RecDateIni : true) &&
                               (model.RecDateEnd != null ? data.FechaRecibo <= model.RecDateEnd : true) &&
                               (model.ResDateIni != null ? data.FechaRespuesta >= model.ResDateIni : true) &&
                               (model.ResDateEnd != null ? data.FechaRespuesta <= model.ResDateEnd : true)
                                orderby data.CreatedDate descending
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_CorrespondenciaTB>()
                             where data.Deleted == false &&
                             (string.IsNullOrEmpty(model.Filter) ? true : (data.Empresa.Contains(model.Filter) || data.NumDocRecibido.Contains(model.Filter) || data.NombreRecibido.Contains(model.Filter) || data.NumDocRespuesta.Contains(model.Filter) || data.Asunto.Contains(model.Filter))) &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Empresa.Contains(model.Filter) || data.NumDocRecibido.Contains(model.Filter) || data.NombreRecibido.Contains(model.Filter) || data.NumDocRespuesta.Contains(model.Filter) || data.Asunto.Contains(model.Filter))) &&
                              (model.FromDate != null ? data.FechaIngreso >= model.FromDate : true) &&
                               (model.ToDate != null ? data.FechaIngreso <= model.ToDate : true) &&
                              (model.RevDateIni != null ? data.FechaRevision >= model.RevDateIni : true) &&
                               (model.RevDateEnd != null ? data.FechaRevision <= model.RevDateEnd : true) &&
                               (model.RecDateIni != null ? data.FechaRecibo >= model.RecDateIni : true) &&
                               (model.RecDateEnd != null ? data.FechaRecibo <= model.RecDateEnd : true) &&
                               (model.ResDateIni != null ? data.FechaRespuesta >= model.ResDateIni : true) &&
                               (model.ResDateEnd != null ? data.FechaRespuesta <= model.ResDateEnd : true)
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<AUD_CorrespondenciaTB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;

                model = await FindAll(model);


                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "Correspondencia";
                    wb.Properties.Title = "Correspondencia";
                    wb.Properties.Subject = "Correspondencia";

                    var ws = wb.Worksheets.Add("Correspondencia");

                    ws.Cell(1, 1).Value = "Fecha Ingreso";
                    ws.Cell(1, 2).Value = "Desde (Empresa o Institución, Dpto, otros)";
                    ws.Cell(1, 3).Value = "N° de Documento";
                    ws.Cell(1, 4).Value = "Asunto";
                    ws.Cell(1, 5).Value = "Detalles";
                    ws.Cell(1, 6).Value = "Fecha Revisión";
                    ws.Cell(1, 7).Value = "Responsable de Revisión";
                    ws.Cell(1, 8).Value = "Observaciones";
                    ws.Cell(1, 9).Value = "Departamento y Sección";
                    ws.Cell(1, 10).Value = "Nombre a quien va dirigido";
                    ws.Cell(1, 11).Value = "Recibe";
                    ws.Cell(1, 12).Value = "Firma de quien Recibe";
                    ws.Cell(1, 13).Value = "Fecha Recibo";
                    ws.Cell(1, 14).Value = "Nombre Establecimiento";
                    ws.Cell(1, 15).Value = "Num. Licencia";
                    ws.Cell(1, 16).Value = "Corregimiento";
                    ws.Cell(1, 17).Value = "Ubicación";
                    ws.Cell(1, 18).Value = "Asignado";
                    ws.Cell(1, 19).Value = "Seguimiento";
                    ws.Cell(1, 20).Value = "Fecha Seguimineto";
                    ws.Cell(1, 21).Value = "N° de Documento";

                    for (int row = 1; row <= model.Ldata.Count; row++)
                    {
                        var prod = model.Ldata[row - 1];

                        ws.Cell(row + 1, 1).Value = prod.FechaIngreso?.ToString("dd/MM/yyyy");
                        ws.Cell(row + 1, 2).Value = prod.Empresa;
                        ws.Cell(row + 1, 3).Value = prod.NumDocRecibido;
                        ws.Cell(row + 1, 4).Value = prod.Asunto;
                        ws.Cell(row + 1, 5).Value = prod.Detalles;
                        ws.Cell(row + 1, 6).Value = prod.FechaRevision?.ToString("dd/MM/yyyy");
                        ws.Cell(row + 1, 7).Value = prod.NombreRevision;
                        ws.Cell(row + 1, 8).Value = prod.Observaciones;
                        ws.Cell(row + 1, 9).Value = prod.DptoSeccion;
                        ws.Cell(row + 1, 10).Value = prod.NombreDirigido;
                        ws.Cell(row + 1, 11).Value = prod.NombreRecibido;
                        ws.Cell(row + 1, 12).Value = "";//prod.FirmaRecibido;
                        ws.Cell(row + 1, 13).Value = prod.FechaRecibo?.ToString("dd/MM/yyyy");
                        ws.Cell(row + 1, 14).Value = prod.EstablecimientoNombre;
                        ws.Cell(row + 1, 15).Value = prod.EstablecimientoNumLic;
                        ws.Cell(row + 1, 16).Value = prod.EstablecimientoCorregimiento;
                        ws.Cell(row + 1, 17).Value = prod.EstablecimientoUbicacion;
                        ws.Cell(row + 1, 18).Value = prod.EstablecimientoAsignado;
                        ws.Cell(row + 1, 19).Value = prod.RespuestaCaso;
                        ws.Cell(row + 1, 20).Value = prod.FechaRespuesta?.ToString("dd/MM/yyyy");
                        ws.Cell(row + 1, 21).Value = prod.NumDocRespuesta;
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

        public async Task<List<AUD_CorrespondenciaTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_CorrespondenciaTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_CorrespondenciaTB> Get(long Id)
        {
            var result = DalService.Get<AUD_CorrespondenciaTB>(Id);
            return result;
        }

        public async Task<AUD_CorrespondenciaTB> Save(AUD_CorrespondenciaTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<AUD_CorrespondenciaTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_CorrespondenciaTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_CorrespondenciaTB>(); }
            catch { }return 0;
        }
    }

}
