using DataModel;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{    
    //ApiAuthorizationDbContext IdentityDbContext
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(conString);
            //}

            //lazy loading
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasMany(e => e.LPosSystems)
            //    .WithOne(e => e.User)
            //    .HasForeignKey(e => e.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
                      
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasOne(s => s.UserProfile)
            //    .WithOne(ad => ad.AppUser);

            //modelBuilder.Entity<PurchaseOrderProduct>()
            //    .HasOne(e => e.Product)
            //    .WithOne()
            //    .HasForeignKey<PurchaseOrderProduct>(e => e.ProductId);



            base.OnModelCreating(modelBuilder);
        }

       
        //public virtual DbSet<PosSystemTB> PosSystem { get; set; }
        public virtual DbSet<UserProfileTB> UserProfile { get; set; }



    }
}
