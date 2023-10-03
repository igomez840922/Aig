using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Identity;

namespace AuditoriaApp.Services
{
    public interface IPaymentService
    {
        Task<LicenseClientTB> ChargeCreditCard(ChargeCreditCardModel model);
        
    }
}
