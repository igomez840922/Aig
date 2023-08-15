using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Aig.Farmacoterapia.Infrastructure.Jobs
{
    [Quartz.DisallowConcurrentExecutionAttribute()]
    public class SysFarmUpdateJob : IJob
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISysFarmService _sysFarmService;
        private readonly ISystemLogger _logger;

        public SysFarmUpdateJob(
            IUnitOfWork unitOfWork,
            ISysFarmService sysFarmService,
            ISystemLogger logger)
        {
            _unitOfWork = unitOfWork;
            _sysFarmService = sysFarmService;
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.Debug($"Execute SYSFARM Update Job {string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", DateTime.Now)}");
             await _sysFarmService.GetRecords();
        }
    }
}
