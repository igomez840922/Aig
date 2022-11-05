using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;

namespace Aig.Farmacoterapia.Domain.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IRepositoryAsync<T> Repository<T>() where T : BaseEntity;
        public Task ExecuteInTransactionAsync(Func<CancellationToken, Task> operation, CancellationToken cancellationToken = default);
        public void ExecuteInTransaction(Func<CancellationToken, Task> operation);
        public Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        public void BeginTransaction();
        public Task<bool> CommitAsync(CancellationToken cancellationToken = default);
        public bool Commit();
    }
 
}
