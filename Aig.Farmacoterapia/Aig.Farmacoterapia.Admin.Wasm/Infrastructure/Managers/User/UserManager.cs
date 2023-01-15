using Aig.Farmacoterapia.Admin.Wasm.Extensions;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Admin.Wasm.Infrastructure.Managers.User
{
    public class UserManager : IUserManager
    {
        private readonly HttpClient _httpClient;

        public UserManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PaginatedResult<UserModelOutput>> SearchAsync(PageSearchArgs request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.UsersEndpoints.Search, request);
            return await response.ToPaginatedResult<UserModelOutput>();
        }
        public async Task<IResult<bool>> UsernameExists(string userName)
        {
            var response = await _httpClient.GetAsync(AppConstants.UsersEndpoints.UsernameExists(userName));
            return await response.ToResult<bool>();
        }
        public async Task<IResult<bool>> PhoneExists(string phone)
        {
            var response = await _httpClient.GetAsync(AppConstants.UsersEndpoints.PhoneExists(phone));
            return await response.ToResult<bool>();
        }
   
        //public async Task<IResult<int>> SaveAsync(AigMedicamento request)
        //{
        //    var response = await _httpClient.PostAsJsonAsync(AppConstants.AigMedicamentoEndpoints.Save, request);
        //    return await response.ToResult<int>();
        //}
        //public async Task<IResult> DeleteAsync(string id)
        //{
        //    var response = await _httpClient.DeleteAsync(AppConstants.AigMedicamentoEndpoints.Delete(id));
        //    return await response.ToResult();
        //}
    }
}