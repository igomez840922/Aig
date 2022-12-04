using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using BlazorDownloadFile;

namespace Aig.FarmacoVigilancia.Services
{    
    public class NoteService : INoteService
    {
        private readonly IDalService DalService;
        public NoteService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_NotaTB>> FindAll(GenericModel<FMV_NotaTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_NotaTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.NumNota.Contains(model.Filter) || data.Descripcion.Contains(model.Filter)))&&
                              (model.FromDate == null ? true : (data.Fecha >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.Fecha <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId )) &&
                              (model.NotaType == null ? true : (data.TipoNota == model.NotaType))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_NotaTB>()
                               where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.NumNota.Contains(model.Filter) || data.Descripcion.Contains(model.Filter))) &&
                              (model.FromDate == null ? true : (data.Fecha >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.Fecha <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId)) &&
                               (model.NotaType == null ? true : (data.TipoNota == model.NotaType))
                              select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_NotaTB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;

                model = await FindAll(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "NOTAS_SEGURIDAD";
                    wb.Properties.Title = "NOTAS_SEGURIDAD";
                    wb.Properties.Subject = "NOTAS_SEGURIDAD";

                    var ws = wb.Worksheets.Add("NOTAS_SEGURIDAD");

                    ws.Cell(1, 1).Value = "Fecha";
                    ws.Cell(1, 2).Value = "Número Nota";
                    ws.Cell(1, 3).Value = "Evaluador";
                    ws.Cell(1, 4).Value = "Tipo de Nota";
                    ws.Cell(1, 5).Value = "Descripción";
                    ws.Cell(1, 6).Value = "Destinatario";

                    for (int row = 1; row <= model.Ldata.Count; row++)
                    {//FechaRecepcion
                        var prod = model.Ldata[row - 1];
                        ws.Cell(row + 1, 1).Value = prod.Fecha?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 2).Value = prod.NumNota;
                        ws.Cell(row + 1, 3).Value = prod.Evaluador?.NombreCompleto ?? "";
                        ws.Cell(row + 1, 4).Value = DataModel.Helper.Helper.GetDescription(prod.TipoNota);
                        ws.Cell(row + 1, 5).Value = prod.Descripcion;
                        ws.Cell(row + 1, 6).Value = prod.Destinatario;
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


        public async Task<List<FMV_NotaTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_NotaTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_NotaTB> Get(long Id)
        {
            var result = DalService.Get<FMV_NotaTB>(Id);
            return result;
        }

        public async Task<FMV_NotaTB> Save(FMV_NotaTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<FMV_NotaTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_NotaTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_NotaTB>(); }
            catch { }return 0;
        }

        
    }

}
