using Aig.Farmacoterapia.Domain.Interfaces;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Aig.Farmacoterapia.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        [IgnoreDataMember]
        public long Id { get; set; }
    }
}
