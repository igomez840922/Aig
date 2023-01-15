using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;

namespace Aig.Farmacoterapia.Application.Features.Medicament.Commands
{
    public partial class AddEditUserCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
    }

    internal class AddEditUserCommandHandler : IRequestHandler<AddEditUserCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _systemLogger;

        public AddEditUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUploadService uploadService, ISystemLogger systemLogger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadService = uploadService;
            _systemLogger = systemLogger;
        }

        public async Task<Result<int>> Handle(AddEditUserCommand request, CancellationToken cancellationToken)
        {
            return new Result<int>();
        }
        //public async Task<Result<int>> Handle(AddEditProductCommand command, CancellationToken cancellationToken)
        //{
        //    if (await _unitOfWork.Repository<Product>().Entities.Where(p => p.Id != command.Id)
        //        .AnyAsync(p => p.Barcode == command.Barcode, cancellationToken))
        //    {
        //        return await Result<int>.FailAsync(_localizer["Barcode already exists."]);
        //    }

        //    var uploadRequest = command.UploadRequest;
        //    if (uploadRequest != null)
        //    {
        //        uploadRequest.FileName = $"P-{command.Barcode}{uploadRequest.Extension}";
        //    }

        //    if (command.Id == 0)
        //    {
        //        var product = _mapper.Map<Product>(command);
        //        if (uploadRequest != null)
        //        {
        //            product.ImageDataURL = _uploadService.UploadAsync(uploadRequest);
        //        }
        //        await _unitOfWork.Repository<Product>().AddAsync(product);
        //        await _unitOfWork.Commit(cancellationToken);
        //        return await Result<int>.SuccessAsync(product.Id, _localizer["Product Saved"]);
        //    }
        //    else
        //    {
        //        var product = await _unitOfWork.Repository<Product>().GetByIdAsync(command.Id);
        //        if (product != null)
        //        {
        //            product.Name = command.Name ?? product.Name;
        //            product.Description = command.Description ?? product.Description;
        //            if (uploadRequest != null)
        //            {
        //                product.ImageDataURL = _uploadService.UploadAsync(uploadRequest);
        //            }
        //            product.Rate = (command.Rate == 0) ? product.Rate : command.Rate;
        //            product.BrandId = (command.BrandId == 0) ? product.BrandId : command.BrandId;
        //            await _unitOfWork.Repository<Product>().UpdateAsync(product);
        //            await _unitOfWork.Commit(cancellationToken);
        //            return await Result<int>.SuccessAsync(product.Id, _localizer["Product Updated"]);
        //        }
        //        else
        //        {
        //            return await Result<int>.FailAsync(_localizer["Product Not Found!"]);
        //        }
        //    }
        //}

    }
}