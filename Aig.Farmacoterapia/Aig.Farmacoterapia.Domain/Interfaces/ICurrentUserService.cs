using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces
{
    public interface ICurrentUserService : IService
    {
        string? UserId { get; }
        string? UserName { get; }
    }
}
