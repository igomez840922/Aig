using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Application.Features.Media.Commands;

namespace Aig.Farmacoterapia.Admin.Controllers.Media
{
    [ApiController]
    [Route("api/media")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    [DisableRequestSizeLimit]
    public class MediaController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _logger;
        private readonly IWebHostEnvironment _environment;

        public MediaController(IUploadService uploadService, IMediator mediator, IWebHostEnvironment environment, ISystemLogger logger)
        {
            _uploadService = uploadService;
            _mediator = mediator;
            _environment = environment;
            _logger = logger;
        }


        [HttpPost("chunk")]
        [AllowAnonymous]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> PostFile(IFormFile uploadFile)
        {

            try
            {

                if (uploadFile == null || uploadFile.Length == 0) return BadRequest();

                var folder = "datasheet";
                var folderName = Path.Combine("Files", folder);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fullFilePath = Path.Combine(pathToSave, uploadFile.FileName);

                if (!Directory.Exists(pathToSave))
                    Directory.CreateDirectory(pathToSave);

                using (var fs = new FileStream(fullFilePath, FileMode.Append))
                    await uploadFile.CopyToAsync(fs);


                return Created(fullFilePath, null);
            }
            catch
            {
                throw;
            }

        }



        //[HttpPost("AppendFile/{fragment}")]
        //[AllowAnonymous]
        //public async Task<bool> UploadFileChunk(int fragment, IFormFile file)
        //{
        //    try
        //    {
        //        var folder = "datasheet";
        //        var folderName = Path.Combine("Files", folder);
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        var fullPath = Path.Combine(pathToSave, file.FileName);

        //        // ** let the hosted path 
        //        //var fileName = @"C:\TEMP\" + file.FileName;

        //        if (fragment == 0 && System.IO.File.Exists(fullPath))
        //        {
        //            System.IO.File.Delete(fullPath);
        //        }

        //        using (var fileStream = new FileStream(fullPath, FileMode.Append, FileAccess.Write, FileShare.None))
        //        using (var bw = new BinaryWriter(fileStream))
        //        {
        //            await file.CopyToAsync(fileStream);
        //        }
        //        return true;
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine("Exception: {0}", exception.Message);
        //    }
        //    return false;
        //}


        [HttpPost("file")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {

                if (file is not null && file.Length > 0)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var ms = new MemoryStream();
                    file.CopyTo(ms); ms.Position = 0;
                    var uploadData = new UploadObject
                    {
                        FileName = $"{Guid.NewGuid()}{extension}",
                        Data = ms,
                        Size = file.Length,
                        UploadType = (UploadType)Enum.Parse(typeof(UploadType), "datasheet", true),
                    };
                    //var result = string.Empty;
                    //if (!string.IsNullOrEmpty(result = await _uploadService.UploadAsync(uploadData)))
                    //    return Ok($"File: {result} Length: {file.Length}");
                    UploadObject result;
                    if ((result = await _uploadService.UploadAsync(uploadData))!=null)
                        return Ok($"File: {result.FileName} Length: {result.Size}");
                    throw new Exception("Upload operation failed");
                }
                else
                    throw new Exception("he file is require");
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormCollection formData) => Ok(await _mediator.Send(new UploadMediaCommand(formData)));


    }
}
