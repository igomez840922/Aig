using Aig.Farmacoterapia.Admin.Wasm.Infrastructure;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;

namespace Aig.Farmacoterapia.Admin.Wasm.Infrastructure.Managers.User
{
    public interface IUserManager : IManager
    {
        Task<PaginatedResult<UserModelOutput>> SearchAsync(PageSearchArgs request);
        Task<IResult<bool>> UsernameExists(string userName);
        Task<IResult<bool>> PhoneExistsAsync(string userName);
        Task<IResult<UpdateProfileRequest>> GetAsync(string userName);
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model);
        Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest model);
        Task<IResult> AddUserAsync(RegisterRequest model);
        Task<IResult> DeleteUserAsync(string id);
        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model);
        Task<IResult> DeleteProfilePictureAsync(UploadType uploadType, string image);
        Task<IResult> UploadProfilePictureAsync(UploadObject model);
    }
}
