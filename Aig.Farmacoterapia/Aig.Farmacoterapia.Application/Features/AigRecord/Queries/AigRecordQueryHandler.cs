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
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Aig.Farmacoterapia.Domain.Specifications.Medicament;
using Aig.Farmacoterapia.Domain.Specifications.Maker;
using Aig.Farmacoterapia.Domain.Response;
using Aig.Farmacoterapia.Application.Medicament.Model;
using Aig.Farmacoterapia.Domain.Entities.Products;

namespace Aig.Farmacoterapia.Application.Features.Medicament.Queries
{
    public class AdminGetAllAigRecordQuery : IRequest<PaginatedResult<AigRecord>>
    {
        public PageSearchArgs Args { get; set; }
        public AdminGetAllAigRecordQuery(PageSearchArgs args) => Args = args;
    }
    public class GetAllAigRecordQuery : IRequest<PaginatedResult<AigRecord>>
    {
        public PageSearchArgs Args { get; set; }
        public GetAllAigRecordQuery(PageSearchArgs args) => Args = args;
    }
  
    public class GetAigRecordFileQuery : IRequest<FileStreamResult>
    {
        public string Type { get; set; }
        public string File { get; set; }
        public GetAigRecordFileQuery(string type, string file) {
            Type = type;
            File = file;
        }
    }
    public class GetAigRecordQuery : IRequest<Result<AigRecord>>
    {
        public long Id { get; set; }
        public GetAigRecordQuery(long id) => Id = id;
    }
   
    public class ListAigRecordQuery : IRequest<PaginatedResult<AigRecord>>
    {
        public MedicamentPageSearch Args { get; set; }
        public ListAigRecordQuery(MedicamentPageSearch args) => Args = args;
    }
    internal class AigRecordQueryHandler : 
        IRequestHandler<AdminGetAllAigRecordQuery, PaginatedResult<AigRecord>>,
        IRequestHandler<GetAllAigRecordQuery, PaginatedResult<AigRecord>>,
        IRequestHandler<GetAigRecordQuery, Result<AigRecord>>,
        IRequestHandler<GetAigRecordFileQuery, FileStreamResult>,
        IRequestHandler<ListAigRecordQuery, PaginatedResult<AigRecord>>
    {
        private readonly IAigRecordRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _logger;

        public AigRecordQueryHandler(IAigRecordRepository repository, IUnitOfWork unitOfWork, IUploadService uploadService, ISystemLogger logger)
        {
            _uploadService = uploadService;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PaginatedResult<AigRecord>> Handle(AdminGetAllAigRecordQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigRecord> answer ;
            try
            {
                answer = await _repository.AdminListAsync(request.Args);
            }
            catch (Exception exc) 
            {
                 _logger.Error("Requested operation failed", exc);
                 return PaginatedResult<AigRecord>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }
        
        public async Task<PaginatedResult<AigRecord>> Handle(GetAllAigRecordQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigRecord> answer;
            try
            {
                answer = await _repository.ListAsync(request.Args);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return PaginatedResult<AigRecord>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }
       
        public async Task<FileStreamResult> Handle(GetAigRecordFileQuery request, CancellationToken cancellationToken)
        {
            FileStreamResult result = new(new MemoryStream(Array.Empty<byte>()), "application/unknow");
            try
            {
                if (string.IsNullOrEmpty(request.Type) || string.IsNullOrEmpty(request.File)) return result;
                var type = (UploadType)Enum.Parse(typeof(UploadType), request.Type, true);
                var data = await _uploadService.GetFileAsync(request.File,type);
                result = new(new MemoryStream(data), "application/unknow");
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
            }
            return result;
        }

        public async Task<Result<AigRecord>> Handle(GetAigRecordQuery request, CancellationToken cancellationToken)
        {
            var answer = new Result<AigRecord>();
            try
            {
                var result =await _unitOfWork.Repository<AigRecord>().GetByIdAsync(request.Id);
                answer = result==null? Result<AigRecord>.Fail(): Result<AigRecord>.Success(result);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<AigRecord>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<PaginatedResult<AigRecord>> Handle(ListAigRecordQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigRecord> answer;
            try
            {
                var searchArgs = new PageSearchArgs() {
                    PageIndex = request.Args.PageIndex,
                    PageSize = request.Args.PageSize,
                    FilteringOptions = !string.IsNullOrEmpty(request.Args.Term) ? new List<FilteringOption>() {
                        new FilteringOption {
                            Field = "term", Operator = FilteringOperator.Contains, Value =  request.Args.Term
                        }
                    } : new List<FilteringOption>()
                };
                answer= await _repository.AdminListAsync(searchArgs);
            }
            catch (Exception exc) {
                _logger.Error("Requested operation failed", exc);
                return PaginatedResult<AigRecord>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }
    }
}