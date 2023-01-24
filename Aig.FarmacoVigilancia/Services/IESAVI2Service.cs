using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IESAVI2Service
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_Esavi2TB> model);
        Task<List<FMV_Esavi2TB>> FindAll(Expression<Func<FMV_Esavi2TB, bool>> match);
        Task<GenericModel<FMV_Esavi2TB>> FindAll(GenericModel<FMV_Esavi2TB> model);
        Task<List<FMV_Esavi2TB>> GetAll();
        Task<FMV_Esavi2TB> Get(long id);
        Task<FMV_Esavi2TB> Save(FMV_Esavi2TB data);
        Task<FMV_Esavi2TB> Delete(long id);
        Task<int> Count();

        //Reports

        //1.	ESAVI según vacuna 
        Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model);
        //3.	ESAVI más frecuentes:
        Task<ReportModel<ReportModelResponse>> Report3(ReportModel<ReportModelResponse> model);
        //4.	Origen de la notificación
        Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model);
        //5.	ESAVI según gravedad
        Task<ReportModel<ReportModelResponse>> Report5(ReportModel<ReportModelResponse> model);
        //6.	ESAVI según desenlace
        Task<ReportModel<ReportModelResponse>> Report6(ReportModel<ReportModelResponse> model);
        //7.	ESAVI según SOC (sistema órgano/clase)
        Task<ReportModel<ReportModelResponse>> Report7(ReportModel<ReportModelResponse> model);
        //8.	Categoría de causalidad
        Task<ReportModel<ReportModelResponse>> Report8(ReportModel<ReportModelResponse> model);
        //9.	ESAVI según sexo
        Task<ReportModel<ReportModelResponse>> Report9(ReportModel<ReportModelResponse> model);
        //10.	ESAVI según edad
        Task<ReportModel<ReportModelResponse>> Report10(ReportModel<ReportModelResponse> model);
        //12.	Notificación según tipo de notificador
        Task<ReportModel<ReportModelResponse>> Report12(ReportModel<ReportModelResponse> model);
        //13.	Notificación según tipo de organización
        Task<ReportModel<ReportModelResponse>> Report13(ReportModel<ReportModelResponse> model);
        //14.	Notificación según región de salud
        Task<ReportModel<ReportModelResponse>> Report14(ReportModel<ReportModelResponse> model);
        //15.	Según año (fecha de recepción)
        Task<ReportModel<ReportModelResponse>> Report15(ReportModel<ReportModelResponse> model);
    }

   
}
