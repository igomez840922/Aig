using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Interfaces
{
    public interface IUserService : IService
    {
        Task<PaginatedResult<ApplicationUser>> ListAsync(PageSearchArgs args);
        Task<Result<List<ApplicationUser>>> GetAllAsync();
        Task<int> GetCountAsync();
        Task<ApplicationUser> GetUserByNameAsync(string userName);
        ApplicationUser GetUserByName(string userName);
        ApplicationUser GetUserByPhone(string phone);
        Task<ApplicationUser> GetAsync(string userId);
        Task<IResult> SaveAsync(ApplicationUser data);
        Task<IResult> DeleteDeleteAsync(string id);
        Task<IResult> RegisterAsync(RegisterRequest request, string origin);
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model);
        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model);
        Task<IResult> ToggleUserStatusAsync(string userId, bool activate);
        Task<IResult<UserRolesResponse>> GetRolesAsync(string id);
        Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request);
        Task<IResult<string>> ConfirmEmailAsync(string userId, string code);
        Task<IResult> ChangePasswordAsync(ApplicationUser data);
        Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);
    }
}
