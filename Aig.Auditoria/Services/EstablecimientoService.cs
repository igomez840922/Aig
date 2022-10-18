using DataAccess.Auditoria;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{    
    public class EstablecimientoService : IEstablecimientoService
    {
        private readonly IDalService DalService;
        public EstablecimientoService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_EstablecimientoTB>> FindAll(GenericModel<AUD_EstablecimientoTB> model)
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
