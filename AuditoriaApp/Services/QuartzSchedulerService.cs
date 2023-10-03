
using AuditoriaApp.Data;
using Quartz.Impl;
using Quartz;
using SQLite;

namespace AuditoriaApp.Services
{
    public class QuartzSchedulerService: IQuartzSchedulerService
    {
        private IScheduler scheduler;

        public QuartzSchedulerService()
        {
            //scheduler = new StdSchedulerFactory().GetScheduler().GetAwaiter().GetResult();
        }

        public void Start()
        {
            if(scheduler == null || scheduler.IsShutdown)
            { 
                scheduler = new StdSchedulerFactory().GetScheduler().GetAwaiter().GetResult();

                scheduler.Start().GetAwaiter().GetResult();

                // Schedule checkLicenseProcessJob
                var checkLicenseProcessJob = JobBuilder.Create<Jobs.CheckLicenseProcessJob>()
                    .WithIdentity("checkLicenseProcessJob", "group1")
                    .Build();
                var checkLicenseProcessTrigger = TriggerBuilder.Create()
                    .WithIdentity("checkLicenseProcessTrigger", "group1")
                    .StartAt(DateTime.Now.AddSeconds(10))
                    .WithSimpleSchedule(x => x
                        .WithIntervalInHours(1)
                        .RepeatForever())
                    .Build();
                scheduler.ScheduleJob(checkLicenseProcessJob, checkLicenseProcessTrigger).GetAwaiter().GetResult();

                // Schedule scheduleProcessJob
                var checkOneLoginProcessJob = JobBuilder.Create<Jobs.CheckOneLoginProcessJob>()
                    .WithIdentity("checkOneLoginProcessJob", "group1")
                    .Build();
                var checkOneLoginProcessTrigger = TriggerBuilder.Create()
                    .WithIdentity("checkOneLoginProcessTrigger", "group1")
                    .StartAt(DateTime.Now.AddSeconds(10))
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(10)
                        .RepeatForever())
                    .Build();
                scheduler.ScheduleJob(checkOneLoginProcessJob, checkOneLoginProcessTrigger).GetAwaiter().GetResult();
            }   
        }

        public void Stop()
        {
            scheduler.Shutdown().GetAwaiter().GetResult();
        }
    }
}
