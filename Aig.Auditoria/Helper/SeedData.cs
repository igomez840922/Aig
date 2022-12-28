using Aig.Auditoria.Data;
using Aig.Auditoria.Pages.Settings.Country;
using Aig.Auditoria.Services;
using ClosedXML.Excel;
using DataAccess;
using DataAccess;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Duende.IdentityServer.Models.IdentityResources;

namespace Aig.Auditoria.Helper
{
    public static class SeedData
    {
        public static async Task SeedAll(IServiceProvider serviceProvider)
        {
            await Aig.Auditoria.Helper.SeedData.UpdateMigrations(serviceProvider);
            await Aig.Auditoria.Helper.SeedData.SeedRoles(serviceProvider);
            await Aig.Auditoria.Helper.SeedData.SeedUsers(serviceProvider);
            await Aig.Auditoria.Helper.SeedData.SeedFirstData(serviceProvider);
        }

        public static async Task UpdateMigrations(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    await dbContext.Database.MigrateAsync();
                }
            }
        }

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                foreach (enumUserRoleType dt in Enum.GetValues(typeof(enumUserRoleType)))
                {
                    var roleName = DataModel.Helper.Helper.GetDescription<enumUserRoleType>(dt);
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }                
            }
        }

        public static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                if (userManager.FindByNameAsync("admin").Result == null)
                {
                    ApplicationUser user = new ApplicationUser() { UserProfile = new UserProfileTB() { Languanje = "en-US" } };
                    user.UserRoleType = enumUserRoleType.Admin;
                    user.UserProfile.FirstName = "admin";
                    user.UserProfile.SecondName = "admin";
                    user.UserProfile.SureName = "admin";
                    user.UserProfile.SecondSurName = "admin";
                    user.UserName = "admin";
                    user.Email = "admin@admin.com";
                    user.PhoneNumber = "3055525252";
                    user.EmailConfirmed = true;
                    user.LockoutEnabled = false;
                    user.PhoneNumberConfirmed = true;
                    user.TwoFactorEnabled = false;

                    IdentityResult result = await userManager.CreateAsync(user, "admin");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, DataModel.Helper.Helper.GetDescription<enumUserRoleType>(enumUserRoleType.Admin));
                    }
                }
            }
        }

        public static async Task SeedFirstData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var countryService = serviceScope.ServiceProvider.GetService<ICountriesService>();
                var inspeccionService = serviceScope.ServiceProvider.GetService<IInspectionsService>();
                var dalService = serviceScope.ServiceProvider.GetService<IDalService>();

                //Countries
                if (await countryService.Count() <= 0)
                {
                    List<PaisTB> lCountries = null;
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.Auditoria.Resources.paises.json"))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var jsonFileContent = reader.ReadToEnd();
                        lCountries = JsonConvert.DeserializeObject<List<PaisTB>>(jsonFileContent);
                    }
                    if (lCountries != null)
                    {
                        foreach (var country in lCountries)
                        {
                            await countryService.Save(country);
                        }
                    }
                }

                if (dalService.Count<ProvinciaTB>() <= 0)
                {
                    PaisTB pais = dalService.Find<PaisTB>(x=>x.Codigo=="PA");
                    List<Provincium> lProvincial = null;
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.Auditoria.Resources.provincias.json"))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var jsonFileContent = reader.ReadToEnd();
                        var mainProv = JsonConvert.DeserializeObject<MainProvincias>(jsonFileContent);
                        lProvincial = mainProv.provincia;
                    }
                    if (lProvincial != null)
                    {
                        foreach (var prov in lProvincial)
                        {
                            //await countryService.Save(prov);
                            var provincia = new ProvinciaTB() { Nombre = prov.nombre, Codigo=prov.ced,LDistritos=new List<DistritoTB>(), Pais= pais };
                            foreach (var dist in prov.distrito)
                            {
                                var distrito = new DistritoTB() { Nombre = dist.nombre, Codigo = dist.cabecera,LCorregimientos=new List<CorregimientoTB>() };
                                provincia.LDistritos.Add(distrito);
                                foreach (var corr in dist.corregimientos)
                                {
                                    var corregimiento = new CorregimientoTB() { Nombre = corr, Codigo = corr };
                                    distrito.LCorregimientos.Add(corregimiento);
                                }
                            }
                            dalService.Save(provincia);
                        }
                    }
                }

                if (dalService.Count<ActividadEstablecimientoTB>() <= 0)
                {
                    var ldata = new List<ActividadEstablecimientoTB>() { new ActividadEstablecimientoTB() {Nombre= "Importación" }, new ActividadEstablecimientoTB() { Nombre = "Exportación" }, new ActividadEstablecimientoTB() { Nombre = "Reexportación" }, new ActividadEstablecimientoTB() { Nombre = "Almacenamiento" }, new ActividadEstablecimientoTB() { Nombre = "Distribución" }, new ActividadEstablecimientoTB() { Nombre = "Transporte" }, new ActividadEstablecimientoTB() { Nombre = "Comercialización al por mayor de materia prima para la industria farmacéutica" } };
                    foreach (var data in ldata)
                    {
                        dalService.Save(data);
                    }
                }

                if (dalService.Count<ProductoEstablecimientoTB>() <= 0)
                {
                    var ldata = new List<ProductoEstablecimientoTB>() { new ProductoEstablecimientoTB() { Nombre = "Materia prima para la industria farmacéutica" }, new ProductoEstablecimientoTB() { Nombre = "Medicamentos" }, new ProductoEstablecimientoTB() { Nombre = "Suplementos vitamínicos con propiedad terapéutica" }, new ProductoEstablecimientoTB() { Nombre = "Cosméticos" }, new ProductoEstablecimientoTB() { Nombre = "Plaguicidas de uso doméstico" }, new ProductoEstablecimientoTB() { Nombre = "Desinfectantes de uso doméstico y hospitalario" }};
                    foreach (var data in ldata)
                    {
                        dalService.Save(data);
                    }
                }

                if (dalService.Count<AUD_EstablecimientoTB>() <= 0)
                {
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.Auditoria.Resources.Establecimientos.xlsx"))
                    {
                        try
                        {
                            using var wbook = new XLWorkbook(stream);
                            var ws1 = wbook.Worksheet(1);
                            var count = ws1.RowCount();
                            for (int row = 2; row < count; row++)
                            {
                                AUD_EstablecimientoTB estab = new AUD_EstablecimientoTB();
                                var data = ws1.Row(row);

                                estab.NumLicencia = data.Cell(1).GetValue<string>();
                                estab.Nombre = data.Cell(3).GetValue<string>();

                                if(!string.IsNullOrEmpty(estab.Nombre) && !string.IsNullOrEmpty(estab.NumLicencia))
                                {
                                    estab.Periodo = data.Cell(2).GetValue<int?>();
                                    estab.Ubicacion = data.Cell(4).GetValue<string>();
                                    estab.RepLegalNombre = data.Cell(5).GetValue<string>();
                                    estab.NombreSociedad = data.Cell(6).GetValue<string>();
                                    switch(data.Cell(7).GetValue<string>())//Tipo Establecimiento
                                    {
                                        case "AGENCIA":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.A;
                                                break;
                                            }
                                        case "BOTIQU═N DE PUEBLO":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.B;
                                                break;
                                            }
                                        case "DROGUER═A":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.D;
                                                break;
                                            }
                                        case "ESTABLECIMIENTO NO FARMAC+UTICO":
                                        case "ESTABLECIMIENTO NO FARMAC╔UTICO":
                                        case "ESTABLECIMIENTO NO FARMACEUTICO":
                                        case "ESTABLECIMIENTO NO FARMACÉUTICO":
                                        case "NO FARMAC╔UTICO":
                                        case "NO FARMAC+UTICO":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.ENF;
                                                break;
                                            }
                                        case "FARMACIA":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.F;
                                                break;
                                            }
                                        case "LABORATORIO":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.LF;
                                                break;
                                            }
                                    }
                                    estab.HorariosEstablecimiento = data.Cell(12).GetValue<string>();
                                    estab.FechaExpedida = data.Cell(19).GetValue<DateTime?>();
                                    estab.FechaExpiracion = data.Cell(20).GetValue<DateTime?>();
                                    switch (data.Cell(26).GetValue<string>()) //Clasificacion
                                    {
                                        case "APERTURA":
                                            {
                                                estab.Clasificacion = DataModel.Helper.enumAUD_ClasifEstablecimiento.Apertura;
                                                break;
                                            }
                                        case "MODIF.":
                                            {
                                                estab.Clasificacion = DataModel.Helper.enumAUD_ClasifEstablecimiento.Modificacion;
                                                break;
                                            }
                                        case "RENOVACIËN":
                                            {
                                                estab.Clasificacion = DataModel.Helper.enumAUD_ClasifEstablecimiento.Renovacion;
                                                break;
                                            }
                                    }
                                    switch (data.Cell(27).GetValue<string>()) //Sector
                                    {
                                        case "ESTATAL":
                                            {
                                                estab.Sector = DataModel.Helper.enumAUD_TipoSector.Estatal;
                                                break;
                                            }
                                        case "PRIVADO":
                                            {
                                                estab.Sector = DataModel.Helper.enumAUD_TipoSector.Privado;
                                                break;
                                            }
                                    }
                                    switch (data.Cell(28).GetValue<string>()) //Estatus
                                    {
                                        case "CANCELADA":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Cancelado;
                                                break;
                                            }
                                        case "CERRADO":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Cancelado;
                                                break;
                                            }
                                        case "Cierre T.":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.CerradoTemp;
                                                break;
                                            }
                                        case "INACTIVO":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Inactivo;
                                                break;
                                            }
                                        case "OPERANDO":
                                        case "vOPERANDO":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Operando;
                                                break;
                                            }
                                        case "RESOLUCIËN":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Resolucion;
                                                break;
                                            }
                                        case "VENCIDA":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Vencido;
                                                break;
                                            }
                                    }
                                    estab.Email = data.Cell(47).GetValue<string>();
                                    if (!string.IsNullOrEmpty(estab.Email))
                                    {
                                        if (!Regex.IsMatch(estab.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                                            estab.Email = null;
                                    }
                                    else { estab.Email = null; }

                                    dalService.Save(estab);
                                }
                            }
                        }
                        catch { }

                    }

                }
                else //esto es para actualizar
                {
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.Auditoria.Resources.Establecimientos.xlsx"))
                    {
                        try
                        {
                            using var wbook = new XLWorkbook(stream);
                            var ws1 = wbook.Worksheet(1);
                            var count = ws1.RowCount();
                            for (int row = 2; row < count; row++)
                            {
                                AUD_EstablecimientoTB estab = new AUD_EstablecimientoTB();
                                var data = ws1.Row(row);

                                estab.NumLicencia = data.Cell(1).GetValue<string>();
                                estab.Nombre = data.Cell(3).GetValue<string>();

                                if (!string.IsNullOrEmpty(estab.Nombre) && !string.IsNullOrEmpty(estab.NumLicencia))
                                {
                                    estab.Periodo = data.Cell(2).GetValue<int?>();
                                    estab.Ubicacion = data.Cell(4).GetValue<string>();
                                    estab.RepLegalNombre = data.Cell(5).GetValue<string>();
                                    estab.NombreSociedad = data.Cell(6).GetValue<string>();
                                    switch (data.Cell(7).GetValue<string>())//Tipo Establecimiento
                                    {
                                        case "AGENCIA":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.A;
                                                break;
                                            }
                                        case "BOTIQU═N DE PUEBLO":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.B;
                                                break;
                                            }
                                        case "DROGUER═A":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.D;
                                                break;
                                            }
                                        case "ESTABLECIMIENTO NO FARMAC+UTICO":
                                        case "ESTABLECIMIENTO NO FARMAC╔UTICO":
                                        case "ESTABLECIMIENTO NO FARMACEUTICO":
                                        case "ESTABLECIMIENTO NO FARMACÉUTICO":
                                        case "NO FARMAC╔UTICO":
                                        case "NO FARMAC+UTICO":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.ENF;
                                                break;
                                            }
                                        case "FARMACIA":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.F;
                                                break;
                                            }
                                        case "LABORATORIO":
                                            {
                                                estab.TipoEstablecimiento = DataModel.Helper.enumAUD_TipoEstablecimiento.LF;
                                                break;
                                            }
                                    }
                                    estab.HorariosEstablecimiento = data.Cell(12).GetValue<string>();
                                    estab.FechaExpedida = data.Cell(19).GetValue<DateTime?>();
                                    estab.FechaExpiracion = data.Cell(20).GetValue<DateTime?>();
                                    switch (data.Cell(26).GetValue<string>()) //Clasificacion
                                    {
                                        case "APERTURA":
                                            {
                                                estab.Clasificacion = DataModel.Helper.enumAUD_ClasifEstablecimiento.Apertura;
                                                break;
                                            }
                                        case "MODIF.":
                                            {
                                                estab.Clasificacion = DataModel.Helper.enumAUD_ClasifEstablecimiento.Modificacion;
                                                break;
                                            }
                                        case "RENOVACIËN":
                                            {
                                                estab.Clasificacion = DataModel.Helper.enumAUD_ClasifEstablecimiento.Renovacion;
                                                break;
                                            }
                                    }
                                    switch (data.Cell(27).GetValue<string>()) //Sector
                                    {
                                        case "ESTATAL":
                                            {
                                                estab.Sector = DataModel.Helper.enumAUD_TipoSector.Estatal;
                                                break;
                                            }
                                        case "PRIVADO":
                                            {
                                                estab.Sector = DataModel.Helper.enumAUD_TipoSector.Privado;
                                                break;
                                            }
                                    }
                                    switch (data.Cell(28).GetValue<string>()) //Estatus
                                    {
                                        case "CANCELADA":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Cancelado;
                                                break;
                                            }
                                        case "CERRADO":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Cancelado;
                                                break;
                                            }
                                        case "Cierre T.":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.CerradoTemp;
                                                break;
                                            }
                                        case "INACTIVO":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Inactivo;
                                                break;
                                            }
                                        case "OPERANDO":
                                        case "vOPERANDO":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Operando;
                                                break;
                                            }
                                        case "RESOLUCIËN":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Resolucion;
                                                break;
                                            }
                                        case "VENCIDA":
                                            {
                                                estab.Status = DataModel.Helper.enumAUD_StatusEstablecimiento.Vencido;
                                                break;
                                            }
                                    }
                                    estab.Email = data.Cell(47).GetValue<string>();
                                    if (!string.IsNullOrEmpty(estab.Email))
                                    {
                                        if (!Regex.IsMatch(estab.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                                            estab.Email = null;
                                    }
                                    else { estab.Email = null; }

                                    var tmpEstab = dalService.Find<AUD_EstablecimientoTB>(x => x.NumLicencia == estab.NumLicencia);

                                    estab.Id = tmpEstab?.Id ?? estab.Id;

                                    dalService.Save(estab);
                                }
                            }
                        }
                        catch { }

                    }

                }


            }
        }


    }
}
