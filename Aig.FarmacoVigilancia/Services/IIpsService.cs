using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IIpsService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_IpsTB> model);

        Task<GenericModel<FMV_IpsTB>> FindAll(GenericModel<FMV_IpsTB> model);
        Task<List<FMV_IpsTB>> GetAll();
        Task<FMV_IpsTB> Get(long id);
        Task<FMV_IpsTB> Save(FMV_IpsTB data);
        Task<FMV_IpsTB> Delete(long id);
        Task<int> Count();

        //Nombre Comercial
        Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model);
        //Nombre DCI
        Task<ReportModel<ReportModelResponse>> Report2(ReportModel<ReportModelResponse> model);
        //Titular
        Task<ReportModel<ReportModelResponse>> Report3(ReportModel<ReportModelResponse> model);
        //Reg Sanitario
        Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model);
        //Prioridad
        Task<ReportModel<ReportModelResponse>> Report5(ReportModel<ReportModelResponse> model);
        //Año de Recepción
        Task<ReportModel<ReportModelResponse>> Report6(ReportModel<ReportModelResponse> model);
        //Innovador
        Task<ReportModel<ReportModelResponse>> Report7(ReportModel<ReportModelResponse> model);
        //Biológico
        Task<ReportModel<ReportModelResponse>> Report8(ReportModel<ReportModelResponse> model);
        //Requiere intercambiabilidad
        Task<ReportModel<ReportModelResponse>> Report9(ReportModel<ReportModelResponse> model);
        //Estatus del  Registro
        Task<ReportModel<ReportModelResponse>> Report10(ReportModel<ReportModelResponse> model);
        //Recibidos
        Task<ReportModel<ReportModelResponse>> Report11(ReportModel<ReportModelResponse> model);
        //Estatus de Revision
        Task<ReportModel<ReportModelResponse>> Report12(ReportModel<ReportModelResponse> model);

    }

   
}
