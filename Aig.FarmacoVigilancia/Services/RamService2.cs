using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Linq.Expressions;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Aig.FarmacoVigilancia.Components.Ram2;

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
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodigoCNFV.Contains(model.Filter) || data.IdFacedra.Contains(model.Filter) || data.CodigoNotiFacedra.Contains(model.Filter) || data.CodExterno.Contains(model.Filter) || data.FarmacosDesc.Contains(model.Filter) || data.RamDesc.Contains(model.Filter) || data.GravedadDesc.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter) ))&&
                              (model.FromDate==null?true:(data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId )) &&
                              (model.RamType == null ? true : (data.RamType == model.RamType))
                               orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodigoCNFV.Contains(model.Filter) || data.IdFacedra.Contains(model.Filter) || data.CodigoNotiFacedra.Contains(model.Filter) || data.CodExterno.Contains(model.Filter) || data.FarmacosDesc.Contains(model.Filter) || data.RamDesc.Contains(model.Filter) || data.GravedadDesc.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter) ))&&
                              (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId)) &&
                              (model.RamType == null ? true : (data.RamType == model.RamType))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_Ram2TB> model)
        {
            try {
                var lInstitucionDest = DalService.GetAll<InstitucionDestinoTB>();
                var lTipoInstitucion = DalService.GetAll<TipoInstitucionTB>();
                var lProvincias = DalService.GetAll<ProvinciaTB>();

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
                    ws.Cell(1, idx).Value = "Fecha de Tratamiento Inicial";
                    idx++;
                    ws.Cell(1, idx).Value = "Fecha de Tratamiento Final";
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

                    int row = 1;
                    foreach (var ram in model.Ldata)
                    {                       
                        if (ram?.LFarmacos?.Count > 0)
                        {
                            foreach (var farmaco in ram.LFarmacos)
                            {
                                if (farmaco?.LRams?.Count > 0)
                                {
                                    foreach (var data in farmaco.LRams)
                                    {
                                        idx = 1; row++;
                                        ws.Cell(row , idx).Value = ram.FechaRecibidoCNFV?.ToString("dd/MM/yyyy") ?? "";
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.FechaEntregaEva?.ToString("dd/MM/yyyy") ?? "";
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.Evaluador?.NombreCompleto ?? "";
                                        idx++;
                                        ws.Cell(row , idx).Value = farmaco.FarmacoSospechosoComercial;
                                        idx++;
                                        ws.Cell(row , idx).Value = farmaco.FarmacoSospechosoDci;
                                        idx++;
                                        ws.Cell(row , idx).Value = farmaco.Atc;
                                        idx++;
                                        ws.Cell(row , idx).Value = farmaco.SubGrupoTerapeutico;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.RamType);
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.RamOrigenType);
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.CodigoNotiFacedra;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.IdFacedra;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.CodigoCNFV;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.CodExterno;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.TipoNotificacion);
                                        idx++;
                                        ws.Cell(row , idx).Value = (ram.TipoInstitucionId.HasValue ? lTipoInstitucion.Where(x => x.Id == ram.TipoInstitucionId.Value)?.FirstOrDefault()?.Nombre ?? "" : ""); //DataModel.Helper.Helper.GetDescription(data.TipoOrgInst);
                                        idx++;
                                        ws.Cell(row, idx).Value = (ram.ProvinciaId.HasValue ? lProvincias.Where(x => x.Id == ram.ProvinciaId.Value)?.FirstOrDefault()?.Nombre ?? "" : "");//ram.Provincia?.Nombre ?? ""; //data.ProvRegionOrigen;
                                        idx++;
                                        ws.Cell(row, idx).Value = (ram.InstitucionId.HasValue ? lInstitucionDest.Where(x => x.Id == ram.InstitucionId.Value)?.FirstOrDefault()?.Nombre ?? "" : ""); // ram.InstitucionDestino?.Nombre ?? ""; //data.NombreOrgInst;
                                        idx++;
                                        //ws.Cell(row , idx).Value = ram.NumIngresoVigiflow;
                                        //idx++;
                                        ws.Cell(row , idx).Value = ram.FechaEvaluacion?.ToString("dd/MM/yyyy") ?? "";
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.Estatus);
                                        idx++;
                                        ws.Cell(row , idx).Value = farmaco.FechaTratamiento;
                                        idx++;
                                        ws.Cell(row, idx).Value = farmaco.FechaTratamientoFin;
                                        idx++;
                                        ws.Cell(row , idx).Value = data.FechaRam;
                                        idx++;
                                        //ws.Cell(row, idx).Value = data.FechaRamFin;
                                        //idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.Desenlace);
                                        idx++;
                                        ws.Cell(row , idx).Value = farmaco.Indicacion;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(farmaco.ConductaDosis);
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(farmaco.ConductaTerapia);
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.EvoDosis);
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.EvoTerapia);
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.OtrosDiagnosticos;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.Sexo);
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.Edad;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.HistClinica;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.DatosLab;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(farmaco.Reexposicion);
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.ConReexposicion);
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.RamUnaDosis);
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.Grado;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.InicialesPaciente;
                                        idx++;
                                        ws.Cell(row , idx).Value = farmaco.ViaAdministracion;
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Ram;//data.EvaluacionCausalidad.Ram;
                                        idx++;
                                        ws.Cell(row , idx).Value = data.TerWhoArt;
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Soc;
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Concomitantes;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.SecTemporal);
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Stemp;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.ConPrevio);
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Cprev;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.EfecRetirada);
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Reti;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.EfecReexposicion);
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Reex;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.CausasAlter);
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Alter;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.FactContribuyentes);
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Facon;
                                        idx++;
                                        //ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.ExpComplementarias);
                                        //idx++;
                                        ws.Cell(row , idx).Value = data.Xplc;
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Puntuacion;
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Probabilidad;
                                        idx++;
                                        ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(data.IntRam);
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Gravedad;
                                        idx++;
                                        ws.Cell(row , idx).Value = data.Referencia;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondDosisEvo;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondTerapiaEvo;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondSuspTerapiaReex;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondMantTerapiaReex;
                                        idx++;
                                        ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaConReex;
                                    }
                                }
                                else
                                {
                                    idx = 1; row++;
                                    ws.Cell(row , idx).Value = ram.FechaRecibidoCNFV?.ToString("dd/MM/yyyy") ?? "";
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.FechaEntregaEva?.ToString("dd/MM/yyyy") ?? "";
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.Evaluador?.NombreCompleto ?? "";
                                    idx++;
                                    ws.Cell(row , idx).Value = farmaco.FarmacoSospechosoComercial;
                                    idx++;
                                    ws.Cell(row , idx).Value = farmaco.FarmacoSospechosoDci;
                                    idx++;
                                    ws.Cell(row , idx).Value = farmaco.Atc;
                                    idx++;
                                    ws.Cell(row , idx).Value = farmaco.SubGrupoTerapeutico;
                                    idx++;
                                    ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.RamType);
                                    idx++;
                                    ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.RamOrigenType);
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.CodigoNotiFacedra;
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.IdFacedra;
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.CodigoCNFV;
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.CodExterno;
                                    idx++;
                                    ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.TipoNotificacion);
                                    idx++;
                                    ws.Cell(row, idx).Value = (ram.TipoInstitucionId.HasValue ? lTipoInstitucion.Where(x => x.Id == ram.TipoInstitucionId.Value)?.FirstOrDefault()?.Nombre ?? "" : ""); //DataModel.Helper.Helper.GetDescription(data.TipoOrgInst);
                                    idx++;
                                    ws.Cell(row, idx).Value = (ram.ProvinciaId.HasValue ? lProvincias.Where(x => x.Id == ram.ProvinciaId.Value)?.FirstOrDefault()?.Nombre ?? "" : "");//ram.Provincia?.Nombre ?? ""; //data.ProvRegionOrigen;
                                    idx++;
                                    ws.Cell(row, idx).Value = (ram.InstitucionId.HasValue ? lInstitucionDest.Where(x => x.Id == ram.InstitucionId.Value)?.FirstOrDefault()?.Nombre ?? "" : ""); // ram.InstitucionDestino?.Nombre ?? ""; //data.NombreOrgInst;
                                    idx++;
                                    //ws.Cell(row , idx).Value = ram.NumIngresoVigiflow;
                                    //idx++;
                                    ws.Cell(row , idx).Value = ram.FechaEvaluacion?.ToString("dd/MM/yyyy") ?? "";
                                    idx++;
                                    ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.Estatus);
                                    idx++;
                                    ws.Cell(row , idx).Value = farmaco.FechaTratamiento;
                                    idx++;
                                    ws.Cell(row, idx).Value = farmaco.FechaTratamientoFin;
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    //idx++;
                                    //ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row, idx).Value = "Desenlase";
                                    idx++;
                                    ws.Cell(row , idx).Value = farmaco.Indicacion;
                                    idx++;
                                    ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(farmaco.ConductaDosis);
                                    idx++;
                                    ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(farmaco.ConductaTerapia);
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.OtrosDiagnosticos;
                                    idx++;
                                    ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.Sexo);
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.Edad;
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.HistClinica;
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.DatosLab;
                                    idx++;
                                    ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(farmaco.Reexposicion);
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.Grado;
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.InicialesPaciente;
                                    idx++;
                                    ws.Cell(row , idx).Value = farmaco.ViaAdministracion;
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    //idx++;
                                    //ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = "";
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondDosisEvo;
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondTerapiaEvo;
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondSuspTerapiaReex;
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondMantTerapiaReex;
                                    idx++;
                                    ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaConReex;
                                }
                            }
                        }
                        else
                        {
                            idx = 1; row++;
                            ws.Cell(row , idx).Value = ram.FechaRecibidoCNFV?.ToString("dd/MM/yyyy") ?? "";
                            idx++;
                            ws.Cell(row , idx).Value = ram.FechaEntregaEva?.ToString("dd/MM/yyyy") ?? "";
                            idx++;
                            ws.Cell(row , idx).Value = ram.Evaluador?.NombreCompleto ?? "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.RamType);
                            idx++;
                            ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.RamOrigenType);
                            idx++;
                            ws.Cell(row , idx).Value = ram.CodigoNotiFacedra;
                            idx++;
                            ws.Cell(row , idx).Value = ram.IdFacedra;
                            idx++;
                            ws.Cell(row , idx).Value = ram.CodigoCNFV;
                            idx++;
                            ws.Cell(row , idx).Value = ram.CodExterno;
                            idx++;
                            ws.Cell(row, idx).Value = (ram.TipoInstitucionId.HasValue ? lTipoInstitucion.Where(x => x.Id == ram.TipoInstitucionId.Value)?.FirstOrDefault()?.Nombre ?? "" : ""); //DataModel.Helper.Helper.GetDescription(data.TipoOrgInst);
                            idx++;
                            ws.Cell(row, idx).Value = (ram.ProvinciaId.HasValue ? lProvincias.Where(x => x.Id == ram.ProvinciaId.Value)?.FirstOrDefault()?.Nombre ?? "" : "");//ram.Provincia?.Nombre ?? ""; //data.ProvRegionOrigen;
                            idx++;
                            ws.Cell(row, idx).Value = (ram.InstitucionId.HasValue ? lInstitucionDest.Where(x => x.Id == ram.InstitucionId.Value)?.FirstOrDefault()?.Nombre ?? "" : ""); // ram.InstitucionDestino?.Nombre ?? ""; //data.NombreOrgInst;
                            idx++;
                            ws.Cell(row, idx).Value = (ram.InstitucionId.HasValue ? lInstitucionDest.Where(x => x.Id == ram.InstitucionId.Value)?.FirstOrDefault()?.Nombre ?? "" : ""); // ram.InstitucionDestino?.Nombre ?? ""; //data.NombreOrgInst;
                            idx++;
                            //ws.Cell(row , idx).Value = ram.NumIngresoVigiflow;
                            //idx++;
                            ws.Cell(row , idx).Value = ram.FechaEvaluacion?.ToString("dd/MM/yyyy") ?? "";
                            idx++;
                            ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.Estatus);
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            //idx++;
                            //ws.Cell(row, idx).Value = "";
                            idx++;
                            ws.Cell(row, idx).Value = "Desenlace";
                            idx++;
                            ws.Cell(row , idx).Value = "Indicacion";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = ram.OtrosDiagnosticos;
                            idx++;
                            ws.Cell(row , idx).Value = DataModel.Helper.Helper.GetDescription(ram.Sexo);
                            idx++;
                            ws.Cell(row , idx).Value = ram.Edad;
                            idx++;
                            ws.Cell(row , idx).Value = ram.HistClinica;
                            idx++;
                            ws.Cell(row , idx).Value = ram.DatosLab;
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = ram.Grado;
                            idx++;
                            ws.Cell(row , idx).Value = ram.InicialesPaciente;
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            //idx++;
                            //ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = "";
                            idx++;
                            ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondDosisEvo;
                            idx++;
                            ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondTerapiaEvo;
                            idx++;
                            ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondSuspTerapiaReex;
                            idx++;
                            ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaCondMantTerapiaReex;
                            idx++;
                            ws.Cell(row , idx).Value = ram.ObservacionInfoNotifica.IncongruenciaConReex;
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

                model.Ldata = (from dataFinal in 
                                 (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                                         where data.Deleted == false &&
                                         (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                                         (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                                         (data.Ram != null && data.Ram.Length > 0)
                                         group data by new { data.Farmaco.RamId, data.Ram } into g
                                         orderby g.Count() descending
                                         select new ReportModelResponse
                                         {
                                             Name = g.FirstOrDefault().Ram,//.Substring(0, 3),
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
                                 (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.Ram != null && data.Ram.Length > 0)
                                  group data by new { data.Farmaco.RamId, data.Ram } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse
                                  {
                                      Name = g.FirstOrDefault().Ram,//.Substring(0, 3),
                                      Count = g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               //orderby gFinal.Count() descending
                               select gFinal.Count()).Sum(x => x);

                // (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                //where data.Deleted == false &&
                //(model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                //(model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                //(data.Ram != null && data.Ram.Length > 0)
                //group data by new { data.Farmaco.RamId, data.Ram } into g
                //orderby g.Count() descending
                //select new ReportModelResponse
                //{
                //    Name = g.FirstOrDefault().Ram,//.Substring(0, 3),
                //    Count = 1,//g.Count()
                //}).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.Ram != null && data.Ram.Length > 0)
                //               group data by new { data.Farmaco.RamId, data.Ram } into g
                //               select g.Count()).Sum(x => x);
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

                model.Ldata = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.Ram != null && data.Ram.Length > 0)
                                  group data by new { data.Farmaco.RamId, data.Ram, data.SocId } into g
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
                                 (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.Ram != null && data.Ram.Length > 0)
                                  group data by new { data.Farmaco.RamId, data.Ram, data.SocId } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse
                                  {
                                      Name = g.FirstOrDefault().Soc,//.Substring(0, 3),
                                      Count = g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               //orderby gFinal.Count() descending
                               select gFinal.Count()).Sum(x => x);

                //model.Ldata = null; model.Total = 0;

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.SocId != null && data.SocId > 0)
                //               group data by data.SocId into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().Soc,//.Substring(0, 3),
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.SocId != null && data.SocId > 0)
                //               group data by data.SocId into g
                //               select g.Count()).Sum(x => x);
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

                model.Ldata = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.Ram != null && data.Ram.Length > 0)
                                  group data by new { data.Farmaco.RamId, data.Ram, data.Gravedad } into g
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
                                 (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.Ram != null && data.Ram.Length > 0)
                                  group data by new { data.Farmaco.RamId, data.Ram, data.Gravedad } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse
                                  {
                                      Name = g.FirstOrDefault().Gravedad,//.Substring(0, 3),
                                      Count = g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               //orderby gFinal.Count() descending
                               select gFinal.Count()).Sum(x => x);

                //model.Ldata = null; model.Total = 0;

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.Gravedad != null && data.Gravedad.Length > 0)
                //               group data by data.Gravedad into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().Gravedad,//.Substring(0, 3),
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.Gravedad != null && data.Gravedad.Length > 0)
                //               group data by data.Gravedad into g
                //               select g.Count()).Sum(x => x);
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
                               //(model.FromDate == null ? true : (data.Year >= model.FromDate.Value.Year)) &&
                               //(model.ToDate == null ? true : (data.Year <= model.ToDate.Value.Year)) &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) 
                               //(data.Year > 0)
                               group data by data.Year into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = string.Format("RAM Totales Año {0}", g.FirstOrDefault().Year),//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                               //(model.FromDate == null ? true : (data.Year >= model.FromDate.Value.Year)) &&
                               //(model.ToDate == null ? true : (data.Year <= model.ToDate.Value.Year)) &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               //(data.Year > 0)
                               group data by data.Year into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Desenlace
        public async Task<ReportModel<ReportModelResponse>> Report15(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.Ram != null && data.Ram.Length > 0)
                                  group data by new { data.Farmaco.RamId, data.Ram, data.Desenlace } into g
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
                                 (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                                  where data.Deleted == false &&
                                  (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                                  (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                                  (data.Ram != null && data.Ram.Length > 0)
                                  group data by new { data.Farmaco.RamId, data.Ram, data.Desenlace } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse
                                  {
                                      RAMDesenlace = g.FirstOrDefault().Desenlace,//.Substring(0, 3),
                                      Count = 1,//g.Count()
                                  })
                               group dataFinal by new { dataFinal.RAMDesenlace } into gFinal
                               //orderby gFinal.Count() descending
                               select gFinal.Count()).Sum(x => x);

                //model.Ldata = null; model.Total = 0;

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.SocId != null && data.SocId > 0)
                //               group data by data.SocId into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().Soc,//.Substring(0, 3),
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_RamFarmacoRamTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Farmaco.Ram.FechaRecibidoCNFV <= model.ToDate)) &&
                //               (data.SocId != null && data.SocId > 0)
                //               group data by data.SocId into g
                //               select g.Count()).Sum(x => x);
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
                                wb.Properties.Author = "Fármaco_Sospechoso_DCI";
                                wb.Properties.Title = "Fármaco_Sospechoso_DCI";
                                wb.Properties.Subject = "Fármaco_Sospechoso_DCI";

                                var ws = wb.Worksheets.Add("Fármaco_Sospechoso_DCI");

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
                    case 2: {
                            model = await Report2(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Clasificación_ATC";
                                wb.Properties.Title = "Clasificación_ATC";
                                wb.Properties.Subject = "Clasificación_ATC";

                                var ws = wb.Worksheets.Add("Clasificación_ATC");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = "SubGrupo Terapeutico";
                                ws.Cell(1, 3).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name?.Length > 2 ? prod.Name.Substring(0, 3) : "";
                                    ws.Cell(row + 1, 2).Value = prod.Name2;
                                    ws.Cell(row + 1, 3).Value = prod.Count;
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
                                wb.Properties.Author = "Origen_Notificacion";
                                wb.Properties.Title = "Origen_Notificacion";
                                wb.Properties.Subject = "Origen_Notificacion";

                                var ws = wb.Worksheets.Add("Origen_Notificacion");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(prod.RAMOrigenType);
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
                                wb.Properties.Author = "Tipo_Notificador";
                                wb.Properties.Title = "Tipo_Notificador";
                                wb.Properties.Subject = "Tipo_Notificador";

                                var ws = wb.Worksheets.Add("Tipo_Notificador");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(prod.RAMNotificationType);
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 5: {
                            model = await Report5(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Organización";
                                wb.Properties.Title = "Organización";
                                wb.Properties.Subject = "Organización";

                                var ws = wb.Worksheets.Add("Organización");

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
                    case 6: {
                            model = await Report6(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Status";
                                wb.Properties.Title = "Status";
                                wb.Properties.Subject = "Status";

                                var ws = wb.Worksheets.Add("Status");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(prod.RAMStatus);
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 7: {
                            model = await Report7(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Edad";
                                wb.Properties.Title = "Edad";
                                wb.Properties.Subject = "Edad";

                                var ws = wb.Worksheets.Add("Edad");

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
                    case 8: {
                            model = await Report8(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Sexo";
                                wb.Properties.Title = "Sexo";
                                wb.Properties.Subject = "Sexo";

                                var ws = wb.Worksheets.Add("Sexo");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(prod.Sexo);
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 9: {
                            model = await Report9(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Grado";
                                wb.Properties.Title = "Grado";
                                wb.Properties.Subject = "Grado";

                                var ws = wb.Worksheets.Add("Grado");

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
                    case 10: {
                            model = await Report10(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "RAM";
                                wb.Properties.Title = "RAM";
                                wb.Properties.Subject = "RAM";

                                var ws = wb.Worksheets.Add("RAM");

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
                    case 11: {
                            model = await Report11(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "SOC";
                                wb.Properties.Title = "SOC";
                                wb.Properties.Subject = "SOC";

                                var ws = wb.Worksheets.Add("SOC");

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
                    case 12: {
                            model = await Report12(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Probabilidades";
                                wb.Properties.Title = "Probabilidades";
                                wb.Properties.Subject = "Probabilidades";

                                var ws = wb.Worksheets.Add("Probabilidades");

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
                    case 13: {
                            model = await Report13(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Gravedad";
                                wb.Properties.Title = "Gravedad";
                                wb.Properties.Subject = "Gravedad";

                                var ws = wb.Worksheets.Add("Gravedad");

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
                    case 14: {
                            model = await Report14(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Año_Recepción";
                                wb.Properties.Title = "Año_Recepción";
                                wb.Properties.Subject = "Año_Recepción";

                                var ws = wb.Worksheets.Add("Año_Recepción");

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
                    case 15: {
                            model = await Report15(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Desenlace";
                                wb.Properties.Title = "Desenlace";
                                wb.Properties.Subject = "Desenlace";

                                var ws = wb.Worksheets.Add("Desenlace");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(prod.RAMDesenlace); 
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
