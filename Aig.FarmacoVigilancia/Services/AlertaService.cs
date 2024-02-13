using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Linq.Expressions;
using Aig.FarmacoVigilancia.Pages.Settings.OrigenAlerta;

namespace Aig.FarmacoVigilancia.Services
{    
    public class AlertaService : IAlertaService
    {
        private readonly IDalService DalService;
        public AlertaService(IDalService dalService)
        {
            DalService = dalService;
        }
        public async Task<List<FMV_AlertaTB>> FindAll(Expression<Func<FMV_AlertaTB, bool>> match)
        {
            try
            {
                return DalService.FindAll(match);
            }
            catch (Exception ex)
            { }

            return null;
        }
        public async Task<GenericModel<FMV_AlertaTB>> FindAll(GenericModel<FMV_AlertaTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_AlertaTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.NumNota.Contains(model.Filter) || data.Producto.Contains(model.Filter) || data.DCI.Contains(model.Filter) || data.OrigenAlerta.Nombre.Contains(model.Filter)))&&
                              (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId )) &&
                              (model.AlertaNotaType == null ? true : (data.TipoAlerta == model.AlertaNotaType)) &&
                              (model.AlertaNotaStatus == null ? true : (data.Estado == model.AlertaNotaStatus))
                              orderby data.CreatedDate descending
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.NumNota.Contains(model.Filter) || data.Producto.Contains(model.Filter) || data.DCI.Contains(model.Filter) || data.OrigenAlerta.Nombre.Contains(model.Filter))) &&
                              (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId)) &&
                               (model.AlertaNotaType == null ? true : (data.TipoAlerta == model.AlertaNotaType)) &&
                               (model.AlertaNotaStatus == null ? true : (data.Estado == model.AlertaNotaStatus))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_AlertaTB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;

                model = await FindAll(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "ALERTAS_SEGURIDAD";
                    wb.Properties.Title = "ALERTAS_SEGURIDAD";
                    wb.Properties.Subject = "ALERTAS_SEGURIDAD";

                    var ws = wb.Worksheets.Add("ALERTAS_SEGURIDAD");

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
                    ws.Cell(1, 15).Value = "Monitoreo";
                    ws.Cell(1, 16).Value = "Otras";
                    ws.Cell(1, 17).Value = "Otras Descripción";
                    ws.Cell(1, 18).Value = "Número de nota";
                    ws.Cell(1, 19).Value = "Estatus";
                    ws.Cell(1, 20).Value = "Observaciones";

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
                        ws.Cell(row + 1, 15).Value = prod.Monitoreo ? "Si" : "No";
                        ws.Cell(row + 1, 16).Value = prod.OtrasConsideraciones ? "Si" : "No";
                        ws.Cell(row + 1, 17).Value = prod.OtrasDescripcion;
                        ws.Cell(row + 1, 18).Value = prod.NumNota;
                        ws.Cell(row + 1, 19).Value = DataModel.Helper.Helper.GetDescription(prod.Estado);
                        ws.Cell(row + 1, 20).Value = prod.Observaciones;
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


        public async Task<List<FMV_AlertaTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_AlertaTB> Get(long Id)
        {
            var result = DalService.Get<FMV_AlertaTB>(Id);
            return result;
        }

        public async Task<FMV_AlertaTB> Save(FMV_AlertaTB data)
        {
            var result = DalService.Save(data);
            if(result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.Adjunto).IsModified = true;
                DalService.DBContext.SaveChanges();
            }
            return result;           
        }

        public async Task<FMV_AlertaTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_AlertaTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_AlertaTB>(); }
            catch { }return 0;
        }


        ////// REPORTES ///////////////
        ///
        //Año de Recepción
        public async Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                               //(model.FromDate == null ? true : (data.Year >= model.FromDate.Value.Year)) &&
                               //(model.ToDate == null ? true : (data.Year <= model.ToDate.Value.Year)) &&
                               //(data.Year > 0)
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by data.Year into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = string.Format("ALARMAS Totales Año {0}", g.FirstOrDefault().Year),//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by data.Year into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Fármaco sospechoso DCI
        public async Task<ReportModel<ReportModelResponse>> Report2(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate)) &&
                               (data.DCI != null && data.DCI.Length > 0)
                               group data by data.DCI into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().DCI,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate)) &&
                               (data.DCI != null && data.DCI.Length > 0)
                               group data by data.DCI into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Origen
        public async Task<ReportModel<ReportModelResponse>> Report3(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate)) &&
                               (data.OrigenAlertaId!=null && data.OrigenAlertaId>0)
                               group data by data.OrigenAlertaId into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().OrigenAlerta.Nombre,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate)) &&
                               (data.OrigenAlertaId != null && data.OrigenAlertaId > 0)
                               group data by data.OrigenAlertaId into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Tipo de Alerta
        public async Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by data.TipoAlerta into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   AlertType = g.FirstOrDefault().TipoAlerta,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by data.TipoAlerta into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }


        public async Task<Stream> ExportToExcelRpt(ReportModel<ReportModelResponse> model, int RptType) {
            try {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;

                switch (RptType) {
                    case 1: {
                            model = await Report1(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "ANO_RECEPCION";
                                wb.Properties.Title = "ANO_RECEPCION";
                                wb.Properties.Subject = "ANO_RECEPCION";

                                var ws = wb.Worksheets.Add("ANO_RECEPCION");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value =string.Format("Total: {0}", model.Total);                                

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 2: {
                            model = await Report2(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Farmaco_Sospechoso_DCI";
                                wb.Properties.Title = "Farmaco_Sospechoso_DCI";
                                wb.Properties.Subject = "Farmaco_Sospechoso_DCI";

                                var ws = wb.Worksheets.Add("Farmaco_Sospechoso_DCI");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 3: {
                            model = await Report3(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Origen";
                                wb.Properties.Title = "Origen";
                                wb.Properties.Subject = "Origen";

                                var ws = wb.Worksheets.Add("Origen");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 4: {
                            model = await Report4(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Tipo_Alerta";
                                wb.Properties.Title = "Tipo_Alerta";
                                wb.Properties.Subject = "Tipo_Alerta";

                                var ws = wb.Worksheets.Add("Tipo_Alerta");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(prod.AlertType);
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                } 
            }
            catch (Exception ex) { }

            return null;
        }

    }

}
