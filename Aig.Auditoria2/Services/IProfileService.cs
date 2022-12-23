namespace Aig.Auditoria2.Services
{
    public interface IProfileService
    {
        Task SetLanguage(string languaje);
        Task<string> GetLanguage();
    }
}
