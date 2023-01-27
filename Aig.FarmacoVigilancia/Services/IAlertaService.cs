using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IAlertaService
    {
        Task<Stream> ExportToExcel(GenericModel<FMV_AlertaTB> model);
        Task<GenericModel<FMV_AlertaTB>> FindAll(GenericModel<FMV_AlertaTB> model);
        Task<List<FMV_AlertaTB>> GetAll();
        Task<FMV_AlertaTB> Get(long id);
        Task<FMV_AlertaTB> Save(FMV_AlertaTB data);
        Task<FMV_AlertaTB> Delete(long id);
        Task<int> Count();

        //Año de Recepción
        Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model);

        //Fármaco sospechoso Nombre Comercial
        Task<ReportModel<ReportModelResponse>> Report2(ReportModel<ReportModelResponse> model);

        //Origen
        Task<ReportModel<ReportModelResponse>> Report3(ReportModel<ReportModelResponse> model);

        //Tipo de Alerta
        Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model);

    }

   
}
