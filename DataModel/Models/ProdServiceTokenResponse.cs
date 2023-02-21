using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class ProdServiceTokenResponse
    {       

        public ProdServiceTokenResponseData data { get; set; }
        public List<string> messages { get; set; }
        public bool succeeded { get; set; }
    }

    public class ProdServiceTokenResponseData
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
        public string avatar { get; set; }
        public DateTime? tokenExpiryTime { get; set; }
    }
}
