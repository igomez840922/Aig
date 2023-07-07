using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IPdfGenerationService
    {
        Task<Stream> GenerateRetentionReceptionPDF(long InspectionId);
        Task<Stream> GenerateNotePDF(long IdNote);
        Task<Stream> GenerateAlertPDF(long IdAlert);
        Task<Stream> GetStreamsFromFile(string filePath);
        Task<byte[]> GetByteArrayFromFile(string filePath);
    }
}
