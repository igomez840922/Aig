using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Aig.Farmacoterapia.Domain.Entities.Enums;

namespace Aig.Farmacoterapia.Application.Features.Account.Queries
{
    public class GetAvatarQuery : IRequest<FileStreamResult>
    {
        public string Image { get; set; }
        public GetAvatarQuery(string image) => Image = image;
    }
    internal class AvatarQueryHandler : IRequestHandler<GetAvatarQuery, FileStreamResult>
    {
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _logger;

        public AvatarQueryHandler(IUploadService uploadService, ISystemLogger logger)
        {
            _uploadService = uploadService;
            _logger = logger;
        }
        public async Task<FileStreamResult> Handle(GetAvatarQuery request, CancellationToken cancellationToken)
        {
            FileStreamResult result= new(new MemoryStream(Array.Empty<byte>()), "image/jpeg");
            try
            {
                var data=await _uploadService.GetFileAsync(request.Image, UploadType.Users);
                result = new(new MemoryStream(data),"image/jpeg");
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
            }
            return result;
        }
    }
}