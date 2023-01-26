using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IApiConnectionFileUploadService
    {
        HttpClient Client { get; set; }
        void Dispose();
    }

   
}
