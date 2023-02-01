using DataAccess;
using DataModel.Models;
using DataModel;

namespace Aig.FarmacoVigilancia.Services
{
   
    public class FarmacoService : IFarmacoService
    {
        private readonly IDalService DalService;
        public FarmacoService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FarmacoTB>> FindAll(GenericModel<FarmacoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FarmacoTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NombreComercial.Contains(model.Filter) || data.NombreDCI.Contains(model.Filter)))
                               orderby data.NombreDCI
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FarmacoTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NombreComercial.Contains(model.Filter) || data.NombreDCI.Contains(model.Filter)))
                               select data).Count();
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<FarmacoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FarmacoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FarmacoTB> Get(long Id)
        {
            var result = DalService.Get<FarmacoTB>(Id);
            return result;
        }

        public async Task<FarmacoTB> Save(FarmacoTB data)
        {
            var result = DalService.Save(data);
            return result;
        }

        public async Task<FarmacoTB> Delete(long Id)
        {
            var data = DalService.Delete<FarmacoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FarmacoTB>(); }
            catch { }
            return 0;
        }
    }

}
