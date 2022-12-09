using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace Aig.FarmacoVigilancia.Services
{    
    public class ESAVIService : IESAVIService
    {
        private readonly IDalService DalService;
        public ESAVIService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_EsaviTB>> FindAll(GenericModel<FMV_EsaviTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_EsaviTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodigoNotiFacedra.Contains(model.Filter) || data.IdFacedra.Contains(model.Filter) || data.CodCNFV.Contains(model.Filter) || data.CodExt.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter) || data.InstitucionDestino.Nombre.Contains(model.Filter)))&&
                              (model.FromDate==null?true:(data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId ))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_EsaviTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.CodigoNotiFacedra.Contains(model.Filter) || data.IdFacedra.Contains(model.Filter) || data.CodCNFV.Contains(model.Filter) || data.CodExt.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter) || data.InstitucionDestino.Nombre.Contains(model.Filter))) &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_EsaviTB> model)
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
                    ws.Cell(1, 9).Value = "Tipo de Notificador";
                    ws.Cell(1, 10).Value = "Tipo de Organización";
                    ws.Cell(1, 11).Value = "Provincia";
                    ws.Cell(1, 12).Value = "Organización";
                    ws.Cell(1, 13).Value = "Otros Diagnosticos";
                    ws.Cell(1, 14).Value = "Sexo";
                    ws.Cell(1, 15).Value = "Edad";
                    ws.Cell(1, 16).Value = "Historia Clínica";
                    ws.Cell(1, 17).Value = "Datos del Laboratorio";
                    ws.Cell(1, 18).Value = "Nombre Completo de la Persona";
                    ws.Cell(1, 19).Value = "Iniciales de Paciente";
                    ws.Cell(1, 20).Value = "Cedula";
                    ws.Cell(1, 21).Value = "Medicamentos Concominante";
                    ws.Cell(1, 22).Value = "Detalles del Caso";
                    ws.Cell(1, 23).Value = "Fecha de Evaluación";
                    ws.Cell(1, 24).Value = "Estatus";
                    ws.Cell(1, 25).Value = "Observaciones";
                    ws.Cell(1, 26).Value = "Hay ESAVI?";
                    ws.Cell(1, 27).Value = "Fecha de ESAVI";
                    ws.Cell(1, 28).Value = "Desenlace";
                    ws.Cell(1, 29).Value = "ESAVI";
                    ws.Cell(1, 30).Value = "Termino WhoArt (LLC)";
                    ws.Cell(1, 31).Value = "SOC";
                    ws.Cell(1, 32).Value = "Intensidad de la ESAVI";
                    ws.Cell(1, 33).Value = "Gravedad";
                    ws.Cell(1, 34).Value = "Otros Criterios";
                    ws.Cell(1, 35).Value = "Elegibilidad por Gravedad";
                    ws.Cell(1, 36).Value = "Elegibilidad por Otro Criterio";
                    ws.Cell(1, 37).Value = "Elegibilidad por Evaluacion de Causalidad";
                    ws.Cell(1, 38).Value = "Probabilidad de Asosiación Causal con la Inmunización";
                    ws.Cell(1, 39).Value = "Vacuna Sospechosa (Comercial)";
                    ws.Cell(1, 40).Value = "Descripción de Vacuna";
                    ws.Cell(1, 41).Value = "DFabricante";
                    ws.Cell(1, 42).Value = "Lote";
                    ws.Cell(1, 43).Value = "Expira";
                    ws.Cell(1, 44).Value = "Reg. Sanitario";
                    ws.Cell(1, 45).Value = "Fecha de Vacunación";
                    ws.Cell(1, 46).Value = "Indicaciones";
                    ws.Cell(1, 47).Value = "Dosis y Via de Administración";
                    ws.Cell(1, 48).Value = "Dosis en que se presenta el ESAVI";

                    var row = 1;
                    foreach (var data in model.Ldata)
                    {
                        foreach (var prod in data.LNotificaciones)
                        {
                            ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(data.OrigenNotificacion);
                            ws.Cell(row + 1, 2).Value = data.CodigoNotiFacedra;
                            ws.Cell(row + 1, 3).Value = data.IdFacedra;
                            ws.Cell(row + 1, 4).Value = data.CodExt;
                            ws.Cell(row + 1, 5).Value = data.CodCNFV;
                            ws.Cell(row + 1, 6).Value = data.FechaRecibidoCNFV?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 7).Value = data.FechaEntregaEva?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 8).Value = data.Evaluador?.NombreCompleto ?? "";
                            ws.Cell(row + 1, 9).Value = DataModel.Helper.Helper.GetDescription(data.TipoNotificacion);
                            ws.Cell(row + 1, 10).Value = data.TipoInstitucion?.Nombre??"";
                            ws.Cell(row + 1, 11).Value = data.Provincia?.Nombre ?? "";
                            ws.Cell(row + 1, 12).Value = data.InstitucionDestino?.Nombre??"";
                            ws.Cell(row + 1, 13).Value = data.OtrosDiagnosticos;
                            ws.Cell(row + 1, 14).Value = DataModel.Helper.Helper.GetDescription(data.Sexo);
                            ws.Cell(row + 1, 15).Value = data.Edad;
                            ws.Cell(row + 1, 16).Value = data.HistoriaClinica;
                            ws.Cell(row + 1, 17).Value = data.DatosLab;
                            ws.Cell(row + 1, 18).Value = data.NombreCompletoPersona;
                            ws.Cell(row + 1, 19).Value = data.InicialesPersona;
                            ws.Cell(row + 1, 20).Value = data.Cedula;
                            ws.Cell(row + 1, 21).Value = data.MedicamentoContaminante;
                            ws.Cell(row + 1, 22).Value = DataModel.Helper.Helper.GetDescription(data.DetallesCaso);
                            ws.Cell(row + 1, 23).Value = data.FechaEvalua?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 24).Value = DataModel.Helper.Helper.GetDescription(data.Estatus);
                            ws.Cell(row + 1, 25).Value = data.Observaciones;
                            ws.Cell(row + 1, 26).Value = DataModel.Helper.Helper.GetDescription(prod.HayEsavi);
                            ws.Cell(row + 1, 27).Value = prod.FechaEsavi?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 28).Value = DataModel.Helper.Helper.GetDescription(prod.Desenlace);
                            ws.Cell(row + 1, 29).Value = prod.EsaviDescripcion;
                            ws.Cell(row + 1, 30).Value = prod.TerminoWhoArt;
                            ws.Cell(row + 1, 31).Value = prod.Soc;// DataModel.Helper.Helper.GetDescription(prod.SOC);
                            ws.Cell(row + 1, 32).Value = string.Format("{0} {1}", prod.IntensidadEsavi?.Nombre??"", prod.IntensidadEsavi?.Gravedad ?? ""); //prod.Intensidad;
                            ws.Cell(row + 1, 33).Value = prod.Gravedad;
                            ws.Cell(row + 1, 34).Value = DataModel.Helper.Helper.GetDescription(prod.OtrosCriterios);
                            ws.Cell(row + 1, 35).Value = prod.ElegibilidadGravedad;
                            ws.Cell(row + 1, 36).Value = prod.ElegibilidadOtroCriterio;
                            ws.Cell(row + 1, 37).Value = prod.ElegibleEvaluacionCausal;
                            ws.Cell(row + 1, 38).Value = DataModel.Helper.Helper.GetDescription(prod.ProbabilidadAsociacion);
                            ws.Cell(row + 1, 39).Value = prod.VacunaComercial;
                            ws.Cell(row + 1, 40).Value = prod.TipoVacuna?.Nombre ?? ""; //prod.DescripVacuna;
                            ws.Cell(row + 1, 41).Value = prod.Laboratorio?.Nombre ?? ""; //prod.DescripVacuna;
                            ws.Cell(row + 1, 42).Value = prod.Lote;
                            ws.Cell(row + 1, 43).Value = prod.FechaExp?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 44).Value = prod.RegSanitario;
                            ws.Cell(row + 1, 45).Value = prod.FechaVacunacion?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row + 1, 46).Value = prod.Indicaciones;
                            ws.Cell(row + 1, 47).Value = prod.DosisViaAdmin;
                            ws.Cell(row + 1, 48).Value = prod.DosisEsavi;
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

        public async Task<List<FMV_EsaviTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_EsaviTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_EsaviTB> Get(long Id)
        {
            var result = DalService.Get<FMV_EsaviTB>(Id);
            return result;
        }

        public async Task<FMV_EsaviTB> Save(FMV_EsaviTB data)
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

            return result;           
        }

        public async Task<FMV_EsaviTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_EsaviTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_EsaviTB>(); }
            catch { }return 0;
        }
    }

}
