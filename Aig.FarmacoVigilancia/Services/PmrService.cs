using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;

namespace Aig.FarmacoVigilancia.Services
{    
    public class PmrService : IPmrService
    {
        private readonly IDalService DalService;
        public PmrService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_PmrTB>> FindAll(GenericModel<FMV_PmrTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<FMV_PmrTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.PrincActivo.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))&&
                              (model.FromDate == null ? true : (data.FechaEntrada >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaEntrada <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_PmrTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.PrincActivo.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter))) &&
                              (model.FromDate == null ? true : (data.FechaEntrada >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaEntrada <= model.ToDate)) &&
                               (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_PmrTB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;

                model = await FindAll(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "PLAN_MANEJO_RIESGO";
                    wb.Properties.Title = "PLAN_MANEJO_RIESGO";
                    wb.Properties.Subject = "PLAN_MANEJO_RIESGO";

                    var ws = wb.Worksheets.Add("PLAN_MANEJO_RIESGO");

                    ws.Cell(1, 1).Value = "Fecha de Entrada";
                    ws.Cell(1, 2).Value = "Fecha de Entrega a Evaluador";
                    ws.Cell(1, 3).Value = "Fecha de Trámite";
                    ws.Cell(1, 4).Value = "Evaluador";
                    ws.Cell(1, 5).Value = "Registro Sanitario";
                    ws.Cell(1, 6).Value = "Principio Activo";
                    ws.Cell(1, 7).Value = "Nombre Comercial";
                    ws.Cell(1, 8).Value = "Laboratorio";

                    var rowCount = 1;
                    for (int row = 1; row <= model.Ldata.Count; row++)
                    {
                        var prod = model.Ldata[row - 1];
                        if(prod.LProductos!=null && prod.LProductos.Count > 0)
                        {
                            for (int rowChild = 1; rowChild <= prod.LProductos.Count; rowChild++)
                            {
                                var prodChild = prod.LProductos[rowChild - 1];

                                ws.Cell(rowCount + 1, 1).Value = prod.FechaEntrada?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(rowCount + 1, 2).Value = prod.FechaEntregaEvaluador?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(rowCount + 1, 3).Value = prod.FechaTramite?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(rowCount + 1, 4).Value = prod.Evaluador?.NombreCompleto ?? "";
                                ws.Cell(rowCount + 1, 5).Value = prodChild.RegSanitario;
                                ws.Cell(rowCount + 1, 6).Value = prod.PrincActivo;
                                ws.Cell(rowCount + 1, 7).Value = prodChild.NomComercial;
                                ws.Cell(rowCount + 1, 8).Value = prodChild.Laboratorio?.Nombre??"";
                                rowCount++;
                            }
                        }
                        else
                        {
                            ws.Cell(rowCount + 1, 1).Value = prod.FechaEntrada?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(rowCount + 1, 2).Value = prod.FechaEntregaEvaluador?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(rowCount + 1, 3).Value = prod.FechaTramite?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(rowCount + 1, 4).Value = prod.Evaluador?.NombreCompleto ?? "";
                            ws.Cell(rowCount + 1, 5).Value = "";
                            ws.Cell(rowCount + 1, 6).Value = prod.PrincActivo;
                            ws.Cell(rowCount + 1, 7).Value = "";
                            ws.Cell(rowCount + 1, 8).Value = "";
                            rowCount++;
                        }
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


        public async Task<List<FMV_PmrTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_PmrTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_PmrTB> Get(long Id)
        {
            var result = DalService.Get<FMV_PmrTB>(Id);
            return result;
        }

        public async Task<FMV_PmrTB> Save(FMV_PmrTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<FMV_PmrTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_PmrTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_PmrTB>(); }
            catch { }return 0;
        }
    }

}
