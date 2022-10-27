using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class SmtpCorreoService : ISmtpCorreoService
    {
        private readonly IDalService DalService;
        public SmtpCorreoService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<SmtpCorreoTB>> FindAll(GenericModel<SmtpCorreoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<SmtpCorreoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Usuario.Contains(model.Filter) || data.SmtpServidor.Contains(model.Filter) || data.Correo.Contains(model.Filter)))
                              orderby data.Usuario
                                select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<SmtpCorreoTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Usuario.Contains(model.Filter) || data.SmtpServidor.Contains(model.Filter) || data.Correo.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<SmtpCorreoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<SmtpCorreoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<SmtpCorreoTB> Get(long Id)
        {
            var result = DalService.Get<SmtpCorreoTB>(Id);
            return result;
        }

        public async Task<SmtpCorreoTB> GetDefault()
        {
            var result = DalService.First<SmtpCorreoTB>();
            return result;
        }

        public async Task<SmtpCorreoTB> Save(SmtpCorreoTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<SmtpCorreoTB> Delete(long Id)
        {
            var data = DalService.Delete<SmtpCorreoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<SmtpCorreoTB>(); }
            catch { }return 0;
        }
    }

}
