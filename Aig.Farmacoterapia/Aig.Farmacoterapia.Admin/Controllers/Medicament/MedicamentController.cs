
using Aig.Farmacoterapia.Application.Medicament.Model;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Admin.Controllers.Identity
{
    [ApiController]
    [Route("api/medicaments")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    public class MedicamentController : ControllerBase
    {
        private readonly IMedicamentRepository _repository;
        private readonly ISystemLogger _systemLogger;
  
        public MedicamentController(IMedicamentRepository repository, ISystemLogger systemLogger)
        {
            _repository = repository;
            _systemLogger = systemLogger;
        }
        
        [HttpPost]
        public async Task<PaginatedResult<AigMedicamento>> List([FromBody] MedicamentPageSearch args)
        {
            try
            {
                var searchArgs = new PageSearchArgs(){
                    PageIndex = args.PageIndex,
                    PageSize = args.PageSize,
                    FilteringOptions = !string.IsNullOrEmpty(args.Term) ? new List<FilteringOption>() {
                        new FilteringOption {
                            Field = "term", Operator = FilteringOperator.Contains, Value = args.Term
                        }
                    } : new List<FilteringOption>()
                };
                return await _repository.ListAsync(searchArgs);
            }
            catch (Exception ex) {
                _systemLogger.Error(ex.Message);
                return PaginatedResult<AigMedicamento>.Failure(new List<string>() { ex.Message });
            }
           
        }
    }

  
}