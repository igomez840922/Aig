using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using MimeKit;
using Microsoft.AspNetCore.Components;

namespace Aig.FarmacoVigilancia.Services
{    
    public class ContactService : IContactService
    {
        private readonly IDalService DalService;
        private readonly IEmailService emailService;
        private readonly IPdfGenerationService pdfGenerationService;
        private readonly NavigationManager navigationManager;
        public ContactService(IDalService dalService, IEmailService emailService, IPdfGenerationService pdfGenerationService, NavigationManager navigationManager)
        {
            DalService = dalService;
            this.emailService = emailService;
            this.pdfGenerationService = pdfGenerationService;
            this.navigationManager = navigationManager;
        }

        //List<T> FindAll<T>(Expression<Func<T, bool>> match)
        public async Task<List<FMV_ContactosTB>> FindAll(Expression<Func<FMV_ContactosTB, bool>> match)
        {
            try
            {
               return DalService.FindAll(match);
            }
            catch (Exception ex)
            { }

            return null;
        }


        public async Task<GenericModel<FMV_ContactosTB>> FindAll(GenericModel<FMV_ContactosTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<FMV_ContactosTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Cargo.Contains(model.Filter) || data.Instalacion.Contains(model.Filter) || data.Correo.Contains(model.Filter) || data.Telefono.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_ContactosTB>()
                               where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.Cargo.Contains(model.Filter) || data.Instalacion.Contains(model.Filter) || data.Correo.Contains(model.Filter) || data.Telefono.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<FMV_ContactosTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_ContactosTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_ContactosTB> Get(long Id)
        {
            var result = DalService.Get<FMV_ContactosTB>(Id);
            return result;
        }

        public async Task<FMV_ContactosTB> Save(FMV_ContactosTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<FMV_ContactosTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_ContactosTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_ContactosTB>(); }
            catch { }return 0;
        }

        public async Task<FMV_ContactosTB> UnSubscribe(UnSubscribeModel data)
        {
            var result = DalService.Find<FMV_ContactosTB>(x=>x.Correo == data.Correo);
            if (result != null)
            {
                return await Delete(result.Id);
            }

            return null;
        }

        public async Task<string> SendEmailSubscription(long Id)
        {
            try
            {
                var data = await Get(Id);
                if (data!=null)
                {
                    var subject = "Mensaje del Centro Nacional de Farmacovigilancia";

                    var builder = new BodyBuilder();

                    builder.TextBody = string.Format("Estimado {0}\r\n\r\nMuchas gracias por suscribirse al Sistema de Notificaciones de notas y alertas emitida por el Centro Nacional de Farmacovigilancia.\r\n\r\n\r\n" +
                        "Para cualquier consulta o información adicional puede contactarnos a través del correo electrónico fvigilancia@minsa.gob.pa.\r\n\r\n\r\n" +
                        "Saludos Cordiales\r\n\r\nCentro Nacional de Farmacovigilancia\r\nDepartamento de Farmacovigilancia\r\nDirección Nacional de Farmacia y Drogas\r\nMinisterio de Salud\r\n\r\n\r\n" +
                        "Nota: para darse de baja de dicho sistema haga click en el siguiente enlace: {1}", data.Nombre, string.Format("{0}{1}", navigationManager.BaseUri, "registrobaja"));

                    //builder.HtmlBody = string.Format("<p>Estimado {0}<br/><br/>Muchas gracias por suscribirse al Sistema de Notificaciones de notas y alertas emitida por el Centro Nacional de Farmacovigilancia.<br/><br/>" +
                    //    "Para cualquier consulta o información adicional puede contactarnos a través del correo electrónico <a href='mailto:fvigilancia@minsa.gob.pa'>fvigilancia@minsa.gob.pa</a>.<br/><br/><br/><br/>" +
                    //    "Saludos Cordiales<br/><br/>Centro Nacional de Farmacovigilancia<br/>Departamento de Farmacovigilancia<br/>Dirección Nacional de Farmacia y Drogas<br/>Ministerio de Salud</p>" +
                    //    "<p>Nota: para darse de baja de dicho sistema haga click en el siguiente enlace: <a href='{1}'>Darse de Baja</a></p>", data.Nombre, string.Format("{0}{1}", navigationManager.BaseUri, "registrobaja"));


                    List<string> lEmails = new List<string>() { data.Correo };

                    await emailService.SendEmailAsync(lEmails, subject, builder, "Centro Nacional de Farmacovigilancia");
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "el correo no pudo ser enviado";
        }

        
    }

}
