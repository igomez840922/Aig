using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class DestinyInstituteService : IDestinyInstituteService
    {
        private readonly IDalService DalService;
        public DestinyInstituteService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<InstitucionDestinoTB>> FindAll(GenericModel<InstitucionDestinoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<InstitucionDestinoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<InstitucionDestinoTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<InstitucionDestinoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<InstitucionDestinoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<InstitucionDestinoTB> Get(long Id)
        {
            var result = DalService.Get<InstitucionDestinoTB>(Id);
            return result;
        }

        public async Task<InstitucionDestinoTB> Save(InstitucionDestinoTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<InstitucionDestinoTB> Delete(long Id)
        {
            var data = DalService.Delete<InstitucionDestinoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<InstitucionDestinoTB>(); }
            catch { }return 0;
        }
    }

}
