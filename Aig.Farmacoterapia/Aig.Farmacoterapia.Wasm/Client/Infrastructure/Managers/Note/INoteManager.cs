using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Managers.Note
{
    public interface INoteManager : IManager
    {
        Task<IResult> SendAsync(string code, UploadFileDTO file);

    }
}