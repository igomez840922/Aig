﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Configuration
{
    public class AppConfiguration
    {
        public string ApiUrl { get; set; }
        public string ApiUsername { get; set; }
        public string ApiPassword { get; set; }
        public string BaseUrl { get; set; }
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ExpiryInMinutes { get; set; }
    }
}
