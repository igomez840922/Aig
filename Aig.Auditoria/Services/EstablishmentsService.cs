using DataAccess.Auditoria;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

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
                var result = (from data in DalService.DBContext.Set<AUD_EstablecimientoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.NumLicencia.Contains(model.Filter) || data.Institucion.Contains(model.Filter) || data.Telefono1.Contains(model.Filter) || data.Telefono2.Contains(model.Filter) || data.Email.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                var count = (from data in DalService.DBContext.Set<AUD_EstablecimientoTB>()
                             where data.Deleted == false &&
                             (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.NumLicencia.Contains(model.Filter) || data.Institucion.Contains(model.Filter) || data.Telefono1.Contains(model.Filter) || data.Telefono2.Contains(model.Filter) || data.Email.Contains(model.Filter)))
                             select data).Count();

                return new GenericModel<AUD_EstablecimientoTB>() { Ldata = result, Total = count };
            }
            catch (Exception ex)
            { }

            return null;
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
