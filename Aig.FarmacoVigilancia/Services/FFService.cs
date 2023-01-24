using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{    
    public class FFService : IFFService
    {
        private readonly IDalService DalService;
        public FFService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<List<FMV_FfTB>> FindAll(Expression<Func<FMV_FfTB, bool>> match)
        {
            try
            {
                return DalService.FindAll(match);
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<GenericModel<FMV_FfTB>> FindAll(GenericModel<FMV_FfTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_FfTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodCNFV.Contains(model.Filter) || data.CodExt.Contains(model.Filter) || data.NombreComercial.Contains(model.Filter) || data.NombreDci.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))&&
                              (model.FromDate==null?true:(data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId ))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.CodCNFV.Contains(model.Filter) || data.CodExt.Contains(model.Filter) || data.NombreComercial.Contains(model.Filter) || data.NombreDci.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter))) &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_FfTB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;
                model = await FindAll(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "FF";
                    wb.Properties.Title = "FF";
                    wb.Properties.Subject = "FF";

                    var ws = wb.Worksheets.Add("FF");

                    ws.Cell(1, 1).Value = "Código del CNFV";
                    ws.Cell(1, 2).Value = "Código Externo";
                    ws.Cell(1, 3).Value = "Fecha de Recibido (CNFV)";
                    ws.Cell(1, 4).Value = "Fecha de entrega al Evaluador";
                    ws.Cell(1, 5).Value = "Evaluador";
                    ws.Cell(1, 6).Value = "Fármaco Sospechoso (Comercial)";
                    ws.Cell(1, 7).Value = "Fármaco Sospechoso (DCI)";
                    ws.Cell(1, 8).Value = "Presentación";
                    ws.Cell(1, 9).Value = "ATC";
                    ws.Cell(1, 10).Value = "Sub-grupo Terapéutico";
                    ws.Cell(1, 11).Value = "Fabricante";
                    ws.Cell(1, 12).Value = "Lote";
                    ws.Cell(1, 13).Value = "Expira";
                    ws.Cell(1, 14).Value = "Registro Sanitario";
                    ws.Cell(1, 15).Value = "Tipo de Notificador";
                    ws.Cell(1, 16).Value = "Tipo de Organización/Institución";
                    ws.Cell(1, 17).Value = "Provincia/Región/Origen";
                    ws.Cell(1, 18).Value = "Nombre de Organización/Institución";
                    ws.Cell(1, 19).Value = "Notificador";
                    ws.Cell(1, 20).Value = "Incidencia de caso";
                    ws.Cell(1, 21).Value = "Detalle de Falla Reportada";
                    ws.Cell(1, 22).Value = "Revisión de RS (especificaciones, inserto, otro)";
                    ws.Cell(1, 23).Value = "Monitoreo";
                    ws.Cell(1, 24).Value = "Notificación al RFV";
                    ws.Cell(1, 25).Value = "Control de Calidad";
                    ws.Cell(1, 26).Value = "Resultados del Control de Calidad";
                    ws.Cell(1, 27).Value = "Investigación de campo";
                    ws.Cell(1, 28).Value = "Investigación al DAC";
                    ws.Cell(1, 29).Value = "Acciones Regulatorias Recomendadas";
                    ws.Cell(1, 30).Value = "Grado";
                    ws.Cell(1, 31).Value = "Fecha de trámite";
                    ws.Cell(1, 32).Value = "Fecha de evaluación";
                    ws.Cell(1, 33).Value = "Resoluciones emitidas";
                    ws.Cell(1, 34).Value = "Observaciones";

                    for (int row = 1; row <= model.Ldata.Count; row++)
                    {
                        var prod = model.Ldata[row - 1];
                        ws.Cell(row + 1, 1).Value = prod.CodCNFV;
                        ws.Cell(row + 1, 2).Value = prod.CodExt;
                        ws.Cell(row + 1, 3).Value = prod.FechaRecibidoCNFV?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 4).Value = prod.FechaEntregaEva?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 5).Value = prod.Evaluador?.NombreCompleto??"";
                        ws.Cell(row + 1, 6).Value = prod.NombreComercial;
                        ws.Cell(row + 1, 7).Value = prod.NombreDci;
                        ws.Cell(row + 1, 8).Value = prod.Presentacion;
                        ws.Cell(row + 1, 9).Value = prod.ATC;
                        ws.Cell(row + 1, 10).Value = prod.SubGrupoTerapeutico;
                        ws.Cell(row + 1, 11).Value = prod.Fabricant?.Nombre??"";
                        ws.Cell(row + 1, 12).Value = prod.Lote;
                        ws.Cell(row + 1, 13).Value = prod.FechaExpira?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 14).Value = prod.RegSanitario;
                        ws.Cell(row + 1, 15).Value = DataModel.Helper.Helper.GetDescription(prod.TipoNotificacion);
                        ws.Cell(row + 1, 16).Value = prod.TipoInstitucion?.Nombre;
                        ws.Cell(row + 1, 17).Value = prod.Provincia?.Nombre;
                        ws.Cell(row + 1, 18).Value = prod.InstitucionDestino?.Nombre??"";
                        ws.Cell(row + 1, 19).Value = prod.Notificador;
                        ws.Cell(row + 1, 20).Value = DataModel.Helper.Helper.GetDescription(prod.IncidenciaCaso);                        
                        ws.Cell(row + 1, 21).Value = prod.FallaReportada?.DetFallaReport??"";
                        ws.Cell(row + 1, 22).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones?.RevisionRs?? enumFMV_FfAcciones.NA); 
                        ws.Cell(row + 1, 23).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones?.Monitoreo ?? enumFMV_FfAcciones.NA);
                        ws.Cell(row + 1, 24).Value = prod.OtrasEspecificaciones.NotificacionRFV;
                        ws.Cell(row + 1, 25).Value = DataModel.Helper.Helper.GetDescription( prod.OtrasEspecificaciones.ControlCalidad);
                        ws.Cell(row + 1, 26).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones.ResultControlCalidad);
                        ws.Cell(row + 1, 27).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones.InvestCampo);
                        ws.Cell(row + 1, 28).Value = prod.OtrasEspecificaciones.InvestDAC;
                        ws.Cell(row + 1, 29).Value = prod.OtrasEspecificaciones.AccRegRecomendada;
                        ws.Cell(row + 1, 30).Value = prod.Grado;
                        ws.Cell(row + 1, 31).Value = prod.FechaTramite?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 32).Value = prod.FechaEvalua?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 33).Value = prod.ResolEmitidas;
                        ws.Cell(row + 1, 34).Value = prod.Observaciones;
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


        public async Task<List<FMV_FfTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_FfTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_FfTB> Get(long Id)
        {
            var result = DalService.Get<FMV_FfTB>(Id);
            return result;
        }

        public async Task<FMV_FfTB> Save(FMV_FfTB data)
        {
            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.FallaReportada).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.OtrasEspecificaciones).IsModified = true;
                DalService.DBContext.SaveChanges();
            }
            return result;           
        }

        public async Task<FMV_FfTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_FfTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_FfTB>(); }
            catch { }return 0;
        }


        //REPORTES

        //Fármaco sospechoso (DCI)
        public async Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.NombreDci!=null && data.NombreDci.Length > 0)
                               group data by data.NombreDci into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().NombreDci,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.NombreDci != null && data.NombreDci.Length > 0)
                               group data by data.NombreDci into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Clasificación ATC
        public async Task<ReportModel<ReportModelResponse>> Report2(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.ATC != null && data.ATC.Length > 2)
                               group data by data.SubGrupoTerapeutico into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name2 = g.FirstOrDefault().SubGrupoTerapeutico,
                                   Name = g.FirstOrDefault().ATC,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.ATC != null && data.ATC.Length > 2)
                               group data by data.SubGrupoTerapeutico into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Tipo de Notificador
        public async Task<ReportModel<ReportModelResponse>> Report3(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.TipoNotificacion into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   RAMNotificationType = g.FirstOrDefault().TipoNotificacion,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.TipoNotificacion into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Organización
        public async Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.TipoInstitucionId into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().TipoInstitucion.Nombre,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.TipoInstitucionId into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Provincia
        public async Task<ReportModel<ReportModelResponse>> Report5(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.ProvinciaId > 0)
                               group data by data.ProvinciaId into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Provincia.Nombre,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.ProvinciaId > 0)
                               group data by data.ProvinciaId into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }
        
        //Fabricante
        public async Task<ReportModel<ReportModelResponse>> Report6(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.FabricanteId > 0)
                               group data by data.FabricanteId into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Fabricant.Nombre,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.FabricanteId > 0)
                               group data by data.FabricanteId into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Año de Recepción
        public async Task<ReportModel<ReportModelResponse>> Report7(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Year >= model.FromDate.Value.Year)) &&
                               (model.ToDate == null ? true : (data.Year <= model.ToDate.Value.Year)) &&
                               (data.Year > 0)
                               group data by data.Year into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = string.Format("FF Totales Año {0}", g.FirstOrDefault().Year),//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Year >= model.FromDate.Value.Year)) &&
                               (model.ToDate == null ? true : (data.Year <= model.ToDate.Value.Year)) &&
                               (data.Year > 0)
                               group data by data.Year into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Grado
        public async Task<ReportModel<ReportModelResponse>> Report8(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))&&
                               (data.Grado != null && data.Grado.Length > 0)
                               group data by data.Grado into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Grado,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Grado != null && data.Grado.Length > 0)
                               group data by data.Grado into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }
        
        //Fármaco sospechoso Nombre Comercial
        public async Task<ReportModel<ReportModelResponse>> Report9(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.NombreComercial != null && data.NombreComercial.Length > 0)
                               group data by data.NombreComercial into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().NombreComercial,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.NombreComercial != null && data.NombreComercial.Length > 0)
                               group data by data.NombreComercial into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Presentación
        public async Task<ReportModel<ReportModelResponse>> Report10(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Presentacion != null && data.Presentacion.Length > 0)
                               group data by data.Presentacion into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Presentacion,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Presentacion != null && data.Presentacion.Length > 0)
                               group data by data.Presentacion into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Lote
        public async Task<ReportModel<ReportModelResponse>> Report11(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by new{ data.NombreComercial, data.FabricanteId, data.Lote } into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().NombreComercial,
                                   Name2 = g.FirstOrDefault().Fabricant.Nombre,
                                   Lote = g.FirstOrDefault().Lote,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by new { data.NombreComercial, data.FabricanteId, data.Lote } into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Registro Sanitario
        public async Task<ReportModel<ReportModelResponse>> Report12(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.RegSanitario != null && data.RegSanitario.Length > 0)
                               group data by data.RegSanitario into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().RegSanitario,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.RegSanitario != null && data.RegSanitario.Length > 0)
                               group data by data.RegSanitario into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Incidencia del caso 
        public async Task<ReportModel<ReportModelResponse>> Report13(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.IncidenciaCaso into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   FfTipoIncidenciaCaso = g.FirstOrDefault().IncidenciaCaso,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.IncidenciaCaso into g
                               select g.Count()).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

    }

}
