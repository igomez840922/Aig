using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Quartz;

namespace Aig.Farmacoterapia.Infrastructure.Jobs
{
    [DisallowConcurrentExecutionAttribute()]
    public class RecordUpdateJob : IJob
    {
        private readonly ISysFarmService _sysFarmService;
        private readonly ISirFadServices _sirFadServices;
        private readonly ISystemLogger _logger;
        public RecordUpdateJob(
            ISysFarmService sysFarmService,
            ISirFadServices sirFadServices,
            ISystemLogger logger)
        {
            _sysFarmService = sysFarmService;
            _sirFadServices = sirFadServices;
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.Debug($"Execute SYSFARM Update Job {string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", DateTime.Now)}");
            await _sysFarmService.GetRecords();
            _logger.Debug($"Execute SIRFAD Update Job {string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", DateTime.Now)}");
            await _sirFadServices.GetRecords();
        }
    }
}
