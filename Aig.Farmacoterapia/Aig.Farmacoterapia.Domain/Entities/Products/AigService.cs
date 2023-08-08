using Aig.Farmacoterapia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Products
{
    public class AigService : BaseAuditableEntity
    {
        public string Code { get; set; }
        public string Host { get; set; }
        public int? Port { get; set; }
        public bool Https { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public int UpdateTime { get; set; }
        public DateTime? LastRun { get; set; }
        public int LastRetrieved { get; set; }
    }
}