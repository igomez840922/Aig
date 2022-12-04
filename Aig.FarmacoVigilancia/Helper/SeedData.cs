
using Aig.FarmacoVigilancia.Data;
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
using System.Threading.Tasks;

namespace Aig.FarmacoVigilancia.Helper
{
    public static class SeedData
    {        
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
                var dalService = serviceScope.ServiceProvider.GetService<IDalService>();

                //Countries
                if (dalService.Count<PaisTB>() <= 0)
                {
                    List<PaisTB> lCountries = null;
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.FarmacoVigilancia.Resources.paises.json"))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var jsonFileContent = reader.ReadToEnd();
                        lCountries = JsonConvert.DeserializeObject<List<PaisTB>>(jsonFileContent);
                    }
                    if (lCountries != null)
                    {
                        foreach (var country in lCountries)
                        {
                            dalService.Save(country);
                        }
                    }
                }

                if (dalService.Count<ProvinciaTB>() <= 0)
                {
                    PaisTB pais = dalService.Find<PaisTB>(x => x.Codigo == "PA");
                    List<Provincium> lProvincial = null;
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.FarmacoVigilancia.Resources.provincias.json"))
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
                            var provincia = new ProvinciaTB() { Nombre = prov.nombre, Codigo = prov.ced, LDistritos = new List<DistritoTB>(), Pais = pais };
                            foreach (var dist in prov.distrito)
                            {
                                var distrito = new DistritoTB() { Nombre = dist.nombre, Codigo = dist.cabecera, LCorregimientos = new List<CorregimientoTB>() };
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


                if (dalService.Count<TipoInstitucionTB>() <= 0)
                {
                    List<TipoInstitucionTB> ltipoInstitucion = new List<TipoInstitucionTB>();
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.FarmacoVigilancia.Resources.TabTipoOrganizacion.xlsx"))
                    {
                        try
                        {
                            using var wbook = new XLWorkbook(stream);
                            var ws1 = wbook.Worksheet(1);
                            for (int row = 2; row < ws1.RowCount(); row++)
                            {
                                TipoInstitucionTB lab = new TipoInstitucionTB();
                                var data = ws1.Row(row);

                                var idTemp = data.Cell(1).GetValue<int?>();
                                if (idTemp == null)
                                    break;

                                lab.Iddb = idTemp.Value;
                                lab.Nombre = data.Cell(2).GetValue<string>();
                                ltipoInstitucion.Add(lab);
                            }
                        }
                        catch { }
                    }

                    List<ProvinciaTipoOrga> lprovinciaTipoOrga = new List<ProvinciaTipoOrga>();
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.FarmacoVigilancia.Resources.TabProvinciasOrigenIF.xlsx"))
                    {
                        try
                        {
                            using var wbook = new XLWorkbook(stream);
                            var ws1 = wbook.Worksheet(1);
                            for (int row = 2; row < ws1.RowCount(); row++)
                            {
                                ProvinciaTipoOrga lab = new ProvinciaTipoOrga();
                                var data = ws1.Row(row);

                                var idTemp = data.Cell(1).GetValue<int?>();
                                if (idTemp == null)
                                    break;

                                lab.id = idTemp.Value;
                                lab.nombre = data.Cell(2).GetValue<string>();
                                lab.idTipoOrg = data.Cell(3).GetValue<int>();
                                lprovinciaTipoOrga.Add(lab);
                            }
                        }
                        catch { }
                    }

                    List<OrganizacionProvinciaTipoOrga> lorganizacionProvincia = new List<OrganizacionProvinciaTipoOrga>();
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.FarmacoVigilancia.Resources.TabInstOrg.xlsx"))
                    {
                        try
                        {
                            using var wbook = new XLWorkbook(stream);
                            var ws1 = wbook.Worksheet(1);
                            for (int row = 2; row < ws1.RowCount(); row++)
                            {
                                OrganizacionProvinciaTipoOrga lab = new OrganizacionProvinciaTipoOrga();
                                var data = ws1.Row(row);

                                var idTemp = data.Cell(1).GetValue<int?>();
                                if (idTemp == null)
                                    break;

                                lab.id = idTemp.Value;
                                lab.nombre = data.Cell(2).GetValue<string>();
                                lab.idProvinciaTipoOrga= data.Cell(3).GetValue<int>();
                                lorganizacionProvincia.Add(lab);
                            }
                        }
                        catch { }
                    }

                    PaisTB pais = dalService.Find<PaisTB>(x => x.Codigo == "PA");
                    foreach (var organizacionProvinciaArray in lorganizacionProvincia.GroupBy(x=>x.idProvinciaTipoOrga))
                    {
                        var probTipoOrg = lprovinciaTipoOrga.FirstOrDefault(x=>x.id == organizacionProvinciaArray.First().idProvinciaTipoOrga);

                        var provincia = (from prov in dalService.DBContext.Set<ProvinciaTB>()
                                         where prov.Deleted == false &&
                                         prov.Nombre == probTipoOrg.nombre
                                         select prov).FirstOrDefault();

                        if(provincia == null)
                        {
                            provincia = new ProvinciaTB() { Nombre = probTipoOrg.nombre, Codigo = "", LDistritos = new List<DistritoTB>(), Pais = pais };
                            dalService.Save(provincia);
                        }

                        foreach (var organizacionProvincia in organizacionProvinciaArray)
                        {
                            probTipoOrg = lprovinciaTipoOrga.FirstOrDefault(x => x.id == organizacionProvincia.idProvinciaTipoOrga);

                            var tipoInstitucionMain = ltipoInstitucion.FirstOrDefault(x => x.Iddb == probTipoOrg.idTipoOrg);

                            var tipoInstitucion = (from dt in dalService.DBContext.Set<TipoInstitucionTB>()
                                             where dt.Deleted == false &&
                                             dt.Nombre == tipoInstitucionMain.Nombre
                                             select dt).FirstOrDefault();
                            if (tipoInstitucion == null)
                            {
                                dalService.Save(tipoInstitucionMain);
                            }
                            else { tipoInstitucionMain = tipoInstitucion; }

                            if(!organizacionProvincia.nombre.Contains("No aplica") && !organizacionProvincia.nombre.Contains("No hay información"))
                            {
                                InstitucionDestinoTB data = new InstitucionDestinoTB() { Nombre = organizacionProvincia.nombre, Provincia = provincia, ProvinciaId = provincia.Id, TipoInstitucion = tipoInstitucionMain, TipoInstitucionId = tipoInstitucionMain.Id };
                                dalService.Save(data);
                            }
                            
                        }
                    }
                }

                //if (dalService.Count<InstitucionDestinoTB>() <= 0)
                //{
                //    InstitucionDestinoTB data = new InstitucionDestinoTB() { Nombre = "CSS" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "MINSA" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Hospitales/Patronatos/Centros Especializados" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Clínica/Hospital Privados" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Farmacias Privadas" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Industria Farmacéutica" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Dirección" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Administración" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Asesoría Legal" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "CTC" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Registro Sanitario" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Sebeq" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Modificaciones" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Control de Calidad" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Departamento de Auditoría" };
                //    dalService.Save(data);
                //    data = new InstitucionDestinoTB() { Nombre = "Centro Nacional de Farmacovigilancia" };
                //    dalService.Save(data);
                //}

                if (dalService.Count<FMV_OrigenAlertaTB>() <= 0)
                {
                    FMV_OrigenAlertaTB data = new FMV_OrigenAlertaTB() { Nombre = "EMA" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "AEMPS" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "FDA" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "HEALTH CANADA" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "MHRA" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "PMDA" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "TGA" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "INVIMA" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "COFEPRIS" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "ANVISA" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "ANMAT" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "CECMED" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "ISP" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "LABORATORIOS" };
                    dalService.Save(data);
                    data = new FMV_OrigenAlertaTB() { Nombre = "RAMs LOCALES" };
                    dalService.Save(data); 
                    data = new FMV_OrigenAlertaTB() { Nombre = "DIRECCIÓN" };
                    dalService.Save(data);
                }
                if (dalService.Count<FMV_RfvTB>() <= 0)
                {
                    List<LaboratorioTB> lLabs = new List<LaboratorioTB>();
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.FarmacoVigilancia.Resources.Empresas.xlsx"))
                    {
                        try 
                        {
                            using var wbook = new XLWorkbook(stream);
                            var ws1 = wbook.Worksheet(1);
                            for (int row = 2; row < ws1.RowCount(); row++)
                            {
                                LaboratorioTB lab = new LaboratorioTB();
                                var data = ws1.Row(row);

                                var idTemp = data.Cell(1).GetValue<int?>();
                                if (idTemp == null)
                                    break;

                                lab.IdEmpresa = idTemp.Value;
                                lab.Nombre = data.Cell(2).GetValue<string>();
                                lab.Pais = data.Cell(3).GetValue<string>();
                                lab.TipoLaboratorio = data.Cell(4).GetValue<string>().Contains("Distribuidora") ? DataModel.Helper.enum_LaboratoryType.Distributor : DataModel.Helper.enum_LaboratoryType.Laboratory;
                                lab.TipoUbicacion = data.Cell(5).GetValue<string>().Contains("Extranjera") ? DataModel.Helper.enum_UbicationType.Foreign : DataModel.Helper.enum_UbicationType.Local;
                                dalService.Save(lab);
                                lLabs.Add(lab);
                            }
                        }
                        catch { }
                                              
                    }
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aig.FarmacoVigilancia.Resources.RFV.xlsx"))
                    {
                        using var wbook = new XLWorkbook(stream);
                        var ws1 = wbook.Worksheet(1);
                        for (int row = 2; row < ws1.RowCount(); row++)
                        {
                            try {
                                FMV_RfvTB rfv = new FMV_RfvTB();
                                var data = ws1.Row(row);
                                var idTemp = data.Cell(1).GetValue<int?>();
                                if (idTemp == null)
                                    break;

                                rfv.FechaNotificacion = data.Cell(2).GetValue<DateTime?>();
                                rfv.LaboratorioId = lLabs.Where(x => x.IdEmpresa == data.Cell(3).GetValue<int>()).FirstOrDefault()?.Id ?? null;
                                rfv.Laboratorio = lLabs.Where(x => x.IdEmpresa == data.Cell(3).GetValue<int>()).FirstOrDefault() ?? null;
                                rfv.NombreCompleto = data.Cell(4).GetValue<string>();
                                rfv.Cargo = data.Cell(5).GetValue<string>();
                                rfv.DireccionFisica = data.Cell(6).GetValue<string>();
                                rfv.Telefonos = data.Cell(7).GetValue<string>();
                                rfv.Correos = data.Cell(8).GetValue<string>();
                                rfv.TipoUbicacion = data.Cell(9).GetValue<string>().Contains("Extranjero") ? DataModel.Helper.enum_UbicationType.Foreign : DataModel.Helper.enum_UbicationType.Local;
                                rfv.Observaciones = data.Cell(10).GetValue<string>();
                                dalService.Save(rfv);
                            }
                            catch { }                            
                        }
                    }
                    //LaboratorioTB lab = new LaboratorioTB() { Nombre = "Abbott" };
                    //dalService.Save(lab);
                    //lab = new LaboratorioTB() { Nombre = "Roche" };
                    //dalService.Save(lab);
                    //lab = new LaboratorioTB() { Nombre = "GSK" };
                    //dalService.Save(lab);
                    //lab = new LaboratorioTB() { Nombre = "Novartis" };
                    //dalService.Save(lab);
                }
                if (dalService.Count<LaboratorioTB>() <= 0)
                {
                    LaboratorioTB lab = new LaboratorioTB() { Nombre = "Abbott" };
                    dalService.Save(lab);
                    lab = new LaboratorioTB() { Nombre = "Roche" };
                    dalService.Save(lab);
                    lab = new LaboratorioTB() { Nombre = "GSK" };
                    dalService.Save(lab);
                    lab = new LaboratorioTB() { Nombre = "Novartis" };
                    dalService.Save(lab);
                }
                if (dalService.Count<PersonalTrabajadorTB>() <= 0)
                {
                    PersonalTrabajadorTB lab = new PersonalTrabajadorTB() { NombreCompleto = "Arelis Quintero", Evaluador = true, Registrador = true, Tramitador = true };
                    dalService.Save(lab);
                    lab = new PersonalTrabajadorTB() { NombreCompleto = "Favio Navarro", Evaluador=true, Registrador=true, Tramitador=true };
                    dalService.Save(lab);
                    lab = new PersonalTrabajadorTB() { NombreCompleto = "Idalmis Aguilar", Evaluador = true, Registrador = true, Tramitador = true };
                    dalService.Save(lab);
                    lab = new PersonalTrabajadorTB() { NombreCompleto = "Miguel Díaz" , Evaluador = true, Registrador = true, Tramitador = true };
                    dalService.Save(lab);
                }
                                

            }

        }


    }
}
