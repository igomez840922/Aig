namespace AuditoriaApp.Services
{
    public interface IApiConnectionService
    {
        HttpClient Client { get; set; }
        void Dispose();
    }
}
