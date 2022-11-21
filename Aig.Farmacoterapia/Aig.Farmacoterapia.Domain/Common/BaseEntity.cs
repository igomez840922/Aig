using Aig.Farmacoterapia.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aig.Farmacoterapia.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }
    }
}
