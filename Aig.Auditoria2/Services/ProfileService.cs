using Blazored.LocalStorage;

namespace Aig.Auditoria2.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ILocalStorageService _localStorageService;

        public ProfileService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task SetLanguage(string language)
        {
            try
            {
                await _localStorageService.SetItemAsync("language", language);
            }
            catch (Exception ex)
            { }
        }


        public async Task<string> GetLanguage()
        {
            try
            {
                var data = await _localStorageService.GetItemAsync<string>("language");
                return string.IsNullOrEmpty(data) ? "es-ES" : data; //"en-US"
			}
            catch (Exception ex)
            { }
            return "en-US";
        }

    }

}
