﻿using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface ISystemUserService
    {
        Task<GenericModel<ApplicationUser>> FindAll(string filter, int pIdx, int pAmt);
        Task<List<ApplicationUser>> GetAll();
        Task<ApplicationUser> Get(string id);
        Task<IdentityResult> Save(ApplicationUser data);
        Task<IdentityResult> Delete(string id);
        Task<IdentityResult> ChangePsw(ApplicationUser data);
        Task<bool> SetUserLanguaje(string id, string languaje);
    }
}