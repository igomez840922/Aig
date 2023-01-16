using System.Net.Http.Headers;

namespace Aig.FarmacoVigilancia.Services
{
    public class ApiConnectionFileUploadService : IApiConnectionFileUploadService
    {
        private readonly IConfiguration configuration;

        public HttpClient Client { get; set; }
        public string Url { get; set; }

        public ApiConnectionFileUploadService(IConfiguration configuration)
        {
            this.configuration = configuration;
            Url = configuration["ApiFileUploadUrl"];

            Client = new HttpClient(
                        //new HttpClientHandler
                        //{
                        //    UseCookies = true,
                        //    CookieContainer = new CookieContainer()
                        //}
                        );
            Client.BaseAddress = new Uri(Url);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            //Client.DefaultRequestHeaders.Add("Basic", "ZmRvdEQ2OjQ1NE1lV2JvakpN");
        }

        public void Dispose()
        {
            try { Client.Dispose(); Client = null; }
            catch { }
        }
    }

}
