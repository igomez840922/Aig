using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{    
    public class NotaDestinoService : INotaDestinoService
    {
        private readonly IDalService DalService;
        public NotaDestinoService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<List<FMV_NotaDestinoTB>> FindAll(Expression<Func<FMV_NotaDestinoTB, bool>> match)
        {
            try
            {
                return DalService.FindAll(match);
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<GenericModel<FMV_NotaDestinoTB>> FindAll(GenericModel<FMV_NotaDestinoTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_NotaDestinoTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter) ))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_NotaDestinoTB>()
                               where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.Nombre.Contains(model.Filter)))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        
        public async Task<List<FMV_NotaDestinoTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_NotaDestinoTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_NotaDestinoTB> Get(long Id)
        {
            var result = DalService.Get<FMV_NotaDestinoTB>(Id);
            return result;
        }

        public async Task<FMV_NotaDestinoTB> Save(FMV_NotaDestinoTB data)
        {      
            var result = DalService.Save(data);
            if (result != null)
            {
                DalService.DBContext.Entry(result).Property(b => b.NotaClasificacion).IsModified = true;
                DalService.DBContext.Entry(result).Property(b => b.NotaContactos).IsModified = true;
                DalService.DBContext.SaveChanges();
            }

            return result;           
        }

        public async Task<FMV_NotaDestinoTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_NotaDestinoTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_NotaDestinoTB>(); }
            catch { }return 0;
        }
    }

}
