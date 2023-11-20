using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using BlazorDownloadFile;
using System.Linq.Expressions;
using MimeKit;
using Microsoft.AspNetCore.Components;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace Aig.FarmacoVigilancia.Services
{    
    public class NoteService : INoteService
    {
        private readonly IDalService DalService;
        private readonly IEmailService emailService;
        private readonly IPdfGenerationService pdfGenerationService;
        private readonly NavigationManager navigationManager;
        public NoteService(IDalService dalService, IEmailService emailService, IPdfGenerationService pdfGenerationService, NavigationManager navigationManager)
        {
            DalService = dalService;
            this.emailService = emailService;
            this.pdfGenerationService = pdfGenerationService;
            this.navigationManager = navigationManager;
        }

        public async Task<List<FMV_NotaTB>> FindAll(Expression<Func<FMV_NotaTB, bool>> match)
        {
            try
            {
                return DalService.FindAll(match);
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<GenericModel<FMV_NotaTB>> FindAll(GenericModel<FMV_NotaTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_NotaTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.NumNota.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))&&
                              (model.FromDate == null ? true : (data.Fecha >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.Fecha <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId )) &&
                              (model.NotaType == null ? true : (data.TipoNota == model.NotaType))
                              orderby data.CreatedDate descending
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_NotaTB>()
                               where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.NumNota.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter))) &&
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
                    ws.Cell(1, 5).Value = "Institución";
                    ws.Cell(1, 6).Value = "Asunto";
                    ws.Cell(1, 7).Value = "Descripción";
                    ws.Cell(1, 8).Value = "Destinatarios";
                    ws.Cell(1, 9).Value = "Estado del Mensaje";
                    ws.Cell(1, 10).Value = "Mensaje Leído";

                    string Destinatarios = null;
                    string Instituciones = null;
                    for (int row = 1; row <= model.Ldata.Count; row++)
                    {
                        var prod = model.Ldata[row - 1];

                        Destinatarios = "";
                        if (prod.NotaContactos != null)
                        {
                            foreach (var dest in prod.NotaContactos.LContactos)
                            {
                                Destinatarios += dest.Correo + "; ";
                            }
                        }

                        Instituciones = "";
                        if (prod.Instituciones?.LInstituciones?.Count > 0)
                        {
                            foreach (var dest in prod.Instituciones.LInstituciones)
                            {
                                Instituciones += dest.Nombre + "; ";
                            }
                        }

                        //FechaRecepcion
                        ws.Cell(row + 1, 1).Value = prod.Fecha?.ToString("dd/MM/yyyy") ?? "";
                        ws.Cell(row + 1, 2).Value = prod.NumNota;
                        ws.Cell(row + 1, 3).Value = prod.Evaluador?.NombreCompleto ?? "";
                        ws.Cell(row + 1, 4).Value = DataModel.Helper.Helper.GetDescription(prod.TipoNota);
                        ws.Cell(row + 1, 5).Value = Instituciones;
                        ws.Cell(row + 1, 6).Value = prod.Asunto;
                        ws.Cell(row + 1, 7).Value = prod.Descripcion;
                        ws.Cell(row + 1, 8).Value = Destinatarios;
                        ws.Cell(row + 1, 9).Value = DataModel.Helper.Helper.GetDescription(prod.EmailStatus);
                        ws.Cell(row + 1, 10).Value = string.Format("{0} {1}", DataModel.Helper.Helper.GetDescription(prod.EmailReadStatus), prod.EmailReadTimes > 0 ? prod.EmailReadTimes : "");
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
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.NotaContactos).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.Adjunto).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.Instituciones).IsModified = true;
                DalService.DBContext.SaveChanges();
            }
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

        public async Task<string> SendEmailNote(long Id)
        {
            try
            {
                var data = await Get(Id);
                if (data?.NotaContactos?.LContactos?.Count > 0)
                {
                    var subject = data.Asunto; //"Mensaje del Centro Nacional de Farmacovigilancia";

                    var builder = new BodyBuilder();

                    //builder.TextBody = "Nota #: " + data.NumNota + "\r\n" + data.Descripcion;
                    builder.TextBody = string.Format("Buen día, adjunto a este correo electrónico encontrará información de interés emitida por el Centro Nacional de Farmacovigilancia\r\n\r\n" +
                        "Nota #: {0}\r\n{1}\r\n\r\n\r\n" +
                        "Por favor notifique la lectura de este correo haciendo click en el siguiente enlace {2}.\r\n\r\n\r\n" +
                        "Para cualquier consulta o información adicional puede contactarnos a través del correo electrónico fvigilancia@minsa.gob.pa.\r\n\r\n" +
                        "Saludos Cordiales\r\n\r\nCentro Nacional de Farmacovigilancia\r\nDepartamento de Farmacovigilancia\r\nDirección Nacional de Farmacia y Drogas\r\nMinisterio de Salud\r\n\r\n\r\n" +
                        "Nota: para darse de baja de dicho sistema haga click en el siguiente enlace: {3}", 
                        data.NumNota, data.Descripcion, string.Format("{0}{1}/{2}", navigationManager.BaseUri, "notarecibida", data.Id), string.Format("{0}{1}", navigationManager.BaseUri, "registrobaja"));


                    if (data.Adjunto?.LAttachments?.Count > 0)
                    {
                        foreach (var attch in data.Adjunto.LAttachments)
                        {
                            FileInfo fi = new FileInfo(attch.AbsolutePath);
                            var byteArr = await pdfGenerationService.GetByteArrayFromFile(attch.AbsolutePath);
                            if (byteArr != null)
                            {
                                builder.Attachments.Add(fi.Name, byteArr);
                            }
                        }
                    }

                    List<string> lEmails = (from email in data.NotaContactos.LContactos
                                            select email.Correo).ToList();

                    await emailService.SendEmailAsync(lEmails, subject, builder, "Centro Nacional de Farmacovigilancia");

                    data.EmailStatus = enumEmailStatus.Send;
                    data.EmailReadStatus = data.EmailReadStatus == enumEmailReadStatus.NA? enumEmailReadStatus.UnRead: data.EmailReadStatus;
                    await Save(data);

                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "el correo no pudo ser enviado";
        }

        public async Task NotifyNoteReaded(long Id)
        {
            var result = DalService.Get<FMV_NotaTB>(Id);

            if (result != null)
            {
                result.EmailReadStatus = enumEmailReadStatus.Read;
                result.EmailReadTimes ++;
                result.EmailStatus = enumEmailStatus.Send;

                await Save(result);
            }
        }

    }

}
