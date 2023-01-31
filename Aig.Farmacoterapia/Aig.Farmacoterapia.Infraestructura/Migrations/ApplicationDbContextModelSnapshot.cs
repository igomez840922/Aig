﻿// <auto-generated />
using System;
using Aig.Farmacoterapia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aig.Farmacoterapia.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigFabricante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(600)");

                    b.Property<long>("PaisId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Fabricante");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigFormaFarmaceutica", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormaFarmaceutica");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigMedicamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Concentracion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CondicionVenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataSheetURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Envase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Excipientes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("FabricanteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaExpiracion")
                        .HasColumnType("datetime2");

                    b.Property<long?>("FormaFarmaceuticaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumReg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumRen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Presentacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Principio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProspectusURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoEquivalencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoMedicamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ViaAdministracionId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Vigente")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId");

                    b.HasIndex("FormaFarmaceuticaId");

                    b.HasIndex("ViaAdministracionId");

                    b.ToTable("Medicamento");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigPais", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigViaAdministracion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AigViaAdministracion");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.Studies.AigEstudio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("AgenciaDistribuidora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CentroInvestigacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duracion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaAsignacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("FrecuenciaImportacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvestigadorPrincipal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicamentos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NoteNo")
                        .HasColumnType("bigint");

                    b.Property<string>("ObservacionTramitante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Participantes")
                        .HasColumnType("int");

                    b.Property<string>("Patrocinador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Placebo")
                        .HasColumnType("bit");

                    b.Property<string>("Poblacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AigEstudio");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.Studies.AigEstudioDNFD", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("AgenciaDistribuidora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CentroInvestigacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComiteBioetica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duracion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaEvaluacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvestigadorPrincipal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicamentos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotaEvaluacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObservacionTramitante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObservacionesEvaluador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Participantes")
                        .HasColumnType("int");

                    b.Property<string>("Patrocinador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poblacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistroProtocoloDIGESA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AigEstudioDNFD");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.Studies.AigEstudioEvaluador", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<long>("EstudioId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EstudioId");

                    b.HasIndex("UserId");

                    b.ToTable("AigEstudioEvaluador", (string)null);
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("bit");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Use");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("ConsumedTime");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigFabricante", b =>
                {
                    b.HasOne("Aig.Farmacoterapia.Domain.Entities.AigPais", "Pais")
                        .WithMany("Fabricantes")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigMedicamento", b =>
                {
                    b.HasOne("Aig.Farmacoterapia.Domain.Entities.AigFabricante", "Fabricante")
                        .WithMany("Medicamentos")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Aig.Farmacoterapia.Domain.Entities.AigFormaFarmaceutica", "FormaFarmaceutica")
                        .WithMany("Medicamentos")
                        .HasForeignKey("FormaFarmaceuticaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Aig.Farmacoterapia.Domain.Entities.AigViaAdministracion", "ViaAdministracion")
                        .WithMany("Medicamentos")
                        .HasForeignKey("ViaAdministracionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Fabricante");

                    b.Navigation("FormaFarmaceutica");

                    b.Navigation("ViaAdministracion");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.Studies.AigEstudio", b =>
                {
                    b.OwnsOne("Aig.Farmacoterapia.Domain.Entities.Studies.AigTramitanteEstudio", "Tramitante", b1 =>
                        {
                            b1.Property<long>("AigEstudioId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Correo")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Idoneidad")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Telefono")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AigEstudioId");

                            b1.ToTable("AigEstudio");

                            b1.WithOwner()
                                .HasForeignKey("AigEstudioId");
                        });

                    b.OwnsOne("Aig.Farmacoterapia.Domain.Entities.Studies.AigNotaEstudio", "Nota", b1 =>
                        {
                            b1.Property<long>("AigEstudioId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime?>("FechaEvaluacion")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Observaciones")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AigEstudioId");

                            b1.ToTable("AigEstudio");

                            b1.WithOwner()
                                .HasForeignKey("AigEstudioId");
                        });

                    b.Navigation("Nota")
                        .IsRequired();

                    b.Navigation("Tramitante")
                        .IsRequired();
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.Studies.AigEstudioDNFD", b =>
                {
                    b.OwnsOne("Aig.Farmacoterapia.Domain.Entities.Studies.AigTramitanteEstudio", "Tramitante", b1 =>
                        {
                            b1.Property<long>("AigEstudioDNFDId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Correo")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Idoneidad")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Nombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Telefono")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AigEstudioDNFDId");

                            b1.ToTable("AigEstudioDNFD");

                            b1.WithOwner()
                                .HasForeignKey("AigEstudioDNFDId");
                        });

                    b.Navigation("Tramitante")
                        .IsRequired();
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.Studies.AigEstudioEvaluador", b =>
                {
                    b.HasOne("Aig.Farmacoterapia.Domain.Entities.Studies.AigEstudio", null)
                        .WithMany("EstudioEvaluador")
                        .HasForeignKey("EstudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aig.Farmacoterapia.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany("EstudioEvaluador")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Aig.Farmacoterapia.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Aig.Farmacoterapia.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aig.Farmacoterapia.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Aig.Farmacoterapia.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigFabricante", b =>
                {
                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigFormaFarmaceutica", b =>
                {
                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigPais", b =>
                {
                    b.Navigation("Fabricantes");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.AigViaAdministracion", b =>
                {
                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Domain.Entities.Studies.AigEstudio", b =>
                {
                    b.Navigation("EstudioEvaluador");
                });

            modelBuilder.Entity("Aig.Farmacoterapia.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Navigation("EstudioEvaluador");
                });
#pragma warning restore 612, 618
        }
    }
}
