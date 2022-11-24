using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.Auditoria.Services
{
    public interface IPdfGenerationService
    {
        Task<Stream> GenerateRetentionReceptionPDF(long InspectionId);
        Task<Stream> GenerateAperturaCambioUbicacionPDF(long InspectionId);
    }
}
