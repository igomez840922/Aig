using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aig.Farmacoterapia.Application.Features.Medicament.Commands;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Interfaces;

namespace Aig.Farmacoterapia.Admin.Controllers.Media
{
    [ApiController]
    [Route("api/media")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    public class MediaController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _logger;

        public MediaController(IUploadService uploadService, IMediator mediator, ISystemLogger logger)
        {
            _uploadService = uploadService;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("file")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
              
                if (file is not null && file.Length>0)
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
                    var result = string.Empty;
                    if (!string.IsNullOrEmpty(result = await _uploadService.UploadAsync(uploadData)))
                        return Ok($"File: {result} Length: {file.Length}");
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
