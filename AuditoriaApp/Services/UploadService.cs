﻿using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;

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
                    string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AuditoriaApp");
                    //Path.Combine(FileSystem.Current.AppDataDirectory, "AuditoriaApp");
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
                        Url = null,//string.Format("/files/{0}", fileName),
                        FileName = fileName,
                        Base64 = Helper.Helper.ReturnBase64FromFilePath(path)
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

                    //return true;
                }
            }
            catch{}
            return true;
        }

        //public async Task ExecuteFile(string filePath)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(filePath))
        //        {
        //            await Launcher.OpenAsync(new OpenFileRequest
        //            {
        //                File = new ReadOnlyFile(filePath)
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions, e.g., if there's no associated app to open the file
        //    }
        //}

        public async Task ExecuteFile(AttachmentTB attach)
        {
            try
            {
                //FileSystem.AppDataDirectory
                string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AuditoriaApp", "TempFile");
                //Path.Combine(FileSystem.Current.AppDataDirectory, "AuditoriaApp");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                // remove all files
                foreach (string file in Directory.GetFiles(dir))
                {
                    File.Delete(file);
                }
                var fileBytes = Helper.Helper.ReturnByteArrayFromBase64(attach.Base64);
                var path = System.IO.Path.Combine(dir, attach.FileName);
                System.IO.File.WriteAllBytes(path, fileBytes);
                if (!string.IsNullOrEmpty(path))
                {
                    await Launcher.OpenAsync(new OpenFileRequest
                    {
                        File = new ReadOnlyFile(path)
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