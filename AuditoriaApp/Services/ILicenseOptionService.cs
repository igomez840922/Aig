using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Identity;

namespace AuditoriaApp.Services
{
    public interface ILicenseOptionService
    {
        Task<GenericModel<LicenseOptionTB>> FindAll(GenericModel<LicenseOptionTB> model);
        Task<List<LicenseOptionTB>> GetAll();
        Task<LicenseOptionTB> Get(long Id);
        Task<LicenseOptionTB> Save(LicenseOptionTB data);
        Task<LicenseOptionTB> Delete(long Id);
        
    }
}
