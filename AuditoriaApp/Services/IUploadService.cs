using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Forms;

namespace AuditoriaApp.Services
{
    public interface IUploadService
    {
        Task<FileUploadResult> UploadFile(IBrowserFile File);

        Task<bool> DeleteFile(AttachmentTB data);
    }
}
