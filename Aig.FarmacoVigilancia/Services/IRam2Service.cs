using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IRamService2
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_Ram2TB> model);
        Task<List<FMV_Ram2TB>> FindAll(Expression<Func<FMV_Ram2TB, bool>> match);
        Task<GenericModel<FMV_Ram2TB>> FindAll(GenericModel<FMV_Ram2TB> model);
        Task<List<FMV_Ram2TB>> GetAll();
        Task<FMV_Ram2TB> Get(long id);
        Task<FMV_Ram2TB> Save(FMV_Ram2TB data);
        Task<FMV_Ram2TB> Delete(long id);
        Task<int> Count();

        //Reports

        //Farmacos Sospechosos
        Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model);
        //Clasificación ATC
        Task<ReportModel<ReportModelResponse>> Report2(ReportModel<ReportModelResponse> model);
        //Origen de la Notificación 
        Task<ReportModel<ReportModelResponse>> Report3(ReportModel<ReportModelResponse> model);
        //Tipo de Notificador
        Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model);
        //Organizacion
        Task<ReportModel<ReportModelResponse>> Report5(ReportModel<ReportModelResponse> model);
        //Estatus
        Task<ReportModel<ReportModelResponse>> Report6(ReportModel<ReportModelResponse> model);
        //Edad
        Task<ReportModel<ReportModelResponse>> Report7(ReportModel<ReportModelResponse> model);
        //Sexo
        Task<ReportModel<ReportModelResponse>> Report8(ReportModel<ReportModelResponse> model);
        //Calidad de la información (grado)
        Task<ReportModel<ReportModelResponse>> Report9(ReportModel<ReportModelResponse> model);
        //RAM
        Task<ReportModel<ReportModelResponse>> Report10(ReportModel<ReportModelResponse> model);
        //Clasificación según SOC (Sistema órgano/clase)
        Task<ReportModel<ReportModelResponse>> Report11(ReportModel<ReportModelResponse> model);
        //Resultado del Algoritmo (Probabilidad)
        Task<ReportModel<ReportModelResponse>> Report12(ReportModel<ReportModelResponse> model);
        //Gravedad
        Task<ReportModel<ReportModelResponse>> Report13(ReportModel<ReportModelResponse> model);
        //Según año (fecha de recepción).
        Task<ReportModel<ReportModelResponse>> Report14(ReportModel<ReportModelResponse> model);
    }

   
}
