
using AuditoriaApp.Data;

namespace AuditoriaApp.Services
{
    public interface IQuartzSchedulerService
    {
        void Start();
        void Stop();
    }
}
