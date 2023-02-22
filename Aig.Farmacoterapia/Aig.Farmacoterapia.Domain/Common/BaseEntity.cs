using Aig.Farmacoterapia.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Aig.Farmacoterapia.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        [IgnoreDataMember]
        public long Id { get; set; }
    }
}
