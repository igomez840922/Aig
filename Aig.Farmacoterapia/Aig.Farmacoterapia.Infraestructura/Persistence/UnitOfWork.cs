using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Infrastructure.Persistence.Repositories;

namespace Aig.Farmacoterapia.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly ISystemLogger _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly ApplicationDbContext _context;
        private bool disposed;
        private Hashtable _repositories;
       
        public UnitOfWork(ApplicationDbContext context, ISystemLogger logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public IRepositoryAsync<TEntity>? Repository<TEntity>() where TEntity : BaseEntity
        {
            _repositories ??= new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryAsync<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }
            return _repositories[type] as IRepositoryAsync<TEntity>;
        }

        public Task ExecuteInTransactionAsync(Func<CancellationToken, Task> operation,
            CancellationToken cancellationToken = default)
            => _context.Database.CreateExecutionStrategy().ExecuteAsync(operation, cancellationToken);

        public void ExecuteInTransaction(Func<CancellationToken, Task> operation)
            => Task.Run(async () => await ExecuteInTransactionAsync(operation));

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction ??= await _context.Database.BeginTransactionAsync(cancellationToken);
        }
        public void BeginTransaction()
        {
            Task.Run(async () => await BeginTransactionAsync());
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            var commit = false;
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                if (_transaction != null)
                    await _transaction.CommitAsync(cancellationToken);
                commit = true;
            }
            catch (Exception exc)
            {
                _logger.Error(this, exc);
                if (_transaction != null)
                    await _transaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
            return commit;
        }
        public bool Commit()
        {
            var task = Task.Run(async () => await CommitAsync());
            return task.Result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _context.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
    }

}
