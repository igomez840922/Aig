using System.Reflection;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Aig.Farmacoterapia.Infrastructure.Persistence
{

    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly ICurrentUserService _currentUserService;
        public DbSet<AigMedicamento> Medicamento { get; set; }
        public DbSet<AigFormaFarmaceutica> FormaFarmaceutica { get; set; }
        public DbSet<AigFabricante> Fabricante { get; set; }
        public DbSet<AigPais> Pais { get; set; }
        public DbSet<AigEstudioDNFD> AigEstudioDNFD { get; set; }
        public DbSet<AigEstudio> AigEstudio { get; set; }
        public ApplicationDbContext(ICurrentUserService currentUserService, DbContextOptions options,IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }
 
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = _currentUserService.UserName;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = _currentUserService.UserName;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.HasDefaultSchema("aigmeddb");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }

}