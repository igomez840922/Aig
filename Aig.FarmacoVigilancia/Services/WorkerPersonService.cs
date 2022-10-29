using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class WorkerPersonService : IWorkerPersonService
    {
        private readonly IDalService DalService;
        public WorkerPersonService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<PersonalTrabajadorTB>> FindAll(GenericModel<PersonalTrabajadorTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<PersonalTrabajadorTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.NombreCompleto.Contains(model.Filter)))
                              orderby data.NombreCompleto
                                select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<PersonalTrabajadorTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.NombreCompleto.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<PersonalTrabajadorTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<PersonalTrabajadorTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<PersonalTrabajadorTB> Get(long Id)
        {
            var result = DalService.Get<PersonalTrabajadorTB>(Id);
            return result;
        }

        public async Task<PersonalTrabajadorTB> Save(PersonalTrabajadorTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<PersonalTrabajadorTB> Delete(long Id)
        {
            var data = DalService.Delete<PersonalTrabajadorTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<PersonalTrabajadorTB>(); }
            catch { }return 0;
        }
    }

}
