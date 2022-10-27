using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IPdfGenerationService
    {
        Task<Stream> GenerateRetentionReceptionPDF(long InspectionId);
    }
}
