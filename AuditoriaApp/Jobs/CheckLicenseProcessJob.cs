using BlazorComponentBus;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriaApp.Jobs
{
    
    [DisallowConcurrentExecution]
    public class CheckLicenseProcessJob : IJob
    {
        //private readonly ICameraProcessService cameraProcessService;
        //private readonly IDalService dalService;
        //public TramitesProcessJob(IDalService dalService) //ICameraProcessService cameraProcessService, 
        //{
        //    //this.cameraProcessService = cameraProcessService;
        //    this.dalService = dalService;
        //}
        public async Task Execute(IJobExecutionContext context)
        {
            await StartProcess();

            //return Task.CompletedTask;
        }


        private async Task StartProcess()
        {
            try
            {
                // Now you can use the serviceProvider to retrieve any registered services.
                // For example:
                //var bus = MauiProgram.serviceProvider.GetService<ComponentBus>();
                //await bus.Publish(new AuditoriaApp.Events.LoginProcess.CheckLoginEvent { Check = true });

            }
            catch (Exception ex)
            { }
        }

    }

}
