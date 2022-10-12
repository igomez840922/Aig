using DataAccess.Auditoria;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class InspeccionService : IInspeccionService
    {
        private readonly IDalService DalService;
        public InspeccionService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_InspeccionTB>> FindAll(string filter, int pIdx, int pAmt)
        {
            try
            {
                //var result = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                //              where data.UserRoleType == enumUserRoleType.None &&
                //              (string.IsNullOrEmpty(filter) ? true : (data.Email.Contains(filter) || data.UserProfile.FirstName.Contains(filter) || data.UserProfile.SecondName.Contains(filter) || data.UserProfile.SureName.Contains(filter) || data.UserProfile.SecondSurName.Contains(filter) || data.Email.Contains(filter) || data.PhoneNumber.Contains(filter)))
                //              orderby data.UserProfile.FirstName
                //              select data).Skip(pIdx * pAmt).Take(pAmt).ToList();

                //var count = (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                //             where data.UserRoleType == enumUserRoleType.None &&
                //             (string.IsNullOrEmpty(filter) ? true : (data.Email.Contains(filter) || data.UserProfile.FirstName.Contains(filter) || data.UserProfile.SecondName.Contains(filter) || data.UserProfile.SureName.Contains(filter) || data.UserProfile.SecondSurName.Contains(filter) || data.Email.Contains(filter) || data.PhoneNumber.Contains(filter)))
                //             select data).Count();

                //return new GenericModel<AUD_InspeccionTB>() { Ldata = result, Total = count };
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<List<AUD_InspeccionTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_InspeccionTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_InspeccionTB> Get(long Id)
        {
            var result = DalService.Get<AUD_InspeccionTB>(Id);
            return result;
        }

        public async Task<AUD_InspeccionTB> Save(AUD_InspeccionTB data)
        {
            var result = DalService.Save(data);
            return result;           
        }

        public async Task<AUD_InspeccionTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_InspeccionTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_InspeccionTB>(); }
            catch { }return 0;
        }
    }

}
