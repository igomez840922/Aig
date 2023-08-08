using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Aig.Farmacoterapia.Infrastructure.Persistence;
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
            _logger.Debug($"Execute SendEmailJob {DateTime.Now}");
            var result=await _sysFarmService.GetRecords();
            if (result != null)
            {
                await _unitOfWork.ExecuteInTransactionAsync(async (cc) => {
                    await _unitOfWork.BeginTransactionAsync(cc);
                    //if (await _accountRepository.UpdateAsync(account, cc) &&
                    //    await _remittanceApprovalEventRepository.DeleteEventByUserIdAsync(account.Id, cc))
                    //{
                    //    if (await _unitOfWork.CommitAsync(cc))
                    //    {
                    //        //Send push notification
                    //        await SendPushNotificationAsync(account.Username, account.RemittanceApproval.Metadata.AcceptLanguage ?? "en", account.RemittanceApproval.Status, cc);
                    //        //Send sms notification
                    //        await SendSmsNotificationAsync(account.PhoneNumber, account.RemittanceApproval.Metadata.AcceptLanguage ?? "en", account.RemittanceApproval.Status, cc);
                    //        //Send support notification
                    //        await SendSupportNotificationAsync(account.Username, account.RemittanceApproval.Status, cc);
                    //        //Send Log notification
                    //        await _logger.LogAsync(this, LogType.Alert, $"Approved User Notification {account.Username}", cancellationToken: cc);
                    //    }
                    //}
                }, default);
            }
            return;
        }
    }
}
