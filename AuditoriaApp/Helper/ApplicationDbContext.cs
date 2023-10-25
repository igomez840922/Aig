using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AuditoriaApp_EF19.db");
            //Path.Combine(FileSystem.Current.AppDataDirectory, "AuditoriaApp_EF01.db");
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

            //JSON
            modelBuilder.Entity<APP_Inspeccion>()
.Property(e => e.Inspeccion)
.HasConversion(x => JsonConvert.SerializeObject(x, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), x => x == null ? null : JsonConvert.DeserializeObject<AUD_InspeccionTB>(x));

            //JSON
            modelBuilder.Entity<APP_Paises>()
.Property(e => e.LPaises)
.HasConversion(x => JsonConvert.SerializeObject(x, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), x => x == null ? null : JsonConvert.DeserializeObject<List<PaisTB>>(x));

            //JSON
            modelBuilder.Entity<APP_Provincias>()
.Property(e => e.LProvincias)
.HasConversion(x => JsonConvert.SerializeObject(x, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), x => x == null ? null : JsonConvert.DeserializeObject<List<ProvinciaTB>>(x));

            //JSON
            modelBuilder.Entity<APP_Corregimientos>()
.Property(e => e.LCorregimientos)
.HasConversion(x => JsonConvert.SerializeObject(x, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), x => x == null ? null : JsonConvert.DeserializeObject<List<CorregimientoTB>>(x));

            //JSON
            modelBuilder.Entity<APP_Distritos>()
.Property(e => e.LDistritos)
.HasConversion(x => JsonConvert.SerializeObject(x, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), x => x == null ? null : JsonConvert.DeserializeObject<List<DistritoTB>>(x));


            ///////////////////////////////
            ///


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<APP_Account> Account { get; set; }
        public virtual DbSet<APP_Updates> Updates { get; set; }
        public virtual DbSet<APP_Inspeccion> Inspeccion { get; set; }

        ///////////////////////////////////
        ///
        public virtual DbSet<APP_Paises> Paises { get; set; }
        public virtual DbSet<APP_Provincias> Provincias { get; set; }
        public virtual DbSet<APP_Corregimientos> Corregimientos { get; set; }
        public virtual DbSet<APP_Distritos> Distritos { get; set; }
    }

}
