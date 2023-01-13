using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IContactService
    {
        Task<List<FMV_ContactosTB>> FindAll(Expression<Func<FMV_ContactosTB, bool>> match);

        Task<GenericModel<FMV_ContactosTB>> FindAll(GenericModel<FMV_ContactosTB> model);
        Task<List<FMV_ContactosTB>> GetAll();
        Task<FMV_ContactosTB> Get(long id);
        Task<FMV_ContactosTB> Save(FMV_ContactosTB data);
        Task<FMV_ContactosTB> Delete(long id);
        Task<int> Count();

        Task<FMV_ContactosTB> UnSubscribe(UnSubscribeModel data);

        Task<string> SendEmailSubscription(long id);
    }

   
}
