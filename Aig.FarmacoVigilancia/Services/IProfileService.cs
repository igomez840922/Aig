namespace Aig.FarmacoVigilancia.Services
{
    public interface IProfileService
    {
        Task SetLanguage(string languaje);
        Task<string> GetLanguage();
    }
}
