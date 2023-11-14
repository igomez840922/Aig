using CommunityToolkit.Mvvm.Messaging;
using DataAccess;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Auditoria.Services;
using MimeKit;
using DataModel;
using Radzen.Blazor;
using Microsoft.Extensions.DependencyInjection;

namespace Aig.Auditoria.Jobs
{
    
    [DisallowConcurrentExecution]
    public class CheckCorrespondenciaProcessJob : IJob
    {
        /*
         *  ICorrespondenciaService correspondenciaService { get; set; }
        [Inject]
        IPdfGenerationService pdfGenerationService { get; set; }
        [Inject]
        IBlazorDownloadFileService blazorDownloadFileService { get; set; }
        [Inject]
        IEmailService emailService { get; set; }
         */
        //private readonly IDalService DalService;
        //private readonly IPdfGenerationService pdfGenerationService;
        //private readonly IEmailService emailService;
        //public CheckCorrespondenciaProcessJob(IDalService dalService, IPdfGenerationService pdfGenerationService, IEmailService emailService)
        //{
        //    DalService = dalService;
        //}


        public async Task Execute(IJobExecutionContext context)
        {
            await StartProcess();
        }


        private async Task StartProcess()
        {
            try
            {
                using (var serviceScope = Aig.Auditoria.Helper.Helper.serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    try {
                        var DalService = serviceScope.ServiceProvider.GetService<IDalService>();

                        DateTime date = DateTime.Now.AddDays(-26);
                        DateTime startDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                        DateTime endDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
                        var ldata = (from data in DalService.DBContext.Set<AUD_CorrespondenciaTB>()
                                     where data.Deleted == false
                                     && data.FechaIngreso >= startDate && data.FechaIngreso <= endDate
                                     && data.Status != DataModel.Helper.enumAUD_StatusCorrespondencia.FinalizadoDAC
                                     select data).ToList();

                        foreach (var data in ldata)
                        {
                            await SendEmailNotification(data);
                        }
                    }
                    catch { }
                }   
            }
            catch (Exception ex)
            { }
        }

        private async Task SendEmailNotification(AUD_CorrespondenciaTB data)
        {
            try
            {
                using (var serviceScope = Aig.Auditoria.Helper.Helper.serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    try {

                        var pdfGenerationService = serviceScope.ServiceProvider.GetService<IPdfGenerationService>();
                        var emailService = serviceScope.ServiceProvider.GetService<IEmailService>();

                        //var data = await correspondenciaService.Get(Id);
                        if (data != null && !string.IsNullOrEmpty(data.EmailDirigido))
                        {
                            var subject = string.Format("Correspondencia {0} Pendiente de Respuesta", data.SecNumberStr);

                            var builder = new BodyBuilder();

                            builder.TextBody = string.Format("Para: {0} \r\nFecha: {1} \r\nNum.: {2} \r\n\r\nAsunto: {3}\r\n\r\nObservaciones: {4}\r\n\r\nESTA CORRESPONDENCIA AUN ESTA PENDIENTE DE RESPUESTA!!! \r\n\r\nDe: Ana Belén Gonzáles\r\nJefa del Dpto. Auditorías de Calidad a \r\nEstablecimientos Farmacéuticos y NF", data.DptoSeccion, DateTime.Now.ToString("dd/MM/yyyy"), data.SecNumberStr, data.Asunto, data.Observaciones);

                            var stream = await pdfGenerationService.GenerateCorrespondencia(data.Id);
                            if (stream != null)
                            {
                                builder.Attachments.Add("correspondencia.pdf", stream);
                            }
                            List<string> listemails = new List<string>();
                            if (!string.IsNullOrEmpty(data.EmailDirigido)) { listemails.Add(data.EmailDirigido); }
                            if (!string.IsNullOrEmpty(data.CorrespondenciaResponsable?.Correo ?? null)) { listemails.Add(data.CorrespondenciaResponsable.Correo); }
                            if (listemails?.Count > 0)
                                await emailService.SendEmailAsync(listemails, subject, builder);
                        }
                    }
                    catch { }
                }                

            }
            catch (Exception ex) { }
        }


    }

}
