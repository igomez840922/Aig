using DataAccess.Auditoria;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;

namespace Aig.Auditoria.Services
{    
    public class RetiredProductService : IRetiredProductService
    {
        private readonly IDalService DalService;
        public RetiredProductService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_ProdRetiroRetencionTB>> FindAll(GenericModel<AUD_ProdRetiroRetencionTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;
                model.FromDate = model.FromDate != null ? new DateTime(model.FromDate.Value.Year, model.FromDate.Value.Month, model.FromDate.Value.Day, 0, 0, 0) : model.FromDate;
                model.ToDate = model.ToDate != null ? new DateTime(model.ToDate.Value.Year, model.ToDate.Value.Month, model.ToDate.Value.Day, 23, 59, 59) : model.ToDate;

                model.Ldata = (from data in DalService.DBContext.Set<AUD_ProdRetiroRetencionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.RegSanitario.Contains(model.Filter) || data.PresentacionComercial.Contains(model.Filter) || data.Fabricante.Contains(model.Filter) || data.Lote.Contains(model.Filter) || data.Pais.Contains(model.Filter) || data.Destino.Contains(model.Filter) || data.FrmRetiroRetencion.SeccionOficinaRegional.Contains(model.Filter) || data.FrmRetiroRetencion.SeccionOficinaRegional.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.LicenseNumber.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.NumActa.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.Establecimiento.Nombre.Contains(model.Filter))) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None ? data.FrmRetiroRetencion.Inspeccion.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.FromDate != null ? data.FechaExp >= model.FromDate : true) &&
                               (model.ToDate != null ? data.FechaExp <= model.ToDate : true)
                               orderby data.CreatedDate
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_ProdRetiroRetencionTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.RegSanitario.Contains(model.Filter) || data.PresentacionComercial.Contains(model.Filter) || data.Fabricante.Contains(model.Filter) || data.Lote.Contains(model.Filter) || data.Pais.Contains(model.Filter) || data.Destino.Contains(model.Filter) || data.FrmRetiroRetencion.SeccionOficinaRegional.Contains(model.Filter) || data.FrmRetiroRetencion.SeccionOficinaRegional.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.LicenseNumber.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.NumActa.Contains(model.Filter) || data.FrmRetiroRetencion.Inspeccion.Establecimiento.Nombre.Contains(model.Filter))) &&
                               (model.StatusInspecciones != DataModel.Helper.enum_StatusInspecciones.None ? data.FrmRetiroRetencion.Inspeccion.StatusInspecciones == model.StatusInspecciones : true) &&
                               (model.FromDate != null ? data.FechaExp >= model.FromDate : true) &&
                               (model.ToDate != null ? data.FechaExp <= model.ToDate : true)
                               select data).Count();

            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<AUD_ProdRetiroRetencionTB> model)
        {
            try
            {
                model.PagIdx= 0;model.PagAmt = int.MaxValue;

                model = await FindAll(model);
               

                if(model.Ldata!=null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "Productos Retirados";
                    wb.Properties.Title = "Productos Retirados";
                    wb.Properties.Subject = "Productos Retirados";

                    var ws = wb.Worksheets.Add("Productos Retirados");

                    ws.Cell(1, 1).Value = "Estatus";
                    ws.Cell(1, 2).Value = "Sección";
                    ws.Cell(1, 3).Value = "Fecha de Inspección";
                    ws.Cell(1, 4).Value = "Establecimientos";
                    ws.Cell(1, 5).Value = "Número de Licencia";
                    ws.Cell(1, 6).Value = "Número de Acta";
                    ws.Cell(1, 7).Value = "Nombre";
                    ws.Cell(1, 8).Value = "No. Registro Sanitario";
                    ws.Cell(1, 9).Value = "Presentación Comercial";
                    ws.Cell(1, 10).Value = "Fabricante";
                    ws.Cell(1, 11).Value = "País";
                    ws.Cell(1, 12).Value = "Lote";
                    ws.Cell(1, 13).Value = "Fecha Exp.";
                    ws.Cell(1, 14).Value = "Cantidad Retenida";
                    ws.Cell(1, 15).Value = "Cantidad Retirada";
                    ws.Cell(1, 16).Value = "Destino del Producto";

                    for (int row = 1; row <= model.Ldata.Count; row++)
                    {
                        var prod = model.Ldata[row - 1];

                        ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(prod.FrmRetiroRetencion?.Inspeccion?.StatusInspecciones ?? enum_StatusInspecciones.None);
                        ws.Cell(row + 1, 2).Value = prod.FrmRetiroRetencion?.SeccionOficinaRegional ?? "";
                        ws.Cell(row + 1, 3).Value = prod.FrmRetiroRetencion?.Inspeccion?.FechaInicio.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 4).Value = prod.FrmRetiroRetencion?.Inspeccion?.Establecimiento?.Nombre ?? "";
                        ws.Cell(row + 1, 5).Value = prod.FrmRetiroRetencion?.Inspeccion?.LicenseNumber ?? "";
                        ws.Cell(row + 1, 6).Value = prod.FrmRetiroRetencion?.Inspeccion?.NumActa ?? "";
                        ws.Cell(row + 1, 7).Value = prod.Nombre;
                        ws.Cell(row + 1, 8).Value = prod.RegSanitario;
                        ws.Cell(row + 1, 9).Value = prod.PresentacionComercial;
                        ws.Cell(row + 1, 10).Value = prod.Fabricante;
                        ws.Cell(row + 1, 11).Value = prod.Pais;
                        ws.Cell(row + 1, 12).Value = prod.Lote;
                        ws.Cell(row + 1, 13).Value = prod.FechaExp?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 14).Value = prod.CantidadRetenida;
                        ws.Cell(row + 1, 15).Value = prod.CantidadRetirada;
                        ws.Cell(row + 1, 16).Value = prod.Destino;
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

        public async Task<List<AUD_ProdRetiroRetencionTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_ProdRetiroRetencionTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_ProdRetiroRetencionTB> Get(long Id)
        {
            var result = DalService.Get<AUD_ProdRetiroRetencionTB>(Id);
            return result;
        }

        public async Task<AUD_ProdRetiroRetencionTB> Save(AUD_ProdRetiroRetencionTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<AUD_ProdRetiroRetencionTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_ProdRetiroRetencionTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_ProdRetiroRetencionTB>(); }
            catch { }return 0;
        }
    }

}
