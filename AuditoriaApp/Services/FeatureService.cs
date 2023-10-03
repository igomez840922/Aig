using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Blazored.LocalStorage;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;

namespace AuditoriaApp.Services
{    
    public class FeatureService : IFeatureService
    {
        public FeatureService()
        {
            
        }

        public async Task<double> GetScreenHeight()
        {
            try {
                var displayInfo = DeviceDisplay.MainDisplayInfo;
                return displayInfo.Height;
            }
            catch (Exception ex) { }
            return 0;
        }
                
        


    }

}
