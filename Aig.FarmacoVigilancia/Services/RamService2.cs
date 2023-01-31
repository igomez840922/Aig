﻿using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Linq.Expressions;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace Aig.FarmacoVigilancia.Services
{    
    public class RamService2 : IRamService2
    {
        private readonly IDalService DalService;
        public RamService2(IDalService dalService)
        {
            DalService = dalService;
        }
        public async Task<List<FMV_Ram2TB>> FindAll(Expression<Func<FMV_Ram2TB, bool>> match)
        {
            try
            {
                return DalService.FindAll(match);
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<GenericModel<FMV_Ram2TB>> FindAll(GenericModel<FMV_Ram2TB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_Ram2TB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodigoCNFV.Contains(model.Filter) || data.IdFacedra.Contains(model.Filter) || data.CodigoNotiFacedra.Contains(model.Filter) || data.CodExterno.Contains(model.Filter) || data.FarmacosDesc.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))&&
                              (model.FromDate==null?true:(data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId ))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodigoCNFV.Contains(model.Filter) || data.IdFacedra.Contains(model.Filter) || data.CodigoNotiFacedra.Contains(model.Filter) || data.CodExterno.Contains(model.Filter) || data.FarmacosDesc.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter))) &&
                              (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_Ram2TB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;
                model = await FindAll(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "RAM";
                    wb.Properties.Title = "RAM";
                    wb.Properties.Subject = "RAM";

                    var ws = wb.Worksheets.Add("RAM");
                    int idx = 1;
                    ws.Cell(1, idx).Value = "Fecha de Recibido (CNFV)";
                    idx++;
                    ws.Cell(1, idx).Value = "Fecha de entrega al Evaluador";
                    idx++;
                    ws.Cell(1, idx).Value = "Evaluador";
                    idx++;
                    ws.Cell(1, idx).Value = "Fármaco Sospechoso (Comercial)";
                    idx++;
                    ws.Cell(1, idx).Value = "Fármaco Sospechoso (DCI)";
                    idx++;
                    ws.Cell(1, idx).Value = "ATC";
                    idx++;
                    ws.Cell(1, idx).Value = "Sub-grupo Terapéutico";
                    idx++;
                    ws.Cell(1, idx).Value = "Hay RAM?";
                    idx++;
                    ws.Cell(1, idx).Value = "Origen de la Notificación";
                    idx++;
                    ws.Cell(1, idx).Value = "Código de Facedra";
                    idx++;
                    ws.Cell(1, idx).Value = "ID Facedra";
                    idx++;
                    ws.Cell(1, idx).Value = "Código del CNFV";
                    idx++;
                    ws.Cell(1, idx).Value = "Código Externo";
                    idx++;
                    ws.Cell(1, idx).Value = "Tipo de Notificador";
                    idx++;
                    ws.Cell(1, idx).Value = "Tipo de Organización/Institución";
                    idx++;
                    ws.Cell(1, idx).Value = "Provincia/Región/Origen";
                    idx++;
                    ws.Cell(1, idx).Value = "Nombre de Organización/Institución";
                    //ws.Cell(1, 18).Value = "Número de Ingreso a Vigiflow";
                    idx++;
                    ws.Cell(1, idx).Value = "Fecha de evaluación";
                    idx++;
                    ws.Cell(1, idx).Value = "Estatus";
                    idx++;
                    ws.Cell(1, idx).Value = "Fecha de Tratamiento";
                    idx++;
                    ws.Cell(1, idx).Value = "Fecha de RAM";
                    idx++;
                    ws.Cell(1, idx).Value = "Desenlace";
                    idx++;
                    ws.Cell(1, idx).Value = "Indicación";
                    idx++;
                    ws.Cell(1, idx).Value = "Conducta Sobre Dosis";
                    idx++;
                    ws.Cell(1, idx).Value = "Conducta Sobre Terapia";
                    idx++;
                    ws.Cell(1, idx).Value = "Evolucion Sobre Dosis";
                    idx++;
                    ws.Cell(1, idx).Value = "Evolucion Sobre Terapia";
                    idx++;
                    ws.Cell(1, idx).Value = "Otros Diagnósticos";
                    idx++;
                    ws.Cell(1, idx).Value = "Sexo";
                    idx++;
                    ws.Cell(1, idx).Value = "Edad";
                    idx++;
                    ws.Cell(1, idx).Value = "Historia Clinica";
                    idx++;
                    ws.Cell(1, idx).Value = "Datos del Laboratorio";
                    idx++;
                    ws.Cell(1, idx).Value = "Reexposición";
                    idx++;
                    ws.Cell(1, idx).Value = "Consecuencia de Reexposición";
                    idx++;
                    ws.Cell(1, idx).Value = "RAM con una sola dosis";
                    idx++;
                    ws.Cell(1, idx).Value = "Grado";
                    idx++;
                    ws.Cell(1, idx).Value = "Iniciales del Paciente";
                    idx++;
                    ws.Cell(1, idx).Value = "Dosis, Frecuencia, Vía de Administración";
                    idx++;
                    ws.Cell(1, idx).Value = "RAM";
                    idx++;
                    ws.Cell(1, idx).Value = "TERMINO WHOArt (LLT)";
                    idx++;
                    ws.Cell(1, idx).Value = "SOC";
                    idx++;
                    ws.Cell(1, idx).Value = "Concomitante";
                    idx++;
                    ws.Cell(1, idx).Value = "Secuencia temporal";
                    idx++;
                    ws.Cell(1, idx).Value = "STEMP";
                    idx++;
                    ws.Cell(1, idx).Value = "Conocimiento previo";
                    idx++;
                    ws.Cell(1, idx).Value = "CPREV";
                    idx++;
                    ws.Cell(1, idx).Value = "Efecto de Retirada";
                    idx++;
                    ws.Cell(1, idx).Value = "RETI";
                    idx++;
                    ws.Cell(1, idx).Value = "Efecto de Reexposición";
                    idx++;
                    ws.Cell(1, idx).Value = "REEX";
                    idx++;
                    ws.Cell(1, idx).Value = "Causas Alternativas";
                    idx++;
                    ws.Cell(1, idx).Value = "ALTER";
                    idx++;
                    ws.Cell(1, idx).Value = "Factores Contribuyentes";
                    idx++;
                    ws.Cell(1, idx).Value = "FACON";
                    idx++;
                    ws.Cell(1, idx).Value = "XPLC";
                    idx++;
                    ws.Cell(1, idx).Value = "Puntuación";
                    idx++;
                    ws.Cell(1, idx).Value = "Probabilidad";
                    idx++;
                    ws.Cell(1, idx).Value = "Intesidad de la RAM";
                    idx++;
                    ws.Cell(1, idx).Value = "Gravedad";
                    idx++;
                    ws.Cell(1, idx).Value = "Referencia";
                    idx++;
                    ws.Cell(1, idx).Value = "Incongruencia Conducta_No Disminuyó Dosis /Evolución";
                    idx++;
                    ws.Cell(1, idx).Value = "Incongruencia Conducta_Mantuvo la Terapia/Evolución";
                    idx++;
                    ws.Cell(1, idx).Value = "Incongruencia Conducta_Suspendió la terapia/ REEX";
                    idx++;
                    ws.Cell(1, idx).Value = "Incongruencia Conducta_Mantuvo la terapia/ REEX";
                    idx++;
                    ws.Cell(1, idx).Value = "Incongruencia Reexposicion Conducta_Mantuvo la terapia/ REEX";
                    idx++;
                    ws.Cell(1, idx).Value = "Incongruencia Reexposición/Consecuencia de REEX";
                    
                    //ws.Cell(1, 68).Value = "Recomendaciones a Profesionales y Pacientes";
                    //ws.Cell(1, 69).Value = "Actualización de monografía e inserto";
                    //ws.Cell(1, 70).Value = "Suspensión y retiro de lote(s)";
                    //ws.Cell(1, 71).Value = "Registro Sanitario (Suspensión/Cancelación)";
                    //ws.Cell(1, 72).Value = "Otras";
                    //ws.Cell(1, 73).Value = "Observaciones";

                    var row = 1;
                    foreach (var ram in model.Ldata)
                    {
                        foreach (var farmaco in ram.LFarmacos)
                        {
                            foreach (var data in farmaco.LRams)
                            {
                                idx=1;
                                ws.Cell(row + 1, idx).Value = ram.FechaRecibidoCNFV?.ToString("dd/MM/yyyy") ?? "";
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.FechaEntregaEva?.ToString("dd/MM/yyyy") ?? "";
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.Evaluador?.NombreCompleto ?? "";
                                idx++;
                                ws.Cell(row + 1, idx).Value = farmaco.FarmacoSospechosoComercial;
                                idx++;
                                ws.Cell(row + 1, idx).Value = farmaco.FarmacoSospechosoDci;
                                idx++;
                                ws.Cell(row + 1, idx).Value = farmaco.Atc;
                                idx++;
                                ws.Cell(row + 1, idx).Value = farmaco.SubGrupoTerapeutico;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(ram.RamType);
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(ram.RamOrigenType);
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.CodigoNotiFacedra;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.IdFacedra;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.CodigoCNFV;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.CodExterno;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(ram.TipoNotificacion);
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.TipoInstitucion?.Nombre ?? ""; //DataModel.Helper.Helper.GetDescription(data.TipoOrgInst);
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.Provincia?.Nombre ?? ""; //data.ProvRegionOrigen;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.InstitucionDestino?.Nombre ?? ""; //data.NombreOrgInst;
                                idx++;
                                //ws.Cell(row + 1, idx).Value = ram.NumIngresoVigiflow;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.FechaEvaluacion?.ToString("dd/MM/yyyy") ?? "";
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(ram.Estatus);
                                idx++;
                                ws.Cell(row + 1, idx).Value = farmaco.FechaTratamiento?.ToString("dd/MM/yyyy") ?? "";
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.FechaRam?.ToString("dd/MM/yyyy") ?? "";
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.Desenlace);
                                idx++;
                                ws.Cell(row + 1, idx).Value = farmaco.Indicacion;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(farmaco.ConductaDosis);
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(farmaco.ConductaTerapia);
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.EvoDosis);
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.EvoTerapia);
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.OtrosDiagnosticos;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(ram.Sexo);
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.Edad;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.HistClinica;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.DatosLab;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(farmaco.Reexposicion);
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.ConReexposicion);
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.RamUnaDosis);
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.Grado;
                                //ws.Cell(row + 1, idx).Value = data.Iniciales;
                                idx++;
                                ws.Cell(row + 1, idx).Value = farmaco.ViaAdministracion;
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Ram;//data.EvaluacionCausalidad.Ram;
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.TerWhoArt;
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Soc;
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Concomitantes;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.SecTemporal);
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Stemp;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.ConPrevio);
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Cprev;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.EfecRetirada);
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Reti;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.EfecReexposicion);
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Reex;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.CausasAlter);
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Alter;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.FactContribuyentes);
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Facon;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.ExpComplementarias);
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Xplc;
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Puntuacion;
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Probabilidad;
                                idx++;
                                ws.Cell(row + 1, idx).Value = DataModel.Helper.Helper.GetDescription(data.IntRam);
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Gravedad;
                                idx++;
                                ws.Cell(row + 1, idx).Value = data.Referencia;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondDosisEvo;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondTerapiaEvo;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondSuspTerapiaReex;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondMantTerapiaReex;
                                idx++;
                                ws.Cell(row + 1, idx).Value = ram.ObservacionInfoNotifica.IncongruenciaConReex;
                                //ws.Cell(row + 1, 68).Value = DataModel.Helper.Helper.GetDescription(ram.RecomendacionProPac);
                                //ws.Cell(row + 1, 69).Value = DataModel.Helper.Helper.GetDescription(data.ActMonografia);
                                //ws.Cell(row + 1, 70).Value = DataModel.Helper.Helper.GetDescription(data.SuspRetiroLote);
                                //ws.Cell(row + 1, 71).Value = DataModel.Helper.Helper.GetDescription(data.RegSanSuspencionCancelacion);
                                //ws.Cell(row + 1, 72).Value = ram.Otras;
                                //ws.Cell(row + 1, 73).Value = ram.Observaciones;
                            }
                        }
                        row++;
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


        public async Task<List<FMV_Ram2TB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_Ram2TB> Get(long Id)
        {
            var result = DalService.Get<FMV_Ram2TB>(Id);
            return result;
        }

        public async Task<FMV_Ram2TB> Save(FMV_Ram2TB data)
        {
            var result = DalService.Save(data);   
            if(result != null)
            {
                //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                //DalService.DBContext.Entry(result).Property(b => b.EvaluacionCalidadInfo).IsModified = true;
                //DalService.DBContext.Entry(result).Property(b => b.EvaluacionCausalidad).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.ObservacionInfoNotifica).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.AccionesRegulatoria).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.Concominantes).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.Adjunto).IsModified = true;
                DalService.DBContext.SaveChanges();
            }

            return result;           
        }

        public async Task<FMV_Ram2TB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_Ram2TB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_Ram2TB>(); }
            catch { }return 0;
        }

        ///Reports
        //Fármaco sospechoso (DCI)
        public async Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_RamFarmacoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ram.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.FarmacoSospechosoDci into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().FarmacoSospechosoDci,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_RamFarmacoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ram.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.FarmacoSospechosoDci into g
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

                model.Ldata = (from data in DalService.DBContext.Set<FMV_RamFarmacoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ram.FechaRecibidoCNFV <= model.ToDate))&&
                               (data.Atc!=null && data.Atc.Length > 2)
                               group data by data.SubGrupoTerapeutico into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name2 = g.FirstOrDefault().SubGrupoTerapeutico,
                                   Name = g.FirstOrDefault().Atc,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_RamFarmacoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Atc != null && data.Atc.Length > 2)
                               group data by data.SubGrupoTerapeutico into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Origen de Notificacion
        public async Task<ReportModel<ReportModelResponse>> Report3(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.RamOrigenType into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   RAMOrigenType = g.FirstOrDefault().RamOrigenType,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.RamOrigenType into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Tipo de Notificador
        public async Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
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
        public async Task<ReportModel<ReportModelResponse>> Report5(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
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
        //Status
        public async Task<ReportModel<ReportModelResponse>> Report6(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.Estatus into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   RAMStatus = g.FirstOrDefault().Estatus,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.Estatus into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Edad
        public async Task<ReportModel<ReportModelResponse>> Report7(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
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
        //Sexo
        public async Task<ReportModel<ReportModelResponse>> Report8(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
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

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
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
        //Grado
        public async Task<ReportModel<ReportModelResponse>> Report9(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.Grado into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Grado,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by data.Grado into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //RAM
        public async Task<ReportModel<ReportModelResponse>> Report10(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Ram != null && data.Ram.Length > 0)
                               group data by data.Ram into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Ram,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Ram != null && data.Ram.Length > 0)
                               group data by data.Ram into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //SOC
        public async Task<ReportModel<ReportModelResponse>> Report11(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.SocId != null && data.SocId > 0)
                               group data by data.SocId into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Soc,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.SocId != null && data.SocId > 0)
                               group data by data.SocId into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Probabilidades
        public async Task<ReportModel<ReportModelResponse>> Report12(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.MainProbabilidad != null && data.MainProbabilidad.Length > 0)
                               group data by data.MainProbabilidad into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().MainProbabilidad,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.MainProbabilidad != null && data.MainProbabilidad.Length > 0)
                               group data by data.MainProbabilidad into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Gravedad
        public async Task<ReportModel<ReportModelResponse>> Report13(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Gravedad != null && data.Gravedad.Length > 0)
                               group data by data.Gravedad into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().Gravedad,//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                               (data.Gravedad != null && data.Gravedad.Length > 0)
                               group data by data.Gravedad into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Año de Recepción
        public async Task<ReportModel<ReportModelResponse>> Report14(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Year >= model.FromDate.Value.Year)) &&
                               (model.ToDate == null ? true : (data.Year <= model.ToDate.Value.Year)) &&
                               (data.Year > 0)
                               group data by data.Year into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = string.Format("RAM Totales Año {0}", g.FirstOrDefault().Year),//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
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

    }

}
