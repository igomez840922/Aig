using Aig.Farmacoterapia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Interfaces
{
    public interface ICurrentUserService : IService
    {
        string? UserId { get; }
        string? UserName { get; }
    }
}
