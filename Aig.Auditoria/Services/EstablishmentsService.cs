using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Aig.Auditoria.Services
{    
    public class EstablishmentsService : IEstablishmentsService
    {
        private readonly IDalService DalService;
        public EstablishmentsService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_EstablecimientoTB>> FindAll(GenericModel<AUD_EstablecimientoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<AUD_EstablecimientoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.NumLicencia.Contains(model.Filter) || data.Institucion.Contains(model.Filter) || data.Telefono1.Contains(model.Filter) || data.Telefono2.Contains(model.Filter) || data.Email.Contains(model.Filter)  ))//|| DataAccess.Helper.Helper.JsonValue("Regente", "NumIdoneidad") == model.Filter
                                orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_EstablecimientoTB>()
                             where data.Deleted == false &&
                             (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.NumLicencia.Contains(model.Filter) || data.Institucion.Contains(model.Filter) || data.Telefono1.Contains(model.Filter) || data.Telefono2.Contains(model.Filter) || data.Email.Contains(model.Filter) ))//|| || DataAccess.Helper.Helper.JsonValue("Regente", "NumIdoneidad") == model.Filter
                               select data).Count();

                //MyDbContext.JsonValue(e.ColumnaJson, "MiClave") == "MiValor")
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<AUD_EstablecimientoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_EstablecimientoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_EstablecimientoTB> Get(long Id)
        {
            var result = DalService.Get<AUD_EstablecimientoTB>(Id);
            return result;
        }

        public async Task<AUD_EstablecimientoTB> Save(AUD_EstablecimientoTB data)
        {
            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.FarmaceuticoTablas).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.Regente).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.RepresentanteLegal).IsModified = true;

                DalService.DBContext.SaveChanges();
            }
            return result;           
        }

        public async Task<AUD_EstablecimientoTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_EstablecimientoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_EstablecimientoTB>(); }
            catch { }return 0;
        }
    }

}
