using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IDashboardService
    {
       
        //Reports

        //1.	ESAVI según vacuna 
        Task<ReportModel<ReportModelResponse>> ReportEsavy(ReportModel<ReportModelResponse> model);
        //3.	ESAVI más frecuentes:
        Task<ReportModel<ReportModelResponse>> ReportRam(ReportModel<ReportModelResponse> model);
        //4.	Origen de la notificación
        Task<ReportModel<ReportModelResponse>> ReportAlerta(ReportModel<ReportModelResponse> model);
        //5.	Nota
        Task<ReportModel<ReportModelResponse>> ReportNotas(ReportModel<ReportModelResponse> model);
        //6.	PMR
        Task<ReportModel<ReportModelResponse>> ReportPmr(ReportModel<ReportModelResponse> model);
        //6.	IPS
        Task<ReportModel<ReportModelResponse>> ReportIps(ReportModel<ReportModelResponse> model);
        //6.	IPS
        Task<ReportModel<ReportModelResponse>> ReportRfv(ReportModel<ReportModelResponse> model);
        //6.	FF
        Task<ReportModel<ReportModelResponse>> ReportFF(ReportModel<ReportModelResponse> model);
        //6.	FT
        Task<ReportModel<ReportModelResponse>> ReportFT(ReportModel<ReportModelResponse> model);

    }


}
