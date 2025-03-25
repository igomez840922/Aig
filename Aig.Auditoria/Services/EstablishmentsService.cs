using ClosedXML.Excel;
using Dapper;
using DataAccess;
using DataModel;
using DataModel.DTO;
using DataModel.Models;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aig.Auditoria.Services
{    
    public class EstablishmentsService : IEstablishmentsService
    {
        private readonly IDalService DalService;
        public EstablishmentsService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<AUD_EstablecimientoTB>> FindAll(GenericModel<AUD_EstablecimientoTB> model)
        {
            try
            {
                
                //var dataRes = DalService.DBContext.AUD_Establecimiento.Where(d => ApplicationDbContext.JsonValue(nameof(d.Nombre), "$.PrimerNombre").Contains(model.Filter)).ToList();
                model.Ldata = null; model.Total = 0;
                                
                model.Ldata  = (from data in DalService.DBContext.Set<AUD_EstablecimientoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.NumLicencia.Contains(model.Filter) || data.Institucion.Contains(model.Filter) || data.Telefono1.Contains(model.Filter) || data.Telefono2.Contains(model.Filter) || data.Email.Contains(model.Filter)  ))//|| DataAccess.Helper.Helper.JsonValue("Regente", "NumIdoneidad") == model.Filter
                                orderby data.Nombre
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<AUD_EstablecimientoTB>()
                             where data.Deleted == false &&
                             (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) || data.NumLicencia.Contains(model.Filter) || data.Institucion.Contains(model.Filter) || data.Telefono1.Contains(model.Filter) || data.Telefono2.Contains(model.Filter) || data.Email.Contains(model.Filter) ))//|| DataAccess.Helper.Helper.JsonValue("Regente", "NumIdoneidad") == model.Filter
                               select data).Count();

                if (!string.IsNullOrEmpty(model.Filter))
                {
                    try {
                        var ldata = DalService.DBContext.AUD_Establecimiento
    .FromSqlRaw(@$"SELECT * FROM AUD_Establecimiento WHERE 
JSON_VALUE(Regente, '$.NumIdoneidad') like '%{model.Filter}%'").ToList();
                        if (ldata?.Count > 0)
                        {
                            model.Ldata = model.Ldata != null ? model.Ldata : new List<AUD_EstablecimientoTB>();
                            if (ldata.Concat(model.Ldata).Distinct().Count() > 0)
                            {
                                model.Total = ldata.Concat(model.Ldata).Distinct().Count();
                                model.Ldata.AddRange(ldata);
                                model.Ldata = model.Ldata.Distinct().ToList();
                                //model.Ldata = model.Ldata.Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();
                            }
                        }
                    }
                    catch { }
                    try
                    {
                        
    var ldata = DalService.DBContext.AUD_Establecimiento
   .FromSqlRaw(string.Format("SELECT DISTINCT t.* FROM AUD_Establecimiento as t CROSS APPLY OPENJSON(t.FarmaceuticoTablas, '$.LFarmaceuticos') WITH(NumReg NVARCHAR(MAX) '$.NumReg') AS jsonFarma WHERE jsonFarma.NumReg LIKE '%{0}%'", model.Filter)).ToList();

                        //                     var ldata = DalService.DBContext.AUD_Establecimiento
                        //.FromSqlRaw(string.Format("SELECT * FROM [AUD_Establecimiento] WHERE JSON_VALUE(FarmaceuticoTablas,'$.LFarmaceuticos[0].NumReg') LIKE '%{0}%'", model.Filter)).ToList();

                        if (ldata?.Count > 0)
                        {
                            model.Ldata = model.Ldata != null ? model.Ldata : new List<AUD_EstablecimientoTB>();
                            if (ldata.Concat(model.Ldata).Distinct().Count() > 0)
                            {
                                model.Total = ldata.Concat(model.Ldata).Distinct().Count();
                                model.Ldata.AddRange(ldata);
                                model.Ldata = model.Ldata.Distinct().ToList();
                                //model.Ldata = model.Ldata.Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();
                            }
                        }
                    }
                    catch { }

                   
                }
                
                
                //MyDbContext.JsonValue(e.ColumnaJson, "MiClave") == "MiValor")
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<List<AUD_EstablecimientoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<AUD_EstablecimientoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<AUD_EstablecimientoTB> Get(long Id)
        {
            var result = DalService.Get<AUD_EstablecimientoTB>(Id);
            return result;
        }

        public async Task<AUD_EstablecimientoTB> Save(AUD_EstablecimientoTB data)
        {
            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.FarmaceuticoTablas).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.Regente).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.RepresentanteLegal).IsModified = true;

                DalService.DBContext.SaveChanges();
            }
            return result;           
        }

        public async Task<AUD_EstablecimientoTB> Delete(long Id)
        {
            var data = DalService.Delete<AUD_EstablecimientoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<AUD_EstablecimientoTB>(); }
            catch { }return 0;
        }


        public async Task<GenericModel<FarmaceuticoEstablecimientoDto>> RptFarmaceuticos(GenericModel<FarmaceuticoEstablecimientoDto> model)
        {
            try
            {
                //var dataRes = DalService.DBContext.AUD_Establecimiento.Where(d => ApplicationDbContext.JsonValue(nameof(d.Nombre), "$.PrimerNombre").Contains(model.Filter)).ToList();
                model.Ldata = null; model.Total = 0;

                var connection = DalService.DBContext.Database.GetDbConnection();
                // Abre la conexión desde el DbContext
                ///using (var connection = DalService.DBContext.Database.GetDbConnection())
                {
                   //connection.Open();

                    try {
                        string query = null;
                        if (!string.IsNullOrEmpty(model.Filter))
                        {
                            query = @"
                        SELECT DISTINCT 
                            t.Nombre, 
                            t.NumLicencia,
                            t.TipoEstablecimiento,
                            t.Status,
                            jsonFarma.NombreCompleto, 
                            jsonFarma.NumReg, 
                            jsonFarma.Cedula, 
                            jsonFarma.Horario
                        FROM AUD_Establecimiento AS t
                        CROSS APPLY OPENJSON(t.FarmaceuticoTablas, '$.LFarmaceuticos')
                        WITH (
                            NumReg NVARCHAR(MAX) '$.NumReg',
                            NombreCompleto NVARCHAR(MAX) '$.NombreCompleto',
                            Cedula NVARCHAR(MAX) '$.Cedula',
                            Horario NVARCHAR(MAX) '$.Horario'
                        ) AS jsonFarma                            
                        WHERE jsonFarma.NumReg LIKE @Filter
                           OR jsonFarma.NombreCompleto LIKE @Filter
                           OR jsonFarma.Cedula LIKE @Filter
                        ORDER BY jsonFarma.NombreCompleto
                        OFFSET @Offset ROWS FETCH NEXT @PageAmt ROWS ONLY;";
                        }
                        else
                        {
                            query = @"
                        SELECT DISTINCT 
                            t.Nombre, 
                            t.NumLicencia,
                            t.TipoEstablecimiento,
                            t.Status,
                            jsonFarma.NombreCompleto, 
                            jsonFarma.NumReg, 
                            jsonFarma.Cedula, 
                            jsonFarma.Horario
                        FROM AUD_Establecimiento AS t
                        CROSS APPLY OPENJSON(t.FarmaceuticoTablas, '$.LFarmaceuticos')
                        WITH (
                            NumReg NVARCHAR(MAX) '$.NumReg',
                            NombreCompleto NVARCHAR(MAX) '$.NombreCompleto',
                            Cedula NVARCHAR(MAX) '$.Cedula',
                            Horario NVARCHAR(MAX) '$.Horario'
                        ) AS jsonFarma                            
                        WHERE jsonFarma.NumReg is not null
                           OR jsonFarma.NombreCompleto is not null
                           OR jsonFarma.Cedula is not null
                        ORDER BY jsonFarma.NombreCompleto
                        OFFSET @Offset ROWS FETCH NEXT @PageAmt ROWS ONLY;";
                        }
                        var parameters = new
                        {
                            Filter = "%" + model.Filter + "%",
                            Offset = model.PagIdx * model.PagAmt,
                            PageAmt = model.PagAmt
                        };

                        // La consulta devolverá una lista de objetos dinámicos (ExpandoObject)
                        var result = connection.Query<FarmaceuticoEstablecimientoDto>(query, parameters).ToList();
                        model.Ldata = result;

                        if (!string.IsNullOrEmpty(model.Filter))
                        {
                            query = @"
                        SELECT COUNT(*) 
                        FROM (
                            SELECT DISTINCT 
                            t.Nombre, 
                            t.NumLicencia,
                            t.TipoEstablecimiento,
                            t.Status,
                            jsonFarma.NombreCompleto, 
                            jsonFarma.NumReg, 
                            jsonFarma.Cedula, 
                            jsonFarma.Horario
                        FROM AUD_Establecimiento AS t
                        CROSS APPLY OPENJSON(t.FarmaceuticoTablas, '$.LFarmaceuticos')
                        WITH (
                            NumReg NVARCHAR(MAX) '$.NumReg',
                            NombreCompleto NVARCHAR(MAX) '$.NombreCompleto',
                            Cedula NVARCHAR(MAX) '$.Cedula',
                            Horario NVARCHAR(MAX) '$.Horario'
                        ) AS jsonFarma                            
                        WHERE jsonFarma.NumReg is not null
                           OR jsonFarma.NombreCompleto is not null
                           OR jsonFarma.Cedula is not null
                        ) AS CountQuery;
                    ";
                        }
                        else
                        {
                            query = @"
                        SELECT COUNT(*) 
                        FROM (
                            SELECT DISTINCT 
                            t.Nombre, 
                            t.NumLicencia,
                            t.TipoEstablecimiento,
                            t.Status,
                            jsonFarma.NombreCompleto, 
                            jsonFarma.NumReg, 
                            jsonFarma.Cedula, 
                            jsonFarma.Horario
                        FROM AUD_Establecimiento AS t
                        CROSS APPLY OPENJSON(t.FarmaceuticoTablas, '$.LFarmaceuticos')
                        WITH (
                            NumReg NVARCHAR(MAX) '$.NumReg',
                            NombreCompleto NVARCHAR(MAX) '$.NombreCompleto',
                            Cedula NVARCHAR(MAX) '$.Cedula',
                            Horario NVARCHAR(MAX) '$.Horario'
                        ) AS jsonFarma                            
                        WHERE jsonFarma.NumReg is not null
                           OR jsonFarma.NombreCompleto is not null
                           OR jsonFarma.Cedula is not null
                        ) AS CountQuery;
                    ";
                        }

                        model.Total = connection.ExecuteScalar<int>(query, parameters);
                    }
                    catch { }
                    //finally { connection.Close(); }
                }
                //MyDbContext.JsonValue(e.ColumnaJson, "MiClave") == "MiValor")
                
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<GenericModel<RegenteEstablecimientoDto>> RptRegentes(GenericModel<RegenteEstablecimientoDto> model)
        {
            try
            {
                //var dataRes = DalService.DBContext.AUD_Establecimiento.Where(d => ApplicationDbContext.JsonValue(nameof(d.Nombre), "$.PrimerNombre").Contains(model.Filter)).ToList();
                model.Ldata = null; model.Total = 0;

                var connection = DalService.DBContext.Database.GetDbConnection();
                // Abre la conexión desde el DbContext
                ///using (var connection = DalService.DBContext.Database.GetDbConnection())
                {
                    //connection.Open();

                    try
                    {
                        string query = null;
                        if (!string.IsNullOrEmpty(model.Filter))
                        {
                            query = @"
                        SELECT DISTINCT 
                            t.Nombre, 
                            t.NumLicencia,
                            t.TipoEstablecimiento,
                            t.Status,
                            JSON_VALUE(Regente, '$.PrimerNombre') AS PrimerNombre,
                            JSON_VALUE(Regente, '$.SegundoNombre') AS SegundoNombre,
                            JSON_VALUE(Regente, '$.PrimerApellido') AS PrimerApellido,
                            JSON_VALUE(Regente, '$.SegundoApellido') AS SegundoApellido,
                            JSON_VALUE(Regente, '$.Identificacion') AS Identificacion,
                            JSON_VALUE(Regente, '$.Observaciones') AS Observaciones,
                            JSON_VALUE(Regente, '$.NumIdoneidad') AS NumIdoneidad
                        FROM AUD_Establecimiento AS t
                        WHERE JSON_VALUE(Regente, '$.PrimerNombre') LIKE @Filter
                            OR JSON_VALUE(Regente, '$.SegundoNombre') LIKE @Filter
                            OR JSON_VALUE(Regente, '$.PrimerApellido') LIKE @Filter
                            OR JSON_VALUE(Regente, '$.SegundoApellido') LIKE @Filter
                            OR JSON_VALUE(Regente, '$.Identificacion') LIKE @Filter
                            OR JSON_VALUE(Regente, '$.NumIdoneidad') LIKE @Filter
                        ORDER BY PrimerNombre
                        OFFSET @Offset ROWS FETCH NEXT @PageAmt ROWS ONLY;";
                        }
                        else
                        {
                            query = @"
                        SELECT DISTINCT 
                            t.Nombre, 
                            t.NumLicencia,
                            t.TipoEstablecimiento,
                            t.Status,
                            JSON_VALUE(Regente, '$.PrimerNombre') AS PrimerNombre,
                            JSON_VALUE(Regente, '$.SegundoNombre') AS SegundoNombre,
                            JSON_VALUE(Regente, '$.PrimerApellido') AS PrimerApellido,
                            JSON_VALUE(Regente, '$.SegundoApellido') AS SegundoApellido,
                            JSON_VALUE(Regente, '$.Identificacion') AS Identificacion,
                            JSON_VALUE(Regente, '$.Observaciones') AS Observaciones,
                            JSON_VALUE(Regente, '$.NumIdoneidad') AS NumIdoneidad
                        FROM AUD_Establecimiento AS t
                         WHERE JSON_VALUE(Regente, '$.PrimerNombre') is not null
                            OR JSON_VALUE(Regente, '$.SegundoNombre') is not null
                            OR JSON_VALUE(Regente, '$.PrimerApellido') is not null
                            OR JSON_VALUE(Regente, '$.SegundoApellido') is not null
                            OR JSON_VALUE(Regente, '$.Identificacion') is not null
                            OR JSON_VALUE(Regente, '$.NumIdoneidad') is not null
                        ORDER BY PrimerNombre
                        OFFSET @Offset ROWS FETCH NEXT @PageAmt ROWS ONLY;";
                        }
                        var parameters = new
                        {
                            Filter = "%" + model.Filter + "%",
                            Offset = model.PagIdx * model.PagAmt,
                            PageAmt = model.PagAmt
                        };

                        // La consulta devolverá una lista de objetos dinámicos (ExpandoObject)
                        var result = connection.Query<RegenteEstablecimientoDto>(query, parameters).ToList();
                        model.Ldata = result;

                        if (!string.IsNullOrEmpty(model.Filter))
                        {
                            query = @"
                        SELECT COUNT(*) 
                        FROM (
                            SELECT DISTINCT 
                            t.Nombre, 
                            t.NumLicencia,
                            t.TipoEstablecimiento,
                            t.Status,
                            JSON_VALUE(Regente, '$.PrimerNombre') AS PrimerNombre,
                            JSON_VALUE(Regente, '$.SegundoNombre') AS SegundoNombre,
                            JSON_VALUE(Regente, '$.PrimerApellido') AS PrimerApellido,
                            JSON_VALUE(Regente, '$.SegundoApellido') AS SegundoApellido,
                            JSON_VALUE(Regente, '$.Identificacion') AS Identificacion,
                            JSON_VALUE(Regente, '$.Observaciones') AS Observaciones,
                            JSON_VALUE(Regente, '$.NumIdoneidad') AS NumIdoneidad
                        FROM AUD_Establecimiento AS t
                        WHERE JSON_VALUE(Regente, '$.PrimerNombre') LIKE @Filter
                            OR JSON_VALUE(Regente, '$.SegundoNombre') LIKE @Filter
                            OR JSON_VALUE(Regente, '$.PrimerApellido') LIKE @Filter
                            OR JSON_VALUE(Regente, '$.SegundoApellido') LIKE @Filter
                            OR JSON_VALUE(Regente, '$.Identificacion') LIKE @Filter
                            OR JSON_VALUE(Regente, '$.NumIdoneidad') LIKE @Filter
                        ) AS CountQuery;
                    ";
                        }
                        else
                        {
                            query = @"
                        SELECT COUNT(*) 
                        FROM (
                            SELECT DISTINCT 
                            t.Nombre, 
                            t.NumLicencia,
                            t.TipoEstablecimiento,
                            t.Status,
                            JSON_VALUE(Regente, '$.PrimerNombre') AS PrimerNombre,
                            JSON_VALUE(Regente, '$.SegundoNombre') AS SegundoNombre,
                            JSON_VALUE(Regente, '$.PrimerApellido') AS PrimerApellido,
                            JSON_VALUE(Regente, '$.SegundoApellido') AS SegundoApellido,
                            JSON_VALUE(Regente, '$.Identificacion') AS Identificacion,
                            JSON_VALUE(Regente, '$.Observaciones') AS Observaciones,
                            JSON_VALUE(Regente, '$.NumIdoneidad') AS NumIdoneidad
                        FROM AUD_Establecimiento AS t
                         WHERE JSON_VALUE(Regente, '$.PrimerNombre') is not null
                            OR JSON_VALUE(Regente, '$.SegundoNombre') is not null
                            OR JSON_VALUE(Regente, '$.PrimerApellido') is not null
                            OR JSON_VALUE(Regente, '$.SegundoApellido') is not null
                            OR JSON_VALUE(Regente, '$.Identificacion') is not null
                            OR JSON_VALUE(Regente, '$.NumIdoneidad') is not null
                        ) AS CountQuery;
                    ";
                        }

                        model.Total = connection.ExecuteScalar<int>(query, parameters);
                    }
                    catch { }
                    //finally { connection.Close(); }
                }
                //MyDbContext.JsonValue(e.ColumnaJson, "MiClave") == "MiValor")

            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> RptFarmaceuticosExportToExcel(GenericModel<FarmaceuticoEstablecimientoDto> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;
                model = await RptFarmaceuticos(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "RptFarmaceuticos".ToUpper();
                    wb.Properties.Title = "RptFarmaceuticos".ToUpper();
                    wb.Properties.Subject = "RptFarmaceuticos".ToUpper();

                    var ws = wb.Worksheets.Add("RptFarmaceuticos".ToUpper());

                    ws.Cell(1, 1).Value = "Farmaceutico";
                    ws.Cell(1, 2).Value = "Identificación";
                    ws.Cell(1, 3).Value = "Num. Registro";
                    ws.Cell(1, 4).Value = "Horario";
                    ws.Cell(1, 5).Value = "Establecimiento";
                    ws.Cell(1, 6).Value = "Num. Licencia";
                    ws.Cell(1, 7).Value = "Tipo de Establecimiento";
                    ws.Cell(1, 8).Value = "Estado";

                    var row = 1;
                    foreach (var data in model.Ldata)
                    {                        
                        ws.Cell(row + 1, 1).Value = data.NombreCompleto;
                        ws.Cell(row + 1, 2).Value = data.Cedula;
                        ws.Cell(row + 1, 3).Value = data.NumReg;
                        ws.Cell(row + 1, 4).Value = data.Horario;
                        ws.Cell(row + 1, 5).Value = data.Nombre;
                        ws.Cell(row + 1, 6).Value = data.NumLicencia;
                        ws.Cell(row + 1, 7).Value = DataModel.Helper.Helper.GetDescription(data.TipoEstablecimiento);
                        ws.Cell(row + 1, 8).Value = DataModel.Helper.Helper.GetDescription(data.Status);

                        row++;
                    }

                    MemoryStream XLSStream = new();
                    wb.SaveAs(XLSStream);

                    return XLSStream;
                }
            }
            catch (Exception ex)
            { }

            return null;
        }
        public async Task<Stream> RptRegentesExportToExcel(GenericModel<RegenteEstablecimientoDto> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;
                model = await RptRegentes(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "RptRegentes".ToUpper();
                    wb.Properties.Title = "RptRegentes".ToUpper();
                    wb.Properties.Subject = "RptRegentes".ToUpper();

                    var ws = wb.Worksheets.Add("RptRegentes".ToUpper());

                    ws.Cell(1, 1).Value = "Regente";
                    ws.Cell(1, 2).Value = "Identificación";
                    ws.Cell(1, 3).Value = "Num. Idoneidad";
                    ws.Cell(1, 4).Value = "Observaciones";
                    ws.Cell(1, 5).Value = "Establecimiento";
                    ws.Cell(1, 6).Value = "Num. Licencia";
                    ws.Cell(1, 7).Value = "Tipo de Establecimiento";
                    ws.Cell(1, 8).Value = "Estado";

                    var row = 1;
                    foreach (var data in model.Ldata)
                    {
                        ws.Cell(row + 1, 1).Value = data.NombreCompleto;
                        ws.Cell(row + 1, 2).Value = data.Identificacion;
                        ws.Cell(row + 1, 3).Value = data.NumIdoneidad;
                        ws.Cell(row + 1, 4).Value = data.Observaciones;
                        ws.Cell(row + 1, 5).Value = data.Nombre;
                        ws.Cell(row + 1, 6).Value = data.NumLicencia;
                        ws.Cell(row + 1, 7).Value = DataModel.Helper.Helper.GetDescription(data.TipoEstablecimiento);
                        ws.Cell(row + 1, 8).Value = DataModel.Helper.Helper.GetDescription(data.Status);

                        row++;
                    }

                    MemoryStream XLSStream = new();
                    wb.SaveAs(XLSStream);

                    return XLSStream;
                }
            }
            catch (Exception ex)
            { }

            return null;
        }

    }

}
