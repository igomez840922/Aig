using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriaApp.Helper
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(conString);
            //}

            //lazy loading
            //optionsBuilder.UseLazyLoadingProxies();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AuditoriaApp_EF00.db");
            optionsBuilder.UseSqlite(string.Format("Filename={0}", dbPath));//("Filename=YourDatabase.db");

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

           
//            //JSON
//            modelBuilder.Entity<AUD_InspeccionTB>()
//.Property(e => e.ParticipantesDNFD)
//.HasConversion(x => JsonConvert.SerializeObject(x, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), x => x == null ? null : JsonConvert.DeserializeObject<AUD_ParticipantesDNFD>(x));

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<APP_Account> Account { get; set; }
    }

}
