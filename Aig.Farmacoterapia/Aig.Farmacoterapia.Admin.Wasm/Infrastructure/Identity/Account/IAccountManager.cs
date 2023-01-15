using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Admin.Wasm.Infrastructure;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;

namespace BlazorHero.CleanArchitecture.Client.Infrastructure.Managers.Identity.Account
{
    public interface IAccountManager : IManager
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model);
        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model);
        Task<IResult> UploadProfilePictureAsync(UploadObject model);
        Task<IResult> DeleteProfilePictureAsync(UploadType uploadType, string image);
    }
}