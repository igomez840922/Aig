using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace Aig.FarmacoVigilancia.Services
{    
    public class RamService : IRamService
    {
        private readonly IDalService DalService;
        public RamService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_RamTB>> FindAll(GenericModel<FMV_RamTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_RamTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodigoCNFV.Contains(model.Filter) || data.IdFacedra.Contains(model.Filter) || data.CodigoNotiFacedra.Contains(model.Filter) || data.SubGrupoTerapeutico.Contains(model.Filter) || data.Atc.Contains(model.Filter) || data.FarmacoSospechosoDci.Contains(model.Filter) || data.FarmacoSospechosoComercial.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))&&
                              (model.FromDate==null?true:(data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId ))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_RamTB>()
                               where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodigoCNFV.Contains(model.Filter) || data.IdFacedra.Contains(model.Filter) || data.CodigoNotiFacedra.Contains(model.Filter) || data.SubGrupoTerapeutico.Contains(model.Filter) || data.Atc.Contains(model.Filter) || data.FarmacoSospechosoDci.Contains(model.Filter) || data.FarmacoSospechosoComercial.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter))) &&
                              (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_RamTB> model)
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

                    ws.Cell(1, 1).Value = "Fecha de Recibido (CNFV)";
                    ws.Cell(1, 2).Value = "Fecha de entrega al Evaluador";
                    ws.Cell(1, 3).Value = "Evaluador";
                    ws.Cell(1, 4).Value = "Fármaco Sospechoso (Comercial)";
                    ws.Cell(1, 5).Value = "Fármaco Sospechoso (DCI)";
                    ws.Cell(1, 6).Value = "ATC";
                    ws.Cell(1, 7).Value = "Sub-grupo Terapéutico";
                    ws.Cell(1, 8).Value = "Hay RAM?";
                    ws.Cell(1, 9).Value = "Origen de la Notificación";
                    ws.Cell(1, 10).Value = "Código de Facedra";
                    ws.Cell(1, 11).Value = "ID Facedra";
                    ws.Cell(1, 12).Value = "Código del CNFV";
                    ws.Cell(1, 13).Value = "Código Externo";
                    ws.Cell(1, 14).Value = "Tipo de Notificador";
                    ws.Cell(1, 15).Value = "Tipo de Organización/Institución";
                    ws.Cell(1, 16).Value = "Provincia/Región/Origen";
                    ws.Cell(1, 17).Value = "Nombre de Organización/Institución";
                    ws.Cell(1, 18).Value = "Número de Ingreso a Vigiflow";
                    ws.Cell(1, 19).Value = "Fecha de evaluación";
                    ws.Cell(1, 20).Value = "Estatus";
                    ws.Cell(1, 21).Value = "Fecha de Tratamiento";
                    ws.Cell(1, 22).Value = "Fecha de RAM";
                    ws.Cell(1, 23).Value = "Desenlace";
                    ws.Cell(1, 24).Value = "Indicación";
                    ws.Cell(1, 25).Value = "Conducta Sobre Dosis";
                    ws.Cell(1, 26).Value = "Conducta Sobre Terapia";
                    ws.Cell(1, 27).Value = "Evolucion Sobre Dosis";
                    ws.Cell(1, 28).Value = "Evolucion Sobre Terapia";
                    ws.Cell(1, 29).Value = "Otros Diagnósticos";
                    ws.Cell(1, 30).Value = "Sexo";
                    ws.Cell(1, 31).Value = "Edad";
                    ws.Cell(1, 32).Value = "Historia Clinica";
                    ws.Cell(1, 33).Value = "Datos del Laboratorio";
                    ws.Cell(1, 34).Value = "Reexposición";
                    ws.Cell(1, 35).Value = "Consecuencia de Reexposición";
                    ws.Cell(1, 36).Value = "RAM con una sola dosis";
                    ws.Cell(1, 37).Value = "Grado";
                    ws.Cell(1, 38).Value = "Iniciales del Paciente";
                    ws.Cell(1, 39).Value = "Dosis, Frecuencia, Vía de Administración";
                    ws.Cell(1, 40).Value = "RAM";
                    ws.Cell(1, 41).Value = "TERMINO WHOArt (LLT)";
                    ws.Cell(1, 42).Value = "SOC";
                    ws.Cell(1, 43).Value = "Concomitante";
                    ws.Cell(1, 44).Value = "Secuencia temporal";
                    ws.Cell(1, 45).Value = "STEMP";
                    ws.Cell(1, 46).Value = "Conocimiento previo";
                    ws.Cell(1, 47).Value = "CPREV";
                    ws.Cell(1, 48).Value = "Efecto de Retirada";
                    ws.Cell(1, 49).Value = "RETI";
                    ws.Cell(1, 50).Value = "Efecto de Reexposición";
                    ws.Cell(1, 51).Value = "REEX";
                    ws.Cell(1, 52).Value = "Causas Alternativas";
                    ws.Cell(1, 53).Value = "ALTER";
                    ws.Cell(1, 54).Value = "Factores Contribuyentes";
                    ws.Cell(1, 55).Value = "FACON";
                    ws.Cell(1, 56).Value = "XPLC";
                    ws.Cell(1, 57).Value = "Puntuación";
                    ws.Cell(1, 58).Value = "Probabilidad";
                    ws.Cell(1, 59).Value = "Intesidad de la RAM";
                    ws.Cell(1, 60).Value = "Gravedad";
                    ws.Cell(1, 61).Value = "Referencia";
                    ws.Cell(1, 62).Value = "Incongruencia Conducta_No Disminuyó Dosis /Evolución";
                    ws.Cell(1, 63).Value = "Incongruencia Conducta_Mantuvo la Terapia/Evolución";
                    ws.Cell(1, 64).Value = "Incongruencia Conducta_Suspendió la terapia/ REEX";
                    ws.Cell(1, 65).Value = "Incongruencia Conducta_Mantuvo la terapia/ REEX";
                    ws.Cell(1, 66).Value = "Incongruencia Reexposicion Conducta_Mantuvo la terapia/ REEX";
                    ws.Cell(1, 67).Value = "Incongruencia Reexposición/Consecuencia de REEX";
                    ws.Cell(1, 68).Value = "Recomendaciones a Profesionales y Pacientes";
                    ws.Cell(1, 69).Value = "Actualización de monografía e inserto";
                    ws.Cell(1, 70).Value = "q";
                    ws.Cell(1, 71).Value = "Suspensión y retiro de lote(s)";
                    ws.Cell(1, 78).Value = "Registro Sanitario (Suspensión/Cancelación)";
                    ws.Cell(1, 73).Value = "Otras";
                    ws.Cell(1, 74).Value = "Observaciones";

                    var row = 1;
                    foreach(var data in model.Ldata)
                    {
                        foreach (var prod in data.LNotificaciones)
                        {                         
                            ws.Cell(row + 1, 1).Value = data.FechaRecibidoCNFV?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 2).Value = data.FechaEntregaEva?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 3).Value = data.Evaluador?.NombreCompleto ?? "";
                            ws.Cell(row + 1, 4).Value = data.FarmacoSospechosoComercial;
                            ws.Cell(row + 1, 5).Value = data.FarmacoSospechosoDci;
                            ws.Cell(row + 1, 6).Value = data.Atc;
                            ws.Cell(row + 1, 7).Value = data.SubGrupoTerapeutico;
                            ws.Cell(row + 1, 8).Value = DataModel.Helper.Helper.GetDescription(data.RamType);
                            ws.Cell(row + 1, 9).Value = DataModel.Helper.Helper.GetDescription(data.RamOrigenType);
                            ws.Cell(row + 1, 10).Value = data.CodigoNotiFacedra;
                            ws.Cell(row + 1, 11).Value = data.IdFacedra;
                            ws.Cell(row + 1, 12).Value = data.CodigoCNFV;
                            ws.Cell(row + 1, 13).Value = prod.CodExterno;
                            ws.Cell(row + 1, 14).Value = DataModel.Helper.Helper.GetDescription(prod.TipoNotificador);
                            ws.Cell(row + 1, 15).Value = DataModel.Helper.Helper.GetDescription(prod.TipoOrgInst);
                            ws.Cell(row + 1, 16).Value = prod.ProvRegionOrigen;
                            ws.Cell(row + 1, 17).Value = prod.NombreOrgInst;
                            ws.Cell(row + 1, 18).Value = prod.NumIngresoVigiflow;
                            ws.Cell(row + 1, 19).Value = prod.FechaEvaluacion?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 20).Value = DataModel.Helper.Helper.GetDescription(prod.Estatus);
                            ws.Cell(row + 1, 21).Value = prod.EvaluacionCalidadInfo.FechaTratamiento?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 22).Value = prod.EvaluacionCalidadInfo.FechaRam?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 23).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCalidadInfo.Desenlace);
                            ws.Cell(row + 1, 24).Value = prod.EvaluacionCalidadInfo.Indicacion;
                            ws.Cell(row + 1, 25).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCalidadInfo.ConductaDosis);
                            ws.Cell(row + 1, 26).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCalidadInfo.ConductaTerapia);
                            ws.Cell(row + 1, 27).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCalidadInfo.EvoDosis);
                            ws.Cell(row + 1, 28).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCalidadInfo.EvoTerapia);
                            ws.Cell(row + 1, 29).Value = prod.EvaluacionCalidadInfo.OtrosDiagnosticos;
                            ws.Cell(row + 1, 30).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCalidadInfo.Sexo);
                            ws.Cell(row + 1, 31).Value = prod.EvaluacionCalidadInfo.Edad;
                            ws.Cell(row + 1, 32).Value = prod.EvaluacionCalidadInfo.HistClinica;
                            ws.Cell(row + 1, 33).Value = prod.EvaluacionCalidadInfo.DatosLab;
                            ws.Cell(row + 1, 34).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCalidadInfo.Reexposicion);
                            ws.Cell(row + 1, 35).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCalidadInfo.ConReexposicion);
                            ws.Cell(row + 1, 36).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCalidadInfo.RamUnaDosis);
                            ws.Cell(row + 1, 37).Value = prod.EvaluacionCalidadInfo.Grado;
                            ws.Cell(row + 1, 38).Value = prod.EvaluacionCausalidad.Iniciales;
                            ws.Cell(row + 1, 39).Value = prod.EvaluacionCausalidad.ViaAdministracion;
                            ws.Cell(row + 1, 40).Value = prod.EvaluacionCausalidad.Ram;
                            ws.Cell(row + 1, 41).Value = prod.EvaluacionCausalidad.TerWhoArt;
                            ws.Cell(row + 1, 42).Value = prod.EvaluacionCausalidad.Soc;
                            ws.Cell(row + 1, 43).Value = prod.EvaluacionCausalidad.Concomitantes;
                            ws.Cell(row + 1, 44).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.SecTemporal);
                            ws.Cell(row + 1, 45).Value = prod.EvaluacionCausalidad.Stemp;
                            ws.Cell(row + 1, 46).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.ConPrevio);
                            ws.Cell(row + 1, 47).Value = prod.EvaluacionCausalidad.Cprev;
                            ws.Cell(row + 1, 48).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.EfecRetirada);
                            ws.Cell(row + 1, 49).Value = prod.EvaluacionCausalidad.Reti;
                            ws.Cell(row + 1, 50).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.EfecReexposicion);
                            ws.Cell(row + 1, 51).Value = prod.EvaluacionCausalidad.Reex;
                            ws.Cell(row + 1, 52).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.CausasAlter);
                            ws.Cell(row + 1, 53).Value = prod.EvaluacionCausalidad.Alter;
                            ws.Cell(row + 1, 54).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.FactContribuyentes);
                            ws.Cell(row + 1, 55).Value = prod.EvaluacionCausalidad.Facon;
                            ws.Cell(row + 1, 56).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.ExpComplementarias);
                            ws.Cell(row + 1, 57).Value = prod.EvaluacionCausalidad.Xplc;
                            ws.Cell(row + 1, 58).Value = prod.EvaluacionCausalidad.Puntuacion;
                            ws.Cell(row + 1, 59).Value = prod.EvaluacionCausalidad.Probabilidad;
                            ws.Cell(row + 1, 60).Value = DataModel.Helper.Helper.GetDescription(prod.EvaluacionCausalidad.IntRam);
                            ws.Cell(row + 1, 61).Value = prod.EvaluacionCausalidad.Gravedad;
                            ws.Cell(row + 1, 62).Value = prod.EvaluacionCausalidad.Referencia;
                            ws.Cell(row + 1, 63).Value = prod.ObservacionInfoNotifica.IncongruenciaCondDosisEvo;
                            ws.Cell(row + 1, 64).Value = prod.ObservacionInfoNotifica.IncongruenciaCondTerapiaEvo;
                            ws.Cell(row + 1, 65).Value = prod.ObservacionInfoNotifica.IncongruenciaCondSuspTerapiaReex;
                            ws.Cell(row + 1, 66).Value = prod.ObservacionInfoNotifica.IncongruenciaCondMantTerapiaReex;
                            ws.Cell(row + 1, 67).Value = prod.ObservacionInfoNotifica.IncongruenciaConReex;
                            ws.Cell(row + 1, 68).Value = DataModel.Helper.Helper.GetDescription(prod.AccionesRegulatoria.RecomendacionProPac);
                            ws.Cell(row + 1, 69).Value = DataModel.Helper.Helper.GetDescription(prod.AccionesRegulatoria.ActMonografia);
                            ws.Cell(row + 1, 70).Value = DataModel.Helper.Helper.GetDescription(prod.AccionesRegulatoria.SuspRetiroLote);
                            ws.Cell(row + 1, 71).Value = DataModel.Helper.Helper.GetDescription(prod.AccionesRegulatoria.RegSanSuspencionCancelacion);
                            ws.Cell(row + 1, 72).Value = prod.AccionesRegulatoria.Otras;
                            ws.Cell(row + 1, 73).Value = prod.AccionesRegulatoria.Observaciones;

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


        public async Task<List<FMV_RamTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_RamTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_RamTB> Get(long Id)
        {
            var result = DalService.Get<FMV_RamTB>(Id);
            return result;
        }

        public async Task<FMV_RamTB> Save(FMV_RamTB data)
        {
            var result = DalService.Save(data);
            if (result != null && data.LNotificaciones != null)
            {
                foreach (var item in data.LNotificaciones)
                {
                    //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
                    DalService.DBContext.Entry(item).Property(b => b.EvaluacionCalidadInfo).IsModified = true;
                    DalService.DBContext.Entry(item).Property(b => b.EvaluacionCausalidad).IsModified = true;
                    DalService.DBContext.Entry(item).Property(b => b.ObservacionInfoNotifica).IsModified = true;
                    DalService.DBContext.Entry(item).Property(b => b.AccionesRegulatoria).IsModified = true;
                    DalService.DBContext.SaveChanges();
                }
            }

            return result;           
        }

        public async Task<FMV_RamTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_RamTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_RamTB>(); }
            catch { }return 0;
        }
    }

}
