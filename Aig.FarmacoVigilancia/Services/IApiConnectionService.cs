using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IApiConnectionService
    {
        HttpClient Client { get; set; }
        void Dispose();
    }

   
}
