using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Forms;

namespace AuditoriaApp.Services
{
    public interface IFeatureService
    {
        Task<double> GetScreenHeight();

    }
}
