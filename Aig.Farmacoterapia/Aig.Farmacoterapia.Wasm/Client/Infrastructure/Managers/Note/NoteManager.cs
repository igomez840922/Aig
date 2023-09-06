using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Wasm.Client.Extensions;
using System.Net.Http.Json;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Note
{
    public class NoteManager : INoteManager
    {
        private readonly HttpClient _httpClient;

        public NoteManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
     
        public async Task<IResult> DeleteAsync(long id)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.CodesEndpoints.Delete, new { id = id });
            return await response.ToResult();
        }

        public async Task<IResult> SendAsync(string code, UploadFileDTO file)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.ReportEndpoints.SendNote, new { code = code,file= file });
            return await response.ToResult();
        }
    }
}