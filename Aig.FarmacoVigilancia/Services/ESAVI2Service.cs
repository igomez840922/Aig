using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{    
    public class ESAVI2Service : IESAVI2Service
    {
        private readonly IDalService DalService;
        public ESAVI2Service(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<List<FMV_Esavi2TB>> FindAll(Expression<Func<FMV_Esavi2TB, bool>> match)
        {
            try
            {
                return DalService.FindAll(match);
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<GenericModel<FMV_Esavi2TB>> FindAll(GenericModel<FMV_Esavi2TB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodigoNotiFacedra.Contains(model.Filter) || data.IdFacedra.Contains(model.Filter) || data.CodCNFV.Contains(model.Filter) || data.CodExt.Contains(model.Filter) || data.VacunasDesc.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter) || data.InstitucionDestino.Nombre.Contains(model.Filter)))&&
                              (model.FromDate==null?true:(data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId ))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.CodigoNotiFacedra.Contains(model.Filter) || data.IdFacedra.Contains(model.Filter) || data.CodCNFV.Contains(model.Filter) || data.CodExt.Contains(model.Filter) || data.VacunasDesc.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter) || data.InstitucionDestino.Nombre.Contains(model.Filter))) &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_Esavi2TB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;
                model = await FindAll(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "ESAVI".ToUpper();
                    wb.Properties.Title = "ESAVI".ToUpper();
                    wb.Properties.Subject = "ESAVI".ToUpper();

                    var ws = wb.Worksheets.Add("ESAVI".ToUpper());

                    ws.Cell(1, 1).Value = "Origen de la Notificación";
                    ws.Cell(1, 2).Value = "Código de Notifacedra";
                    ws.Cell(1, 3).Value = "ID de Facedra";
                    ws.Cell(1, 4).Value = "Código Externo";
                    ws.Cell(1, 5).Value = "Código del CNFV";
                    ws.Cell(1, 6).Value = "Fecha de Recibido (CNFV)";
                    ws.Cell(1, 7).Value = "Fecha Entrega a Evaluador";
                    ws.Cell(1, 8).Value = "Evaluador";
                    ws.Cell(1, 9).Value = "Notificacior";
                    ws.Cell(1, 10).Value = "Tipo de Notificador";
                    ws.Cell(1, 11).Value = "Tipo de Organización";
                    ws.Cell(1, 12).Value = "Provincia";
                    ws.Cell(1, 13).Value = "Organización";
                    ws.Cell(1, 14).Value = "Otros Diagnosticos";
                    ws.Cell(1, 15).Value = "Sexo";
                    ws.Cell(1, 16).Value = "Edad";
                    ws.Cell(1, 17).Value = "Historia Clínica";
                    ws.Cell(1, 18).Value = "Datos del Laboratorio";
                    ws.Cell(1, 19).Value = "Nombre Completo de la Persona";
                    ws.Cell(1, 20).Value = "Iniciales de Paciente";
                    ws.Cell(1, 21).Value = "Cedula";
                    ws.Cell(1, 22).Value = "Medicamentos Concominante";
                    ws.Cell(1, 23).Value = "Detalles del Caso";
                    ws.Cell(1, 24).Value = "Fecha de Evaluación";
                    ws.Cell(1, 25).Value = "Estatus";
                    ws.Cell(1, 26).Value = "Observaciones";
                    ws.Cell(1, 27).Value = "Hay ESAVI?";
                    ws.Cell(1, 28).Value = "Fecha de ESAVI";
                    ws.Cell(1, 29).Value = "Desenlace";
                    ws.Cell(1, 30).Value = "ESAVI";
                    ws.Cell(1, 31).Value = "Termino WhoArt (LLC)";
                    ws.Cell(1, 32).Value = "SOC";
                    ws.Cell(1, 33).Value = "Intensidad de la ESAVI";
                    ws.Cell(1, 34).Value = "Gravedad";
                    ws.Cell(1, 35).Value = "Otros Criterios";
                    ws.Cell(1, 36).Value = "Elegibilidad por Gravedad";
                    ws.Cell(1, 37).Value = "Elegibilidad por Otro Criterio";
                    ws.Cell(1, 38).Value = "Elegibilidad por Evaluacion de Causalidad";
                    ws.Cell(1, 39).Value = "Probabilidad de Asosiación Causal con la Inmunización";
                    ws.Cell(1, 40).Value = "Vacuna Sospechosa (Comercial)";
                    ws.Cell(1, 41).Value = "Descripción de Vacuna";
                    ws.Cell(1, 42).Value = "DFabricante";
                    ws.Cell(1, 43).Value = "Lote";
                    ws.Cell(1, 44).Value = "Expira";
                    ws.Cell(1, 45).Value = "Reg. Sanitario";
                    ws.Cell(1, 46).Value = "Fecha de Vacunación";
                    ws.Cell(1, 47).Value = "Indicaciones";
                    ws.Cell(1, 48).Value = "Dosis y Via de Administración";
                    ws.Cell(1, 49).Value = "Dosis en que se presenta el ESAVI";

                    var row = 1;
                    foreach (var notifica in model.Ldata)
                    {
                        foreach (var vac in notifica.LVacunas)
                        {
                            foreach (var data in vac.LEsavis)
                            {
                                ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(notifica.OrigenNotificacion);
                                ws.Cell(row + 1, 2).Value = notifica.CodigoNotiFacedra;
                                ws.Cell(row + 1, 3).Value = notifica.IdFacedra;
                                ws.Cell(row + 1, 4).Value = notifica.CodExt;
                                ws.Cell(row + 1, 5).Value = notifica.CodCNFV;
                                ws.Cell(row + 1, 6).Value = notifica.FechaRecibidoCNFV?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row + 1, 7).Value = notifica.FechaEntregaEva?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row + 1, 8).Value = notifica.Evaluador?.NombreCompleto ?? "";
                                ws.Cell(row + 1, 9).Value = notifica.Notificador;
                                ws.Cell(row + 1, 10).Value = DataModel.Helper.Helper.GetDescription(notifica.TipoNotificacion);
                                ws.Cell(row + 1, 11).Value = notifica.TipoInstitucion?.Nombre ?? "";
                                ws.Cell(row + 1, 12).Value = notifica.Provincia?.Nombre ?? "";
                                ws.Cell(row + 1, 13).Value = notifica.InstitucionDestino?.Nombre ?? "";
                                ws.Cell(row + 1, 14).Value = notifica.OtrosDiagnosticos;
                                ws.Cell(row + 1, 15).Value = DataModel.Helper.Helper.GetDescription(notifica.Sexo);
                                ws.Cell(row + 1, 16).Value = notifica.Edad;
                                ws.Cell(row + 1, 17).Value = notifica.HistoriaClinica;
                                ws.Cell(row + 1, 18).Value = notifica.DatosLab;
                                ws.Cell(row + 1, 19).Value = notifica.NombreCompletoPersona;
                                ws.Cell(row + 1, 20).Value = notifica.InicialesPersona;
                                ws.Cell(row + 1, 21).Value = notifica.Cedula;
                                //ws.Cell(row + 1, 22).Value = data.MedicamentoContaminante;
                                ws.Cell(row + 1, 23).Value = DataModel.Helper.Helper.GetDescription(data.InvDetalleCaso);
                                ws.Cell(row + 1, 24).Value = notifica.FechaEvalua?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row + 1, 25).Value = DataModel.Helper.Helper.GetDescription(notifica.Estatus);
                                ws.Cell(row + 1, 26).Value = notifica.Observaciones;
                                ws.Cell(row + 1, 27).Value = DataModel.Helper.Helper.GetDescription(data.HayEsavi);
                                ws.Cell(row + 1, 28).Value = data.FechaEsavi;
                                ws.Cell(row + 1, 29).Value = DataModel.Helper.Helper.GetDescription(data.Desenlace);
                                ws.Cell(row + 1, 30).Value = data.EsaviDescripcion;
                                ws.Cell(row + 1, 31).Value = data.TerWhoArt;
                                ws.Cell(row + 1, 32).Value = data.Soc;// DataModel.Helper.Helper.GetDescription(prod.SOC);
                                ws.Cell(row + 1, 33).Value = string.Format("{0} {1}", data.IntensidadEsavi?.Nombre ?? "", data.IntensidadEsavi?.Gravedad ?? ""); //prod.Intensidad;
                                ws.Cell(row + 1, 34).Value = data.Gravedad;
                                ws.Cell(row + 1, 35).Value = DataModel.Helper.Helper.GetDescription(data.OtrosCriterios);
                                ws.Cell(row + 1, 36).Value = data.ElegibilidadGravedad;
                                ws.Cell(row + 1, 37).Value = data.ElegibilidadOtroCriterio;
                                ws.Cell(row + 1, 38).Value = data.ElegibleEvaluacionCausal;
                                ws.Cell(row + 1, 39).Value = DataModel.Helper.Helper.GetDescription(data.ProbabilidadAsociacion);
                                ws.Cell(row + 1, 40).Value = vac.VacunaComercial;
                                ws.Cell(row + 1, 41).Value = vac.TipoVacuna?.Nombre ?? ""; //prod.DescripVacuna;
                                ws.Cell(row + 1, 42).Value = vac.Laboratorio?.Nombre ?? ""; //prod.DescripVacuna;
                                ws.Cell(row + 1, 43).Value = vac.Lote;
                                ws.Cell(row + 1, 44).Value = vac.FechaExp?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row + 1, 45).Value = vac.RegSanitario;
                                ws.Cell(row + 1, 46).Value = vac.FechaVacunacion;
                                ws.Cell(row + 1, 47).Value = vac.Indicaciones;
                                ws.Cell(row + 1, 48).Value = vac.DosisViaAdmin;
                                ws.Cell(row + 1, 49).Value = DataModel.Helper.Helper.GetDescription(vac.DosisPresenta);

                                row++;
                            }
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

        public async Task<List<FMV_Esavi2TB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_Esavi2TB> Get(long Id)
        {
            var result = DalService.Get<FMV_Esavi2TB>(Id);
            return result;
        }

        public async Task<FMV_Esavi2TB> Save(FMV_Esavi2TB data)
        {            
            //if (data.LNotificaciones != null)
            //{
            //    foreach (var item in data.LNotificaciones)
            //    {
            //        //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
            //        DalService.DBContext.Entry(item).Property(b => b.FallaReportada).IsModified = true;
            //        DalService.DBContext.Entry(item).Property(b => b.EvaluacionCausalidad).IsModified = true;
            //    }
            //}

            var result = DalService.Save(data);
            if (result != null)
            {                
                DalService.DBContext.Entry(result).Property(b => b.Adjunto).IsModified = true;
                DalService.DBContext.SaveChanges();
            }

            return result;           
        }

        public async Task<FMV_Esavi2TB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_Esavi2TB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_Esavi2TB>(); }
            catch { }return 0;
        }

        //REPORTES

        //Tipo de Vacuna
        public async Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_EsaviVacunaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Esavi.FechaRecibidoCNFV <= model.ToDate))&&
                               (data.TipoVacunaId > 0)
                               group data by data.TipoVacunaId into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().TipoVacuna.Nombre,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_EsaviVacunaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.TipoVacunaId > 0)
                               group data by data.TipoVacunaId into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //ESAVI
        public async Task<ReportModel<ReportModelResponse>> Report3(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.EsaviDescripcion != null && data.EsaviDescripcion.Length > 0)
                                  group data by new { data.EsaviVacuna.EsaviId, data.EsaviDescripcion } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse
                                  {
                                      Name = g.FirstOrDefault().EsaviDescripcion,//.Substring(0, 3),
                                      Count = 1,//g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               orderby gFinal.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = gFinal.FirstOrDefault().Name,//.Substring(0, 3),
                                   Count = gFinal.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.EsaviDescripcion != null && data.EsaviDescripcion.Length > 0)
                                  group data by new { data.EsaviVacuna.EsaviId, data.EsaviDescripcion } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse
                                  {
                                      Name = g.FirstOrDefault().EsaviDescripcion,//.Substring(0, 3),
                                      Count = g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               //orderby gFinal.Count() descending
                               select gFinal.Count()).Sum(x => x);


                //model.Ldata = (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.EsaviDescripcion != null && data.EsaviDescripcion.Length > 0)
                //               group data by data.EsaviDescripcion into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().EsaviDescripcion,//.Substring(0, 3),
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.EsaviDescripcion != null && data.EsaviDescripcion.Length > 0)
                //               group data by data.EsaviDescripcion into g
                //               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Origen de Notificacion
        public async Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.OrigenNotificacion into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   RAMOrigenType = g.FirstOrDefault().OrigenNotificacion,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.OrigenNotificacion into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Gravedad
        public async Task<ReportModel<ReportModelResponse>> Report5(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from dataFinal in
                                (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                                 where data.Deleted == false &&
                                 (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                                 (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                                 (data.EsaviDescripcion != null && data.EsaviDescripcion.Length > 0)
                                 group data by new { data.EsaviVacuna.EsaviId, data.EsaviDescripcion, data.Gravedad } into g
                                 orderby g.Count() descending
                                 select new ReportModelResponse
                                 {
                                     Name = g.FirstOrDefault().Gravedad,//.Substring(0, 3),
                                     Count = 1,//g.Count()
                                 })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               orderby gFinal.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = gFinal.FirstOrDefault().Name,//.Substring(0, 3),
                                   Count = gFinal.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                                 (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                                 (data.EsaviDescripcion != null && data.EsaviDescripcion.Length > 0)
                                  group data by new { data.EsaviVacuna.EsaviId, data.EsaviDescripcion, data.Gravedad } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse
                                  {
                                      Name = g.FirstOrDefault().Gravedad,//.Substring(0, 3),
                                      Count = g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               //orderby gFinal.Count() descending
                               select gFinal.Count()).Sum(x => x);

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.Gravedad != null && data.Gravedad.Length > 0)
                //               group data by data.Gravedad into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().Gravedad,//.Substring(0, 3),
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.Gravedad != null && data.Gravedad.Length > 0)
                //               group data by data.Gravedad into g
                //               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Desenlace
        public async Task<ReportModel<ReportModelResponse>> Report6(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from dataFinal in
                                (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                                 where data.Deleted == false &&
                                 (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                                 (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                                 (data.EsaviDescripcion != null && data.EsaviDescripcion.Length > 0)
                                 group data by new { data.EsaviVacuna.EsaviId, data.EsaviDescripcion, data.Desenlace } into g
                                 orderby g.Count() descending
                                 select new ReportModelResponse
                                 {
                                     RAMDesenlace = g.FirstOrDefault().Desenlace,//.Substring(0, 3),
                                     Count = 1,//g.Count()
                                 })
                               group dataFinal by new { dataFinal.RAMDesenlace } into gFinal
                               orderby gFinal.Count() descending
                               select new ReportModelResponse
                               {
                                   RAMDesenlace = gFinal.FirstOrDefault().RAMDesenlace,//.Substring(0, 3),
                                   Count = gFinal.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                                 (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                                 (data.EsaviDescripcion != null && data.EsaviDescripcion.Length > 0)
                                  group data by new { data.EsaviVacuna.EsaviId, data.EsaviDescripcion, data.Desenlace } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse
                                  {
                                      RAMDesenlace = g.FirstOrDefault().Desenlace,//.Substring(0, 3),
                                      Count = 1,//g.Count()
                                  })
                               group dataFinal by new { dataFinal.RAMDesenlace } into gFinal
                               //orderby gFinal.Count() descending
                               select gFinal.Count()).Sum(x => x);

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate))
                //               group data by data.Desenlace into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   RAMDesenlace = g.FirstOrDefault().Desenlace,//.Substring(0, 3),
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate))
                //               group data by data.Desenlace into g
                //               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //SOC
        public async Task<ReportModel<ReportModelResponse>> Report7(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.EsaviDescripcion != null && data.EsaviDescripcion.Length > 0)
                                  group data by new { data.EsaviVacuna.EsaviId, data.EsaviDescripcion, data.SocId } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse
                                  {
                                      Name = g.FirstOrDefault().Soc,//.Substring(0, 3),
                                      Count = 1,//g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               orderby gFinal.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = gFinal.FirstOrDefault().Name,//.Substring(0, 3),
                                   Count = gFinal.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.EsaviDescripcion != null && data.EsaviDescripcion.Length > 0)
                                  group data by new { data.EsaviVacuna.EsaviId, data.EsaviDescripcion, data.SocId } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse
                                  {
                                      Name = g.FirstOrDefault().Soc,//.Substring(0, 3),
                                      Count = g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               //orderby gFinal.Count() descending
                               select gFinal.Count()).Sum(x => x);

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.SocId != null && data.SocId > 0)
                //               group data by data.SocId into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().Soc,//.Substring(0, 3),
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.SocId != null && data.SocId > 0)
                //               group data by data.SocId into g
                //               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Probabilidades
        public async Task<ReportModel<ReportModelResponse>> Report8(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.ProbabilidadAsociacion into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   EsaviProbabilidadAsociacion = g.FirstOrDefault().ProbabilidadAsociacion,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_EsaviVacunaEsaviTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.EsaviVacuna.Esavi.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.ProbabilidadAsociacion into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Sexo
        public async Task<ReportModel<ReportModelResponse>> Report9(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.Sexo into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Sexo = g.FirstOrDefault().Sexo,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.Sexo into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Edad
        public async Task<ReportModel<ReportModelResponse>> Report10(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.Edad into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Edad,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.Edad into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Tipo de Notificador
        public async Task<ReportModel<ReportModelResponse>> Report12(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.TipoNotificacion into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Organización
        public async Task<ReportModel<ReportModelResponse>> Report13(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.TipoInstitucionId into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Provincia
        public async Task<ReportModel<ReportModelResponse>> Report14(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))&&
                               (data.ProvinciaId > 0)
                               group data by data.ProvinciaId into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Provincia.Nombre,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.ProvinciaId > 0)
                               group data by data.ProvinciaId into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Año de Recepción
        public async Task<ReportModel<ReportModelResponse>> Report15(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))&&
                               (data.Year > 0)
                               group data by data.Year into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = string.Format("ESAVI Totales Año {0}", g.FirstOrDefault().Year),//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Year > 0)
                               group data by data.Year into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

    }

}
