using DataModel;
using DataModel.Models;
using MimeKit;

namespace Aig.FarmacoVigilancia.Services
{
    public interface IImportFileService
    {
        Task ImportRAMEsavi(AttachmentTB attachment);
    }
}

