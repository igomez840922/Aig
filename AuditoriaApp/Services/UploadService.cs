using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;

namespace AuditoriaApp.Services
{    
    public class UploadService : IUploadService
    {
        //private readonly HttpClient _client;
        private readonly IApiConnectionService apiConnectionService;
        private readonly JsonSerializerOptions options;
        private readonly IAccountDataService accountDataService;
        //private readonly IWebHostEnvironment env;

        public UploadService(IApiConnectionService apiConnectionService, IAccountDataService accountDataService)
        {
            this.apiConnectionService = apiConnectionService;
            this.options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.accountDataService = accountDataService;
        }
   
        public async Task<FileUploadResult> UploadFile(IBrowserFile file)//([FromForm] IEnumerable<IFormFile> files)
        {

            try
            {      
                if (file != null)
                {
                    var buffer = new byte[file.Size];
                    var stream = file.OpenReadStream();
                    await stream.ReadAsync(buffer, 0, (int)file.Size);

                    //var dir = Path.Combine(env.WebRootPath, "files");//Path.GetRandomFileName()
                    //var dir = Path.Combine("wwwroot", "files");//Path.GetRandomFileName()
                    //                                           //var dir = Path.Combine("Files");
                    //FileSystem.AppDataDirectory
                    string dir = Path.Combine(FileSystem.Current.AppDataDirectory, "AuditoriaApp");
                    //Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AuditoriaApp");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    var fileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), file.Name.Split(".").LastOrDefault());
                    var path = System.IO.Path.Combine(dir, fileName);

                    //var path = Path.Combine(dir, file.FileName);
                    using (FileStream fileStream = new FileStream(path, FileMode.Create))
                    {
                        await fileStream.WriteAsync(buffer, 0, buffer.Length);
                    }

                    var model = new FileUploadResult()
                    {
                        AbsolutePath = path,
                        Url = string.Format("/files/{0}", fileName),
                        FileName = fileName
                    };

                    return model;
                }
            }
            catch { }
            return null;
        }

        public async Task<bool> DeleteFile(AttachmentTB data)
        {
            try
            {
                if (System.IO.File.Exists(data.AbsolutePath))
                {
                    System.IO.File.Delete(data.AbsolutePath);

                    return true;
                }
            }
            catch{}
            return false;
        }

        public async Task ExecuteFile(string filePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    await Launcher.OpenAsync(new OpenFileRequest
                    {
                        File = new ReadOnlyFile(filePath)
                    });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., if there's no associated app to open the file
            }
        }

    }

}
