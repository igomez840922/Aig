using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{    
    public class AttachmentsService : IAttachmentsService
    {
        private readonly IDalService DalService;
        public AttachmentsService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AttachmentTB>> FindAll(GenericModel<AttachmentTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  = (from data in DalService.DBContext.Set<AttachmentTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Description.Contains(model.Filter)))
                              orderby data.Description
                                select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AttachmentTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.Description.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<AttachmentTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AttachmentTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AttachmentTB> Get(long Id)
        {
            var result = DalService.Get<AttachmentTB>(Id);
            return result;
        }

        public async Task<AttachmentTB> Save(AttachmentTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<AttachmentTB> Delete(long Id)
        {
            var data = DalService.Delete<AttachmentTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AttachmentTB>(); }
            catch { }return 0;
        }
    }

}
