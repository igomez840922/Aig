using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Aig.Farmacoterapia.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        [IgnoreDataMember]
        public DateTime Created { get; set; }
        [IgnoreDataMember]
        public string? CreatedBy { get; set; }
        [IgnoreDataMember]
        public DateTime? LastModified { get; set; }
        [IgnoreDataMember]
        public string? LastModifiedBy { get; set; }
    }
}
