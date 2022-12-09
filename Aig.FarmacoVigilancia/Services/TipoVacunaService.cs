using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class TipoVacunaService : ITipoVacunaService
    {
        private readonly IDalService DalService;
        public TipoVacunaService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<TipoVacunaTB>> FindAll(GenericModel<TipoVacunaTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<TipoVacunaTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                              orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<TipoVacunaTB>()
                             where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<TipoVacunaTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<TipoVacunaTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<TipoVacunaTB> Get(long Id)
        {
            var result = DalService.Get<TipoVacunaTB>(Id);
            return result;
        }

        public async Task<TipoVacunaTB> Save(TipoVacunaTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<TipoVacunaTB> Delete(long Id)
        {
            var data = DalService.Delete<TipoVacunaTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<TipoVacunaTB>(); }
            catch { }return 0;
        }
    }

}
