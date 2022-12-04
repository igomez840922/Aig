using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace Aig.FarmacoVigilancia.Services
{    
    public class RfvService : IRfvService
    {
        private readonly IDalService DalService;
        public RfvService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_RfvTB>> FindAll(GenericModel<FMV_RfvTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_RfvTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.NombreCompleto.Contains(model.Filter) || data.Cargo.Contains(model.Filter) || data.DireccionFisica.Contains(model.Filter) || data.Telefonos.Contains(model.Filter) || data.Correos.Contains(model.Filter)))&&
                              (model.LabId == null ? true : (data.LaboratorioId == model.LabId )) &&
                              (model.UbicationType == null ? true : (data.TipoUbicacion == model.UbicationType))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_RfvTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NombreCompleto.Contains(model.Filter) || data.Cargo.Contains(model.Filter) || data.DireccionFisica.Contains(model.Filter) || data.Telefonos.Contains(model.Filter) || data.Correos.Contains(model.Filter))) &&
                               (model.LabId == null ? true : (data.LaboratorioId == model.LabId)) &&
                               (model.UbicationType == null ? true : (data.TipoUbicacion == model.UbicationType))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_RfvTB> model)
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

                    ws.Cell(1, 1).Value = "Empresa";
                    ws.Cell(1, 2).Value = "País";
                    ws.Cell(1, 3).Value = "Categoría";
                    ws.Cell(1, 4).Value = "Ubicación";
                    ws.Cell(1, 5).Value = "Nombre";
                    ws.Cell(1, 6).Value = "Cargo";
                    ws.Cell(1, 7).Value = "Dirección Física";
                    ws.Cell(1, 8).Value = "Telefono";
                    ws.Cell(1, 9).Value = "Correo";
                    ws.Cell(1, 10).Value = "Tipo";
                    ws.Cell(1, 11).Value = "Fecha Notificación";
                    ws.Cell(1, 12).Value = "Observaciones";

                    for (int row = 1; row <= model.Ldata.Count; row++)
                    {
                        var prod = model.Ldata[row - 1];
                        ws.Cell(row + 1, 1).Value = prod.Laboratorio?.Nombre ?? "";
                        ws.Cell(row + 1, 2).Value = prod.Laboratorio?.Pais ?? "";
                        ws.Cell(row + 1, 3).Value = DataModel.Helper.Helper.GetDescription(prod.Laboratorio?.TipoLaboratorio ?? enum_LaboratoryType.Laboratory);
                        ws.Cell(row + 1, 4).Value = DataModel.Helper.Helper.GetDescription(prod.Laboratorio?.TipoUbicacion ?? enum_UbicationType.Local);
                        ws.Cell(row + 1, 5).Value = prod.NombreCompleto;
                        ws.Cell(row + 1, 6).Value = prod.Cargo;
                        ws.Cell(row + 1, 7).Value = prod.DireccionFisica;
                        ws.Cell(row + 1, 8).Value = prod.Telefonos;
                        ws.Cell(row + 1, 9).Value = prod.Correos;
                        ws.Cell(row + 1, 10).Value = DataModel.Helper.Helper.GetDescription(prod.TipoUbicacion);
                        ws.Cell(row + 1, 11).Value = prod.FechaNotificacion?.ToString("dd/MM/yyyy")??"";
                        ws.Cell(row + 1, 12).Value = prod.Observaciones;
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


        public async Task<List<FMV_RfvTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_RfvTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_RfvTB> Get(long Id)
        {
            var result = DalService.Get<FMV_RfvTB>(Id);
            return result;
        }

        public async Task<FMV_RfvTB> Save(FMV_RfvTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<FMV_RfvTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_RfvTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_RfvTB>(); }
            catch { }return 0;
        }
    }

}
