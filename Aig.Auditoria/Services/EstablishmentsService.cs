using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.SignalR;
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
    }

}
