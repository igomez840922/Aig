namespace Aig.Auditoria2.Services
{
    public interface IApiConnectionService
    {
        HttpClient Client { get; set; }
        void Dispose();
    }
}
