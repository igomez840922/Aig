using DataAccess;
using DataAccess;
using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;

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

        //public async Task<GenericModel<ApplicationUser>> FindAll(string filter, int pIdx, int pAmt)
        //{
        //    try
        //    {
        //        var result = (from data in DalService.DBContext.Set<ApplicationUser>()
        //                      where data.UserRoleType == enumUserRoleType.Admin &&
        //                      (string.IsNullOrEmpty(filter) ? true : (data.Email.Contains(filter) || data.UserProfile.FirstName.Contains(filter) || data.UserProfile.SecondName.Contains(filter) || data.UserProfile.SureName.Contains(filter) || data.UserProfile.SecondSurName.Contains(filter) || data.Email.Contains(filter) || data.PhoneNumber.Contains(filter)))
        //                      orderby data.UserProfile.FirstName                              
        //                      select data).Skip(pIdx * pAmt).Take(pAmt).ToList();

        //        var count = (from data in DalService.DBContext.Set<ApplicationUser>()
        //                     where data.UserRoleType == enumUserRoleType.Admin &&
        //                     (string.IsNullOrEmpty(filter) ? true : (data.Email.Contains(filter) || data.UserProfile.FirstName.Contains(filter) || data.UserProfile.SecondName.Contains(filter) || data.UserProfile.SureName.Contains(filter) || data.UserProfile.SecondSurName.Contains(filter) || data.Email.Contains(filter) || data.PhoneNumber.Contains(filter)))
        //                     select data).Count();

        //        return new GenericModel<ApplicationUser>() { Ldata = result, Total = count };
        //    }
        //    catch (Exception ex)
        //    { }

        //    return null;
        //}

        //public async Task<List<ApplicationUser>> GetAll()
        //{
        //    return (from data in DalService.DBContext.Set<ApplicationUser>()
        //            where data.UserRoleType != enumUserRoleType.None 
        //            select data).ToList();
        //}

        //public async Task<ApplicationUser> Get(string Id)
        //{
        //    var result = DalService.DBContext.Set<ApplicationUser>().Find(Id);

        //    return result;
        //}

        //public async Task<IdentityResult> Save(ApplicationUser data)
        //{
        //    data.UserRoleType =  enumUserRoleType.Admin;
        //    data.UserName = data.Email;
        //    var user = await UserManager.FindByIdAsync(data.Id);
        //    if (user == null)
        //    {
        //        var result = await UserManager.CreateAsync(data, data.Password);
        //        if (result.Succeeded)
        //        {
        //            await UserManager.AddToRoleAsync(data, DataModel.Helper.Helper.GetDescription<enumUserRoleType>(enumUserRoleType.Admin));
        //        }
        //        return result;
        //    }
        //    else
        //    {                
        //        var result = await UserManager.UpdateAsync(user);

        //        return result;
        //    }

        //    return null;
        //}

        //public async Task<IdentityResult> Delete(string Id)
        //{
        //    var user = await UserManager.FindByIdAsync(Id);

        //    var result = await UserManager.DeleteAsync(user);

        //    return result;
        //}

        //public async Task<IdentityResult> ChangePsw(ApplicationUser data)
        //{
        //    var user = await UserManager.FindByIdAsync(data.Id);
        //    if (user != null)
        //    {
        //        await UserManager.RemovePasswordAsync(user);

        //        return await UserManager.AddPasswordAsync(user, data.Password);
        //    }

        //    return null;
        //}

        //public async Task<bool> SetUserLanguaje(string id, string languaje)
        //{
        //    var result = DalService.DBContext.Set<ApplicationUser>().Find(id);
        //    if (result != null)
        //    {
        //        result.UserProfile = result.UserProfile != null ? result.UserProfile : new UserProfileTB();
        //        result.UserProfile.Languanje = languaje;
        //        if(DalService.Save(result.UserProfile) != null)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //////////////////////////////////////////////////////////////////
        ///
               
        public async Task<GenericModel<ApplicationUser>> FindAll(GenericModel<ApplicationUser> model)
        {
            try
            {
                model.Ldata = null;
                model.Total = 0;
                model.Ldata = (from data in DalService.DBContext.Set<ApplicationUser>()
                               where 
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.UserProfile.FirstName.Contains(model.Filter) || data.UserProfile.SecondName.Contains(model.Filter) || data.UserProfile.SureName.Contains(model.Filter) || data.UserProfile.SecondSurName.Contains(model.Filter) || data.Email.Contains(model.Filter) || data.PhoneNumber.Contains(model.Filter)))
                               orderby data.UserProfile.FirstName
                               select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<ApplicationUser>()
                               where 
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.UserProfile.FirstName.Contains(model.Filter) || data.UserProfile.SecondName.Contains(model.Filter) || data.UserProfile.SureName.Contains(model.Filter) || data.UserProfile.SecondSurName.Contains(model.Filter) || data.Email.Contains(model.Filter) || data.PhoneNumber.Contains(model.Filter)))
                               select data).Count();

                return model;
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return (from data in DalService.DBContext.Set<ApplicationUser>()
                    select data).ToList();
        }

        public async Task<ApplicationUser> Get(string Id)
        {
            var result = DalService.DBContext.Set<ApplicationUser>().Find(Id);

            return result;
        }

        public async Task<ApplicationUser> GetByName(string name)
        {
            var result = DalService.DBContext.Set<ApplicationUser>().Where(x => x.UserName == name).FirstOrDefault();

            return result;
        }

		public async Task<ApplicationUser> GetUser(string name)
		{
			var result = DalService.DBContext.Set<ApplicationUser>().Where(x => x.UserName == name).FirstOrDefault();
            if (result == null)
            {
                result = DalService.DBContext.Set<ApplicationUser>().Where(x => x.Email == name).FirstOrDefault();
            }
			return result;
		}

		public async Task<IdentityResult> Save(DataModel.Models.RegisterModel data)
        {
            //data.UserRoleType = enumUserRoleType.Admin;
            data.UserName = data.UserName;

            var appUser = new ApplicationUser() { UserProfile = new UserProfileTB() { FirstName = data.FirstName, SecondName = data.SecondName, SureName = data.SureName, SecondSurName = data.SecondSurName,  }, Email = data.UserName, UserName = data.UserName, UserRoleType = data.UserRoleType, PhoneNumber= data.PhoneNumber };
            var user = await UserManager.FindByIdAsync(appUser.Id);
            if (user == null)
            {
                var result = await UserManager.CreateAsync(appUser, data.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(appUser, DataModel.Helper.Helper.GetDescription<enumUserRoleType>(appUser.UserRoleType));
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

        public async Task<IdentityResult> Update(ApplicationUser data)
        {
            try
            {
                //data.UserRoleType = enumUserRoleType.Admin;
                data.UserName = data.UserName;
                data.Email = data.UserName;

                var user = await UserManager.FindByIdAsync(data.Id);
                user.UserProfile = data.UserProfile;

                var result = await UserManager.UpdateAsync(user);

                return result;
            }
            catch (Exception ex)
            {

            }
            return null;
        }


        public async Task<IdentityResult> Delete(string Id)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(Id);

            if (user != null) //&& user.FromSystem
                return IdentityResult.Failed(new IdentityError[] { new IdentityError() { Code = "", Description = "los datos no pudieron ser eliminados" } });

            var result = await UserManager.DeleteAsync(user);

            return result;
        }

        public async Task<IdentityResult> ChangePsw(ChangePswModel data)
        {
            var user = await UserManager.FindByIdAsync(data.Id);
            if (user != null)
            {
                await UserManager.RemovePasswordAsync(user);

                return await UserManager.AddPasswordAsync(user, data.Password);
            }

            return null;
        }

		public async Task<ApiResponse> ChangePswPIN(ChangePswPinModel data)
		{
			var user = await GetUser(data.UserName);
			if (user != null)
			{
                if(string.Compare(user.pinNum, data.PinNumber,true) != 0)
                {
					return new ApiResponse() { Result = false, Message = "Número PIN inválido" };
				}

				if (user.pinDateValid< DateTime.Now)
				{
					return new ApiResponse() { Result = false, Message = "El número PIN ha caducado" };
				}

				await UserManager.RemovePasswordAsync(user);

				var response = await UserManager.AddPasswordAsync(user, data.Password);
                if(response.Succeeded)
                {
					return new ApiResponse() { Result = true, Message = "contraseña actualizada satisfactoriamente" };

				}
			}

			return new ApiResponse() { Result=false, Message="error al cambiar su contraseña" };
		}

		public async Task<bool> SetUserLanguaje(string id, string languaje)
        {
            var result = DalService.DBContext.Set<ApplicationUser>().Find(id);
            if (result != null)
            {
                result.UserProfile = result.UserProfile != null ? result.UserProfile : new UserProfileTB();
                result.UserProfile.Languanje = languaje;
                if (DalService.Save(result.UserProfile) != null)
                {
                    return true;
                }
            }
            return false;
        }


    }

}
