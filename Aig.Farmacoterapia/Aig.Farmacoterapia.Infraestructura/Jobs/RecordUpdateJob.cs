using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Aig.Farmacoterapia.Infrastructure.Services.Integration;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Jobs
{
    [DisallowConcurrentExecution]
    public class RecordUpdateJob : IJob
    {
        private readonly ISystemLogger _logger;
        private readonly ISysFarmService _sysFarmService;
        
        public RecordUpdateJob(
            ISysFarmService sysFarmService,
            ISystemLogger logger)
        {
            _sysFarmService = sysFarmService;
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _logger.Debug($"Execute SendEmailJob {DateTime.Now}");
            var result= _sysFarmService.GetAllRecords();
            return Task.FromResult(true);
        }
    }
}
