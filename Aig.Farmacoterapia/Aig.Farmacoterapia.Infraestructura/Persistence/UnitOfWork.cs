using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Persistence.Repositories;

namespace Aig.Farmacoterapia.Infrastructure.Persistence
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    namespace BlazorHero.CleanArchitecture.Infrastructure.Repositories
    {
        public class UnitOfWork : IUnitOfWork
        {
            private readonly ApplicationDbContext _dbContext;
            private bool disposed;
            private Hashtable _repositories;

            public UnitOfWork(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            }

            public IRepositoryAsync<TEntity> Repository<TEntity>() where TEntity : BaseEntity
            {
                _repositories ??= new Hashtable();

                var type = typeof(TEntity).Name;

                if (!_repositories.ContainsKey(type))
                {
                    var repositoryType = typeof(RepositoryAsync<>);

                    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);

                    _repositories.Add(type, repositoryInstance);
                }

                return (IRepositoryAsync<TEntity>)_repositories[type];
            }

            public async Task<int> CommitAsync(CancellationToken cancellationToken=default)
            {
                return await _dbContext.SaveChangesAsync(cancellationToken);
            }

            public Task Rollback()
            {
                _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                return Task.CompletedTask;
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
                        _dbContext.Dispose();
                    }
                }
                //dispose unmanaged resources
                disposed = true;
            }
        }
    }
}
