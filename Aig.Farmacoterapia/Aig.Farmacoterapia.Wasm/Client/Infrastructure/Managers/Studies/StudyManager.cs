﻿using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Wasm.Client.Extensions;
using System.Net.Http.Json;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Studies
{
    public class StudyManager : IStudyManager
    {
        private readonly HttpClient _httpClient;

        public StudyManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
     
        public async Task<PaginatedResult<AigEstudio>> SearchAsync(PageSearchArgs request)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioEndpoints.Search, request);
            return await response.ToPaginatedResult<AigEstudio>();
        }

        public async Task<IResult<AigEstudio>> GetAsync(long id)
        {   
            var response = await _httpClient.GetAsync(AppConstants.EstudioEndpoints.Get(id));
            return await response.ToResult<AigEstudio>();
        }
    
        public async Task<IResult<bool>> UpdateAsync(AigEstudio request)
        {

            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioEndpoints.Update, request);
            return await response.ToResult<bool>();

        }
        public async Task<IResult> DeleteAsync(long id)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioEndpoints.Delete, new { id = id });
            return await response.ToResult();
        }
        public async Task<IResult<List<UserModelOutput>>> GetEvaluators(long id)
        {
            var response = await _httpClient.GetAsync(AppConstants.EstudioEndpoints.GetEvaluators(id));
            return await response.ToResult<List<UserModelOutput>>();
        }
        public async Task<IResult> SetEvaluatorsAsync(long id, string[] evaluators)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.EstudioEndpoints.Evaluators, new { studyId = id, evaluators = evaluators });
            return await response.ToResult();
        }
       
    }
}