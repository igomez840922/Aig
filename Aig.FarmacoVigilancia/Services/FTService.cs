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
    public class FTService : IFTService
    {
        private readonly IDalService DalService;
        public FTService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<List<FMV_FtTB>> FindAll(Expression<Func<FMV_FtTB, bool>> match)
        {
            try
            {
                return DalService.FindAll(match);
            }
            catch (Exception ex)
            { }

            return null;
        }
        public async Task<GenericModel<FMV_FtTB>> FindAll(GenericModel<FMV_FtTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_FtTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodCNFV.Contains(model.Filter) || data.CodExt.Contains(model.Filter) || data.NombreComercial.Contains(model.Filter) || data.NombreDci.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))&&
                              (model.FromDate==null?true:(data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId ))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

        public async Task<Stream> ExportToExcel(GenericModel<FMV_FtTB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;
                model = await FindAll(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "FT";
                    wb.Properties.Title = "FT";
                    wb.Properties.Subject = "FT";

                    var ws = wb.Worksheets.Add("FT");

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
                    ws.Cell(1, 21).Value = "Número de Ingreso a Vigiflow";
                    ws.Cell(1, 22).Value = "Revisión de RS (especificaciones, inserto, otro)";
                    ws.Cell(1, 23).Value = "Monitoreo";
                    ws.Cell(1, 24).Value = "Notificación al RFV";
                    ws.Cell(1, 25).Value = "Control de Calidad";
                    ws.Cell(1, 26).Value = "Resultados del Control de Calidad";
                    ws.Cell(1, 27).Value = "Investigación de campo";
                    ws.Cell(1, 28).Value = "Investigación al DAC";
                    ws.Cell(1, 29).Value = "Acciones Regulatorias Recomendadas";
                    ws.Cell(1, 30).Value = "Grado";
                    ws.Cell(1, 31).Value = "Iniciales de Paciente";
                    ws.Cell(1, 32).Value = "Sexo";
                    ws.Cell(1, 33).Value = "Edad";
                    ws.Cell(1, 34).Value = "Historia Clínica";
                    ws.Cell(1, 35).Value = "Fecha de Tratamiento (Inicial)";
                    ws.Cell(1, 36).Value = "Fecha de Tratamiento (Final)";
                    ws.Cell(1, 37).Value = "Fecha de FT";
                    ws.Cell(1, 38).Value = "Indicación";
                    ws.Cell(1, 39).Value = "Dosis, Frecuencia, Vía de Administración";
                    ws.Cell(1, 40).Value = "Concomitantes";
                    ws.Cell(1, 41).Value = "Fármaco con cinética compleja?";
                    ws.Cell(1, 42).Value = "Condiciones clínicas que alteran la farmacocinética?";
                    ws.Cell(1, 43).Value = "El medicamento se prescribió de manera inadecuada?";
                    ws.Cell(1, 44).Value = "El medicamento se usó de manera inadecuada?";
                    ws.Cell(1, 45).Value = "Tiene un método específico de administración que requiere entrenamiento en el paciente?";
                    ws.Cell(1, 46).Value = "Existen potenciales interacciones?";
                    ws.Cell(1, 47).Value = "La notificación de FT se refiere explícitamente al uso de un medicamento genérico o una marca comercial específica?";
                    ws.Cell(1, 48).Value = "Existe algún problema biofarmacéutico estudiado?";
                    ws.Cell(1, 49).Value = "Existen deficiencias en los sistemas de almacenamiento del medicamento?";
                    ws.Cell(1, 50).Value = "Existen otros factores asociados que pudieran explicar el FT?";
                    ws.Cell(1, 51).Value = "Categoría de Causalidad";
                    ws.Cell(1, 52).Value = "Fecha de trámite";
                    ws.Cell(1, 53).Value = "Fecha de evaluación";
                    ws.Cell(1, 54).Value = "Estatus";
                    ws.Cell(1, 55).Value = "Resoluciones emitidas";
                    ws.Cell(1, 56).Value = "Observaciones";

                    for (int row = 1; row <= model.Ldata.Count; row++)
                    {
                        var prod = model.Ldata[row - 1];
                        ws.Cell(row + 1, 1).Value = prod.CodCNFV;
                        ws.Cell(row + 1, 2).Value = prod.CodExt;
                        ws.Cell(row + 1, 3).Value = prod.FechaRecibidoCNFV?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 4).Value = prod.FechaEntregaEva?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 5).Value = prod.Evaluador?.NombreCompleto ?? "";
                        ws.Cell(row + 1, 6).Value = prod.NombreComercial;
                        ws.Cell(row + 1, 7).Value = prod.NombreDci;
                        ws.Cell(row + 1, 8).Value = prod.Presentacion;
                        ws.Cell(row + 1, 9).Value = prod.ATC;
                        ws.Cell(row + 1, 10).Value = prod.SubGrupoTerapeutico;
                        ws.Cell(row + 1, 11).Value = prod.Fabricant?.Nombre ?? "";
                        ws.Cell(row + 1, 12).Value = prod.Lote;
                        ws.Cell(row + 1, 13).Value = prod.FechaExpira?.ToString("dd/MM/yyyy") ?? ""; ;
                        ws.Cell(row + 1, 14).Value = prod.RegSanitario;
                        ws.Cell(row + 1, 15).Value = DataModel.Helper.Helper.GetDescription(prod.TipoNotificacion);
                        ws.Cell(row + 1, 16).Value = prod.TipoInstitucion?.Nombre;
                        ws.Cell(row + 1, 17).Value = prod.Provincia?.Nombre;
                        ws.Cell(row + 1, 18).Value = prod.InstitucionDestino?.Nombre;
                        ws.Cell(row + 1, 19).Value = prod.Notificador;
                        ws.Cell(row + 1, 20).Value = DataModel.Helper.Helper.GetDescription(prod.IncidenciaCaso);
                        ws.Cell(row + 1, 21).Value = prod.OtrasEspecificaciones?.NumIngresoVigiflow ?? "";
                        ws.Cell(row + 1, 22).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones?.RevisionRs?? enumFMV_FfAcciones.NA);
                        ws.Cell(row + 1, 23).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones?.Monitoreo ?? enumFMV_FfAcciones.NA);
                        ws.Cell(row + 1, 24).Value = prod.OtrasEspecificaciones.NotificacionRFV;
                        ws.Cell(row + 1, 25).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones.ControlCalidad);
                        ws.Cell(row + 1, 26).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones.ResultControlCalidad);
                        ws.Cell(row + 1, 27).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones.InvestCampo);
                        ws.Cell(row + 1, 28).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones.InvestDAC);
                        ws.Cell(row + 1, 29).Value = DataModel.Helper.Helper.GetDescription(prod.OtrasEspecificaciones.AccRegRecomendada);
                        ws.Cell(row + 1, 30).Value = prod.Grado;
                        ws.Cell(row + 1, 31).Value = prod.DatosPaciente.InicialesPaciente;
                        ws.Cell(row + 1, 32).Value = DataModel.Helper.Helper.GetDescription(prod.DatosPaciente.Sexo);
                        ws.Cell(row + 1, 33).Value = prod.DatosPaciente.Edad;
                        ws.Cell(row + 1, 34).Value = prod.DatosPaciente.HistClinica;
                        ws.Cell(row + 1, 35).Value = prod.DatosPaciente.FechaTratInicial?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 36).Value = prod.DatosPaciente.FechaTratFinal?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 37).Value = prod.DatosPaciente.FechaFT?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 38).Value = prod.DatosPaciente.Indicacion;
                        ws.Cell(row + 1, 39).Value = prod.DatosPaciente.ViaAdministracion;
                        ws.Cell(row + 1, 40).Value = prod.DatosPaciente.Concomitantes;
                        ws.Cell(row + 1, 41).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.FarmCinCompleja);
                        ws.Cell(row + 1, 42).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.CondClinicas);
                        ws.Cell(row + 1, 43).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.Preescrito);
                        ws.Cell(row + 1, 44).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.UsoInad);
                        ws.Cell(row + 1, 45).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.EntrenamientoPaciente);
                        ws.Cell(row + 1, 46).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.PotInteracciones);
                        ws.Cell(row + 1, 47).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.NotificacionFT);
                        ws.Cell(row + 1, 48).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.ProBiofarmaceutico);
                        ws.Cell(row + 1, 49).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.Deficiencias);
                        ws.Cell(row + 1, 50).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.FactAsociados);
                        ws.Cell(row + 1, 51).Value = prod.EvaluacionCausalidad.CatCausalidad;
                        ws.Cell(row + 1, 52).Value = prod.FechaTramite?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 53).Value = prod.FechaEvalua?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 54).Value = DataModel.Helper.Helper.GetDescription(prod.Estatus);
                        ws.Cell(row + 1, 55).Value = prod.ResolEmitidas;
                        ws.Cell(row + 1, 56).Value = prod.Observaciones;

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

        public async Task<List<FMV_FtTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_FtTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_FtTB> Get(long Id)
        {
            var result = DalService.Get<FMV_FtTB>(Id);
            return result;
        }

        public async Task<FMV_FtTB> Save(FMV_FtTB data)
        {
            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.OtrasEspecificaciones).IsModified = true;
                //DalService.DBContext.Entry(result).Property(b => b.DatosPaciente).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.EvaluacionCausalidad).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.Concominantes).IsModified = true;
                DalService.DBContext.SaveChanges();
            }
            return result;
        }

        public async Task<FMV_FtTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_FtTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_FtTB>(); }
            catch { }return 0;
        }


        //REPORTES

        //Fármaco sospechoso (DCI)
        public async Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.NombreDci != null && data.NombreDci.Length > 0)
                               group data by data.NombreDci into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().NombreDci,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.NombreDci != null && data.NombreDci.Length > 0)
                               group data by data.NombreDci into g
                               select g.Count()).Sum(x => x);
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

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.ATC != null && data.ATC.Length > 2)
                               group data by data.SubGrupoTerapeutico into g
                               select g.Count()).Sum(x => x);
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

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
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
        public async Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
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
        public async Task<ReportModel<ReportModelResponse>> Report5(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

        //Fabricante
        public async Task<ReportModel<ReportModelResponse>> Report6(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.FabricanteId > 0)
                               group data by data.FabricanteId into g
                               select g.Count()).Sum(x => x);
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

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Year >= model.FromDate.Value.Year)) &&
                               (model.ToDate == null ? true : (data.Year <= model.ToDate.Value.Year)) &&
                               (data.Year > 0)
                               group data by data.Year into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = string.Format("FT Totales Año {0}", g.FirstOrDefault().Year),//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Year >= model.FromDate.Value.Year)) &&
                               (model.ToDate == null ? true : (data.Year <= model.ToDate.Value.Year)) &&
                               (data.Year > 0)
                               group data by data.Year into g
                               select g.Count()).Sum(x => x);
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

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Grado != null && data.Grado.Length > 0)
                               group data by data.Grado into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Grado,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Grado != null && data.Grado.Length > 0)
                               group data by data.Grado into g
                               select g.Count()).Sum(x => x);
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

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.NombreComercial != null && data.NombreComercial.Length > 0)
                               group data by data.NombreComercial into g
                               select g.Count()).Sum(x => x);
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

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Presentacion != null && data.Presentacion.Length > 0)
                               group data by data.Presentacion into g
                               select g.Count()).Sum(x => x);
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

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by new { data.NombreComercial, data.FabricanteId, data.Lote } into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().NombreComercial,
                                   Name2 = g.FirstOrDefault().Fabricant.Nombre,
                                   Lote = g.FirstOrDefault().Lote,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by new { data.NombreComercial, data.FabricanteId, data.Lote } into g
                               select g.Count()).Sum(x => x);
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

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.RegSanitario != null && data.RegSanitario.Length > 0)
                               group data by data.RegSanitario into g
                               select g.Count()).Sum(x => x);
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

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.IncidenciaCaso into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Edad
        public async Task<ReportModel<ReportModelResponse>> Report14(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.DatosPacienteId!=null && data.DatosPacienteId > 0)
                               group data by data.DatosPaciente.Edad into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().DatosPaciente.Edad,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                              (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.DatosPacienteId != null && data.DatosPacienteId > 0)
                               group data by data.DatosPaciente.Edad into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Sexo
        public async Task<ReportModel<ReportModelResponse>> Report15(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.DatosPacienteId != null && data.DatosPacienteId > 0)
                               group data by data.DatosPaciente.Sexo into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Sexo = g.FirstOrDefault().DatosPaciente.Sexo,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.DatosPacienteId != null && data.DatosPacienteId > 0)
                               group data by data.DatosPaciente.Sexo into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        ////SOC
        //public async Task<ReportModel<ReportModelResponse>> Report16(ReportModel<ReportModelResponse> model)
        //{
        //    try
        //    {
        //        model.Ldata = null; model.Total = 0;

        //        model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
        //                       where data.Deleted == false &&
        //                       (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
        //                       (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
        //                       (data.SocId != null && data.SocId > 0)
        //                       group data by data.SocId into g
        //                       orderby g.Count() descending
        //                       select new ReportModelResponse
        //                       {
        //                           Name = g.FirstOrDefault().Soc,//.Substring(0, 3),
        //                           Count = g.Count()
        //                       }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

        //        model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
        //                       where data.Deleted == false &&
        //                       (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
        //                       (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
        //                       (data.SocId != null && data.SocId > 0)
        //                       group data by data.SocId into g
        //                       select g.Count()).Sum(x => x);
        //    }
        //    catch (Exception ex)
        //    { }

        //    return model;
        //}

    }

}
