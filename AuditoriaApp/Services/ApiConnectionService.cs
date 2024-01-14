using System.Net.Http.Headers;
using System.Net;
using System;
using Microsoft.Extensions.Configuration;
using System.Security.Policy;

namespace AuditoriaApp.Services
{
    public class ApiConnectionService: IApiConnectionService
    {
        private readonly IConfiguration configuration;

        public HttpClient Client { get; set; }
        public string Url { get; set; }
        
        public ApiConnectionService(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.configuration = configuration;
            Url = configuration["ApiUrl"];
            //Url = string.Format("{0}/api/", configuration["ApiUrl"]);

            var httpClienthandler = new HttpClientHandler();
            httpClienthandler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) => { return true; };
            Client = new HttpClient(httpClienthandler) { Timeout = TimeSpan.FromMinutes(5) };
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
