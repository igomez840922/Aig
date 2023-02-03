using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aig.FarmacoVigilancia.Services
{    
    public class DashboardService : IDashboardService
    {
        private readonly IDalService DalService;
        public DashboardService(IDalService dalService)
        {
            DalService = dalService;
        }

        
        //REPORTES

        //Tipo de Vacuna
        public async Task<ReportModel<ReportModelResponse>> ReportEsavy(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by 
                               new
                               {
                                   Year = data.FechaRecibidoCNFV.Value.Year,
                                   Month = data.FechaRecibidoCNFV.Value.Month,
                               } into g
                               select new ReportModelResponse
                               {
                                   Name = string.Format("{0}/{1}", g.Key.Month, g.Key.Year),
                                   DateResult = new DateTime(g.Key.Year, g.Key.Month,1),
                                   Count = g.Count()
                               }).ToList().OrderBy(x => x.DateResult).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Esavi2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecibidoCNFV.Value.Year,
                                   Month = data.FechaRecibidoCNFV.Value.Month
                               } into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //ESAVI
        public async Task<ReportModel<ReportModelResponse>> ReportRam(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecibidoCNFV.Value.Year,
                                   Month = data.FechaRecibidoCNFV.Value.Month,
                               } into g
                               select new ReportModelResponse
                               {
                                   Name = string.Format("{0}/{1}", g.Key.Month, g.Key.Year),
                                   DateResult = new DateTime(g.Key.Year, g.Key.Month, 1),
                                   Count = g.Count()
                               }).ToList().OrderBy(x => x.DateResult).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_Ram2TB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecibidoCNFV.Value.Year,
                                   Month = data.FechaRecibidoCNFV.Value.Month
                               } into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Alertas
        public async Task<ReportModel<ReportModelResponse>> ReportAlerta(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecepcion.Value.Year,
                                   Month = data.FechaRecepcion.Value.Month,
                               } into g
                               select new ReportModelResponse
                               {
                                   Name = string.Format("{0}/{1}", g.Key.Month, g.Key.Year),
                                   DateResult = new DateTime(g.Key.Year, g.Key.Month, 1),
                                   Count = g.Count()
                               }).ToList().OrderBy(x => x.DateResult).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_AlertaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecepcion.Value.Year,
                                   Month = data.FechaRecepcion.Value.Month
                               } into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //Notas
        public async Task<ReportModel<ReportModelResponse>> ReportNotas(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_NotaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Fecha >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Fecha <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.Fecha.Value.Year,
                                   Month = data.Fecha.Value.Month,
                               } into g
                               select new ReportModelResponse
                               {
                                   Name = string.Format("{0}/{1}", g.Key.Month, g.Key.Year),
                                   DateResult = new DateTime(g.Key.Year, g.Key.Month, 1),
                                   Count = g.Count()
                               }).ToList().OrderBy(x => x.DateResult).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_NotaTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Fecha >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Fecha <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.Fecha.Value.Year,
                                   Month = data.Fecha.Value.Month
                               } into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //PMR
        public async Task<ReportModel<ReportModelResponse>> ReportPmr(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_PmrTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaEntrada >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaEntrada <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaEntrada.Value.Year,
                                   Month = data.FechaEntrada.Value.Month,
                               } into g
                               select new ReportModelResponse
                               {
                                   Name = string.Format("{0}/{1}", g.Key.Month, g.Key.Year),
                                   DateResult = new DateTime(g.Key.Year, g.Key.Month, 1),
                                   Count = g.Count()
                               }).ToList().OrderBy(x => x.DateResult).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_PmrTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaEntrada >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaEntrada <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaEntrada.Value.Year,
                                   Month = data.FechaEntrada.Value.Month
                               } into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //IPS
        public async Task<ReportModel<ReportModelResponse>> ReportIps(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecepcion.Value.Year,
                                   Month = data.FechaRecepcion.Value.Month,
                               } into g
                               select new ReportModelResponse
                               {
                                   Name = string.Format("{0}/{1}", g.Key.Month, g.Key.Year),
                                   DateResult = new DateTime(g.Key.Year, g.Key.Month, 1),
                                   Count = g.Count()
                               }).ToList().OrderBy(x => x.DateResult).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecepcion.Value.Year,
                                   Month = data.FechaRecepcion.Value.Month
                               } into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //RFM
        public async Task<ReportModel<ReportModelResponse>> ReportRfv(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_RfvTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaNotificacion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaNotificacion <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaNotificacion.Value.Year,
                                   Month = data.FechaNotificacion.Value.Month,
                               } into g
                               select new ReportModelResponse
                               {
                                   Name = string.Format("{0}/{1}", g.Key.Month, g.Key.Year),
                                   DateResult = new DateTime(g.Key.Year, g.Key.Month, 1),
                                   Count = g.Count()
                               }).ToList().OrderBy(x => x.DateResult).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_RfvTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaNotificacion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaNotificacion <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaNotificacion.Value.Year,
                                   Month = data.FechaNotificacion.Value.Month
                               } into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //FF
        public async Task<ReportModel<ReportModelResponse>> ReportFF(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecibidoCNFV.Value.Year,
                                   Month = data.FechaRecibidoCNFV.Value.Month,
                               } into g
                               select new ReportModelResponse
                               {
                                   Name = string.Format("{0}/{1}", g.Key.Month, g.Key.Year),
                                   DateResult = new DateTime(g.Key.Year, g.Key.Month, 1),
                                   Count = g.Count()
                               }).ToList().OrderBy(x => x.DateResult).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FfTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecibidoCNFV.Value.Year,
                                   Month = data.FechaRecibidoCNFV.Value.Month
                               } into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }
        //FT
        public async Task<ReportModel<ReportModelResponse>> ReportFT(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecibidoCNFV.Value.Year,
                                   Month = data.FechaRecibidoCNFV.Value.Month,
                               } into g
                               select new ReportModelResponse
                               {
                                   Name = string.Format("{0}/{1}", g.Key.Month, g.Key.Year),
                                   DateResult = new DateTime(g.Key.Year, g.Key.Month, 1),
                                   Count = g.Count()
                               }).ToList().OrderBy(x => x.DateResult).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_FtTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate))
                               group data by
                               new
                               {
                                   Year = data.FechaRecibidoCNFV.Value.Year,
                                   Month = data.FechaRecibidoCNFV.Value.Month
                               } into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

    }

}
