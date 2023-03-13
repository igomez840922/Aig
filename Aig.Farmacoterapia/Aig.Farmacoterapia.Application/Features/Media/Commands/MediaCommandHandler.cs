using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;
using IResponse = Aig.Farmacoterapia.Domain.Interfaces.IResult;

namespace Aig.Farmacoterapia.Application.Features.Media.Commands
{
    public partial class UploadMediaCommand : IRequest<Result<string>>
    {
        public IFormCollection FormData { get; set; }
        public UploadMediaCommand(IFormCollection formData) => FormData = formData;

    }
    public partial class DeleteMediaCommand : IRequest<IResponse>
    {
        public string Type { get; set; }
        public string Image { get; set; }
        public DeleteMediaCommand(string type, string image)
        {
            Type = type;
            Image = image;
        }

    }
    internal class MediaCommandHandler : 
        IRequestHandler<UploadMediaCommand, Result<string>>,
        IRequestHandler<DeleteMediaCommand, IResponse>
    {
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _logger;

        public MediaCommandHandler(IUploadService uploadService, ISystemLogger logger)
        {
            _uploadService = uploadService;
            _logger = logger;
        }
        public async Task<Result<string>> Handle(UploadMediaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var file = request.FormData.Files[0];
                if (file is not null) {
                    var ms = new MemoryStream();
                    file.CopyTo(ms); ms.Position = 0;
                    request.FormData.TryGetValue("type", out var type);
                    var uploadData = new UploadObject
                    {
                        FileName = file.FileName,
                        Data = ms,
                        Size = file.Length,
                        ContentType = file.ContentType,
                        UploadType = (UploadType)Enum.Parse(typeof(UploadType), type.ToString(), true),
                    };
                    var result = string.Empty;
                    if(!string.IsNullOrEmpty(result=await _uploadService.UploadAsync(uploadData)))
                        return Result<string>.Success(file.FileName, "Successful upload");
                    return Result<string>.Fail(new List<string>() { "Upload operation failed" });
                }
                else
                    return Result<string>.Fail(new List<string>() { "The file is required" });
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<string>.Fail(new List<string>() { exc.Message });
            }
    
        }

        public async Task<IResponse> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
        {
            IResponse answer = new Result();
            try
            {
                if (string.IsNullOrEmpty(request.Type) || string.IsNullOrEmpty(request.Image))
                    answer= Result<bool>.Fail(new List<string>() { "Requested operation failed" });
                else
                {   var type = (UploadType)Enum.Parse(typeof(UploadType), request.Type, true);
                    answer = await _uploadService.DeleteAsync(type, request.Image) ?
                                                 Result.Success("Successful deleted") :
                                                 Result.Fail(new List<string>() { "Requested operation failed" });
                }
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<bool>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

    }
}