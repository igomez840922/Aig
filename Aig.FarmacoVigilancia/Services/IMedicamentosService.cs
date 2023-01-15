using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IMedicamentosService
    {
        Task<ProdServiceDataResponse> FindAll(ProdServiceDataRequest request);
    }

   
}
