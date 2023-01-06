using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IPdfGenerationService
    {
        Task<Stream> GenerateInspectionPDF(long InspectionId);

        Task<Stream> GenerateCorrespondencia(long Id);
    }
}
