using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IFFService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_FfTB> model);

        Task<List<FMV_FfTB>> FindAll(Expression<Func<FMV_FfTB, bool>> match);
        Task<GenericModel<FMV_FfTB>> FindAll(GenericModel<FMV_FfTB> model);
        Task<List<FMV_FfTB>> GetAll();
        Task<FMV_FfTB> Get(long id);
        Task<FMV_FfTB> Save(FMV_FfTB data);
        Task<FMV_FfTB> Delete(long id);
        Task<int> Count();


        //Reports

        //1.	Fármaco sospechoso (DCI)
        Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model);
        //2.	Clasificación ATC
        Task<ReportModel<ReportModelResponse>> Report2(ReportModel<ReportModelResponse> model);
        //3.	Tipo de notificador
        Task<ReportModel<ReportModelResponse>> Report3(ReportModel<ReportModelResponse> model);
        //4.	Según Organización
        Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model);
        //5.	Según región de salud
        Task<ReportModel<ReportModelResponse>> Report5(ReportModel<ReportModelResponse> model);
        //6.	Según fabricante
        Task<ReportModel<ReportModelResponse>> Report6(ReportModel<ReportModelResponse> model);
        //7.	Según año (fecha de recepción)
        Task<ReportModel<ReportModelResponse>> Report7(ReportModel<ReportModelResponse> model);
        //8.	Según calidad de información (grado)
        Task<ReportModel<ReportModelResponse>> Report8(ReportModel<ReportModelResponse> model);
        //9.	Nombre comercial
        Task<ReportModel<ReportModelResponse>> Report9(ReportModel<ReportModelResponse> model);
        //10.	Presentación
        Task<ReportModel<ReportModelResponse>> Report10(ReportModel<ReportModelResponse> model);
        //11.	Lote
        Task<ReportModel<ReportModelResponse>> Report11(ReportModel<ReportModelResponse> model);
        //12.	Registro sanitario
        Task<ReportModel<ReportModelResponse>> Report12(ReportModel<ReportModelResponse> model);
        //13.	Incidencia del caso (inicial y seguimiento)
        Task<ReportModel<ReportModelResponse>> Report13(ReportModel<ReportModelResponse> model);

        Task<Stream> ExportToExcelRpt(ReportModel<ReportModelResponse> model, int RptType);

    }


}
