using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Quartz;

namespace Aig.Farmacoterapia.Infrastructure.Jobs
{
    [Quartz.DisallowConcurrentExecutionAttribute()]
    public class SirFadUpdateJob : IJob
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISirFadServices _service;
        private readonly ISystemLogger _logger;

        public SirFadUpdateJob(
            IUnitOfWork unitOfWork,
            ISirFadServices service,
            ISystemLogger logger)
        {
            _unitOfWork = unitOfWork;
            _service = service;
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.Debug($"Execute SIRFAD Update Job {string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", DateTime.Now)}");
            await _service.GetRecords();
        }
    }
}
