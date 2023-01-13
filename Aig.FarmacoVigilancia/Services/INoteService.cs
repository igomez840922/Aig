using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface INoteService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_NotaTB> model);
        Task<List<FMV_NotaTB>> FindAll(Expression<Func<FMV_NotaTB, bool>> match);
        Task<GenericModel<FMV_NotaTB>> FindAll(GenericModel<FMV_NotaTB> model);
        Task<List<FMV_NotaTB>> GetAll();
        Task<FMV_NotaTB> Get(long id);
        Task<FMV_NotaTB> Save(FMV_NotaTB data);
        Task<FMV_NotaTB> Delete(long id);
        Task<int> Count();

        Task<string> SendEmailNote(long id);
        Task NotifyNoteReaded(long Id);
    }

   
}
