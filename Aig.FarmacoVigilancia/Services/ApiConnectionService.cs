using System.Net.Http.Headers;

namespace Aig.FarmacoVigilancia.Services
{
    public class ApiConnectionService : IApiConnectionService
    {
        private readonly IConfiguration configuration;

        public HttpClient Client { get; set; }
        public string Url { get; set; }

        public ApiConnectionService(IConfiguration configuration)
        {
            this.configuration = configuration;
            Url = configuration["ApiUrl"];

            var httpClienthandler = new HttpClientHandler();
            httpClienthandler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, errors) =>{return true;};            
            Client = new HttpClient(httpClienthandler) { Timeout = TimeSpan.FromSeconds(30) };
            Client.BaseAddress = new Uri(Url);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            //Client.DefaultRequestHeaders.Add("Basic", "ZmRvdEQ2OjQ1NE1lV2JvakpN");
        }

        public void UpdateUrlBase(string url)
        {
            Client.BaseAddress = new Uri(url);
        }

        public void Dispose()
        {
            try { Client.Dispose(); Client = null; }
            catch { }
        }
    }

}
