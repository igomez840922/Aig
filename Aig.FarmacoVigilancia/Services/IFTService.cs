using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IFTService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_FtTB> model);
        Task<List<FMV_FtTB>> FindAll(Expression<Func<FMV_FtTB, bool>> match);
        Task<GenericModel<FMV_FtTB>> FindAll(GenericModel<FMV_FtTB> model);
        Task<List<FMV_FtTB>> GetAll();
        Task<FMV_FtTB> Get(long id);
        Task<FMV_FtTB> Save(FMV_FtTB data);
        Task<FMV_FtTB> Delete(long id);
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
        //14. Por Edad
        Task<ReportModel<ReportModelResponse>> Report14(ReportModel<ReportModelResponse> model);
        //15. Por Sexo
        Task<ReportModel<ReportModelResponse>> Report15(ReportModel<ReportModelResponse> model);

    }


}
