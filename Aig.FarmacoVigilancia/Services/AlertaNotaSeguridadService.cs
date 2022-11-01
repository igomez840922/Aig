using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace Aig.FarmacoVigilancia.Services
{    
    public class AlertaNotaSeguridadService : IAlertaNotaSeguridadService
    {
        private readonly IDalService DalService;
        public AlertaNotaSeguridadService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_AlertaNotaSeguridadTB>> FindAll(GenericModel<FMV_AlertaNotaSeguridadTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_AlertaNotaSeguridadTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Producto.Contains(model.Filter) || data.DCI.Contains(model.Filter)))&&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId )) &&
                              (model.AlertaNotaType == null ? true : (data.TipoAlerta == model.AlertaNotaType)) &&
                              (model.AlertaNotaStatus == null ? true : (data.Estado == model.AlertaNotaStatus))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_AlertaNotaSeguridadTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Producto.Contains(model.Filter) || data.DCI.Contains(model.Filter))) &&
                               (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId)) &&
                               (model.AlertaNotaType == null ? true : (data.TipoAlerta == model.AlertaNotaType)) &&
                               (model.AlertaNotaStatus == null ? true : (data.Estado == model.AlertaNotaStatus))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_AlertaNotaSeguridadTB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;

                model = await FindAll(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "RESPONSABLES_FARMACOVIGILANCIA";
                    wb.Properties.Title = "RESPONSABLES_FARMACOVIGILANCIA";
                    wb.Properties.Subject = "RESPONSABLES_FARMACOVIGILANCIA";

                    var ws = wb.Worksheets.Add("RESPONSABLES_FARMACOVIGILANCIA");

                    ws.Cell(1, 1).Value = "Fecha de recibida (CNFV)";
                    ws.Cell(1, 2).Value = "Fecha de entrega al evaluador";
                    ws.Cell(1, 3).Value = "Fecha de evaluación";
                    ws.Cell(1, 4).Value = "Funcionario";
                    ws.Cell(1, 5).Value = "Origen";
                    ws.Cell(1, 6).Value = "Tipo de alerta";
                    ws.Cell(1, 7).Value = "Producto";
                    ws.Cell(1, 8).Value = "DCI";
                    ws.Cell(1, 9).Value = "Descripción";
                    ws.Cell(1, 10).Value = "Recomendaciones a Profesionales y Pacientes";
                    ws.Cell(1, 11).Value = "Actualización de monografía e inserto";
                    ws.Cell(1, 12).Value = "Consentimiento Informado";
                    ws.Cell(1, 13).Value = "Suspensión y retiro de lote(s)";
                    ws.Cell(1, 14).Value = "Registro Sanitario (Suspensión/Cancelación)";
                    ws.Cell(1, 15).Value = "Otras";
                    ws.Cell(1, 16).Value = "Número de nota";
                    ws.Cell(1, 17).Value = "Estatus";
                    ws.Cell(1, 18).Value = "Observaciones";

                    for (int row = 1; row <= model.Ldata.Count; row++)
                    {//FechaRecepcion
                        var prod = model.Ldata[row - 1];
                        ws.Cell(row + 1, 1).Value = prod.FechaRecepcion?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 2).Value = prod.FechaEntregaEvaluador?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 3).Value = prod.FechaEvaluacion?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 4).Value = prod.Evaluador?.NombreCompleto??"";
                        ws.Cell(row + 1, 5).Value = prod.OrigenAlerta?.Nombre??"";
                        ws.Cell(row + 1, 6).Value = DataModel.Helper.Helper.GetDescription(prod.TipoAlerta);
                        ws.Cell(row + 1, 7).Value = prod.Producto;
                        ws.Cell(row + 1, 8).Value = prod.DCI;
                        ws.Cell(row + 1, 9).Value = prod.Descripcion;
                        ws.Cell(row + 1, 10).Value = prod.RecomProfPaciente? "Si":"No";
                        ws.Cell(row + 1, 11).Value = prod.ActualizaMonografias ? "Si" : "No";
                        ws.Cell(row + 1, 12).Value = prod.ConsentFirmado ? "Si" : "No";
                        ws.Cell(row + 1, 13).Value = prod.SuspencionRetiroLote ? "Si" : "No";
                        ws.Cell(row + 1, 14).Value = prod.SuspencCancelRegSanitario ? "Si" : "No";
                        ws.Cell(row + 1, 15).Value = prod.OtrasConsideraciones ? "Si" : "No";
                        ws.Cell(row + 1, 16).Value = prod.NumNota;
                        ws.Cell(row + 1, 17).Value = DataModel.Helper.Helper.GetDescription(prod.Estado);
                        ws.Cell(row + 1, 18).Value = prod.Observaciones;
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


        public async Task<List<FMV_AlertaNotaSeguridadTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_AlertaNotaSeguridadTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_AlertaNotaSeguridadTB> Get(long Id)
        {
            var result = DalService.Get<FMV_AlertaNotaSeguridadTB>(Id);
            return result;
        }

        public async Task<FMV_AlertaNotaSeguridadTB> Save(FMV_AlertaNotaSeguridadTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<FMV_AlertaNotaSeguridadTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_AlertaNotaSeguridadTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_AlertaNotaSeguridadTB>(); }
            catch { }return 0;
        }
    }

}
