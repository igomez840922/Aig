using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;

namespace Aig.Farmacoterapia.Domain.Interfaces
{
   public interface IUnitOfWork : IDisposable
    {
        IRepositoryAsync<T> Repository<T>() where T : BaseEntity;

        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        Task Rollback();
    }
}
