using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{    
    public class ContactService : IContactService
    {
        private readonly IDalService DalService;
        public ContactService(IDalService dalService)
        {
            DalService = dalService;
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
    }

}
