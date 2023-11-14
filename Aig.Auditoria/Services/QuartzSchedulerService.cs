using Quartz.Impl;
using Quartz;

namespace Aig.Auditoria.Services
{
    public class QuartzSchedulerService : IQuartzSchedulerService
    {
        private IScheduler scheduler;

        public QuartzSchedulerService()
        {
            scheduler = new StdSchedulerFactory().GetScheduler().GetAwaiter().GetResult();
        }

        public void Start()
        {
            if (scheduler == null || scheduler.IsShutdown)
            {
                scheduler = new StdSchedulerFactory().GetScheduler().GetAwaiter().GetResult();

                scheduler.Start().GetAwaiter().GetResult();

                // Schedule checkLicenseProcessJob
                var checkCorrespondenciaProcessJob = JobBuilder.Create<Jobs.CheckCorrespondenciaProcessJob>()
                    .WithIdentity("checkCorrespondenciaProcessJob", "group1")
                    .Build();
                var checkCorrespondenciaProcessTrigger = TriggerBuilder.Create()
                    .WithIdentity("checkCorrespondenciaProcessTrigger", "group1")
                    .StartAt(DateTime.Now.AddMinutes(2))
                    .WithSimpleSchedule(x => x
                        .WithIntervalInHours(24)
                        .RepeatForever())
                    .Build();
                scheduler.ScheduleJob(checkCorrespondenciaProcessJob, checkCorrespondenciaProcessTrigger).GetAwaiter().GetResult();

                //// Schedule scheduleProcessJob
                //var checkOneLoginProcessJob = JobBuilder.Create<Jobs.CheckOneLoginProcessJob>()
                //    .WithIdentity("checkOneLoginProcessJob", "group1")
                //    .Build();
                //var checkOneLoginProcessTrigger = TriggerBuilder.Create()
                //    .WithIdentity("checkOneLoginProcessTrigger", "group1")
                //    .StartAt(DateTime.Now.AddSeconds(10))
                //    .WithSimpleSchedule(x => x
                //        .WithIntervalInSeconds(10)
                //        .RepeatForever())
                //    .Build();
                //scheduler.ScheduleJob(checkOneLoginProcessJob, checkOneLoginProcessTrigger).GetAwaiter().GetResult();
            }
        }

        public void Stop()
        {
            scheduler.Shutdown().GetAwaiter().GetResult();
        }
    }
}
