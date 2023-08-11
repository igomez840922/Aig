using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Microsoft.EntityFrameworkCore;
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
            var result = await _service.GetRecords();
            //if (result?.Status == true && result?.Registros.Count > 0)
            if (result?.Registros.Count>0)
            {
                await _unitOfWork.ExecuteInTransactionAsync(async (cc) => {
                    await _unitOfWork.BeginTransactionAsync(cc);
                    foreach (var item in result.Registros){
                        AigRecord record;
                        if ((record = _unitOfWork.Repository<AigRecord>().Entities.AsNoTracking().FirstOrDefault(p => p.Numero == item.Numero)) != null)
                        {
                            item.Id = record.Id;
                            item.DataSheetURL = record.DataSheetURL;
                            item.ProspectusURL = record.ProspectusURL;
                            item.PictureData = record.PictureData;
                        }
                        await _unitOfWork.Repository<AigRecord>().UpdateAsync(item);
                    }
                    var commit = await _unitOfWork.CommitAsync(cc);
                }, default);
            }
            return;
        }
    }
}
