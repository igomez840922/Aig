using DataAccess;
using DataAccess;
using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public class SystemUserService : ISystemUserService
    {
        private readonly IDalService DalService;
        private readonly UserManager<ApplicationUser> UserManager;
        public SystemUserService(UserManager<ApplicationUser> userManager, IDalService dalService)
        {
            DalService = dalService;
            UserManager = userManager;
        }

        public async Task<GenericModel<ApplicationUser>> FindAll(string filter, int pIdx, int pAmt)
        {
            try
            {
                var result = (from data in DalService.DBContext.Set<ApplicationUser>()
                              where data.UserRoleType == enumUserRoleType.Admin &&
                              (string.IsNullOrEmpty(filter) ? true : (data.Email.Contains(filter) || data.UserProfile.FirstName.Contains(filter) || data.UserProfile.SecondName.Contains(filter) || data.UserProfile.SureName.Contains(filter) || data.UserProfile.SecondSurName.Contains(filter) || data.Email.Contains(filter) || data.PhoneNumber.Contains(filter)))
                              orderby data.UserProfile.FirstName                              
                              select data).Skip(pIdx * pAmt).Take(pAmt).ToList();

                var count = (from data in DalService.DBContext.Set<ApplicationUser>()
                             where data.UserRoleType == enumUserRoleType.Admin &&
                             (string.IsNullOrEmpty(filter) ? true : (data.Email.Contains(filter) || data.UserProfile.FirstName.Contains(filter) || data.UserProfile.SecondName.Contains(filter) || data.UserProfile.SureName.Contains(filter) || data.UserProfile.SecondSurName.Contains(filter) || data.Email.Contains(filter) || data.PhoneNumber.Contains(filter)))
                             select data).Count();

                return new GenericModel<ApplicationUser>() { Ldata = result, Total = count };
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return (from data in DalService.DBContext.Set<ApplicationUser>()
                    where data.UserRoleType == enumUserRoleType.Admin 
                    select data).ToList();
        }

        public async Task<ApplicationUser> Get(string Id)
        {
            var result = DalService.DBContext.Set<ApplicationUser>().Find(Id);

            return result;
        }

        public async Task<IdentityResult> Save(ApplicationUser data)
        {
            data.UserRoleType =  enumUserRoleType.Admin;
            data.UserName = data.Email;
            var user = await UserManager.FindByIdAsync(data.Id);
            if (user == null)
            {
                var result = await UserManager.CreateAsync(data, data.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(data, DataModel.Helper.Helper.GetDescription<enumUserRoleType>(enumUserRoleType.Admin));
                }
                return result;
            }
            else
            {                
                var result = await UserManager.UpdateAsync(user);

                return result;
            }

            return null;
        }

        public async Task<IdentityResult> Delete(string Id)
        {
            var user = await UserManager.FindByIdAsync(Id);

            var result = await UserManager.DeleteAsync(user);

            return result;
        }

        public async Task<IdentityResult> ChangePsw(ApplicationUser data)
        {
            var user = await UserManager.FindByIdAsync(data.Id);
            if (user != null)
            {
                await UserManager.RemovePasswordAsync(user);

                return await UserManager.AddPasswordAsync(user, data.Password);
            }

            return null;
        }

        public async Task<bool> SetUserLanguaje(string id, string languaje)
        {
            var result = DalService.DBContext.Set<ApplicationUser>().Find(id);
            if (result != null)
            {
                result.UserProfile = result.UserProfile != null ? result.UserProfile : new UserProfileTB();
                result.UserProfile.Languanje = languaje;
                if(DalService.Save(result.UserProfile) != null)
                {
                    return true;
                }
            }
            return false;
        }


    }

}
