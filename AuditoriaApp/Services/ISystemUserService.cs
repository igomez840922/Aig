using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace AuditoriaApp.Services
{
    public interface ISystemUserService
    {
        Task<GenericModel<ApplicationUser>> FindAll(GenericModel<ApplicationUser> model);
        Task<List<ApplicationUser>> GetAll();
        Task<ApplicationUser> Get(string Id);
        Task<ApiResponse> Save(DataModel.Models.RegisterModel data);
        Task<ApiResponse> Update(ApplicationUser data);
        Task<ApiResponse> Delete(string Id);
        Task<ApiResponse> ChangePsw(ChangePswModel data);

        Task<ApplicationUser> GetByName(string name);
    }
}
