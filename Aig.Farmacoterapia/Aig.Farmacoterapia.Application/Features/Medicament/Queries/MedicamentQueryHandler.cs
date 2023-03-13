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

namespace Aig.Farmacoterapia.Application.Features.Medicament.Queries
{
    public class AdminGetAllMedicamentQuery : IRequest<PaginatedResult<AigMedicamento>>
    {
        public PageSearchArgs Args { get; set; }
        public AdminGetAllMedicamentQuery(PageSearchArgs args) => Args = args;
    }
    public class GetAllMedicamentQuery : IRequest<PaginatedResult<AigMedicamento>>
    {
        public PageSearchArgs Args { get; set; }
        public GetAllMedicamentQuery(PageSearchArgs args) => Args = args;
    }
    public class GetPharmaceuticalQuery : IRequest<Result<List<AigFormaFarmaceutica>>>
    {
        public string Value { get; set; }
    }
    public class GetMedicationRoutelQuery : IRequest<Result<List<AigViaAdministracion>>>
    {
        public string Value { get; set; }
    }
    public class GetMarkerQuery : IRequest<Result<List<AigFabricante>>>
    {
        public string Value { get; set; }
    }
    public class GetFileQuery : IRequest<FileStreamResult>
    {
        public string Type { get; set; }
        public string File { get; set; }
        public GetFileQuery(string type, string file) {
            Type = type;
            File = file;
        }
    }
    public class GetMedicamentQuery : IRequest<Result<AigMedicamento>>
    {
        public long Id { get; set; }
        public GetMedicamentQuery(long id) => Id = id;
    }
    public class GetDashboardMedicamentQuery : IRequest<Result<DashboardMedicamentResponse>>
    {
        public GetDashboardMedicamentQuery() { }
    }

    public class ListMedicamentQuery : IRequest<PaginatedResult<AigMedicamento>>
    {
        public MedicamentPageSearch Args { get; set; }
        public ListMedicamentQuery(MedicamentPageSearch args) => Args = args;
    }
    internal class MedicamentQueryHandler : 
        IRequestHandler<AdminGetAllMedicamentQuery, PaginatedResult<AigMedicamento>>,
        IRequestHandler<GetAllMedicamentQuery, PaginatedResult<AigMedicamento>>,
        IRequestHandler<GetMedicamentQuery, Result<AigMedicamento>>,
        IRequestHandler<GetFileQuery, FileStreamResult>,
        IRequestHandler<GetPharmaceuticalQuery, Result<List<AigFormaFarmaceutica>>>,
        IRequestHandler<GetMedicationRoutelQuery, Result<List<AigViaAdministracion>>>,
        IRequestHandler<GetMarkerQuery, Result<List<AigFabricante>>>,
        IRequestHandler<GetDashboardMedicamentQuery, Result<DashboardMedicamentResponse>>,
        IRequestHandler<ListMedicamentQuery, PaginatedResult<AigMedicamento>>
    {
        private readonly IMedicamentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _logger;

        public MedicamentQueryHandler(IMedicamentRepository repository, IUnitOfWork unitOfWork, IUploadService uploadService, ISystemLogger logger)
        {
            _uploadService = uploadService;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PaginatedResult<AigMedicamento>> Handle(AdminGetAllMedicamentQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigMedicamento> answer ;
            try
            {
                answer = await _repository.AdminListAsync(request.Args);
            }
            catch (Exception exc) 
            {
                 _logger.Error("Requested operation failed", exc);
                 return PaginatedResult<AigMedicamento>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }
        public async Task<PaginatedResult<AigMedicamento>> Handle(GetAllMedicamentQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigMedicamento> answer;
            try
            {
                answer = await _repository.ListAsync(request.Args);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return PaginatedResult<AigMedicamento>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }
       
        public async Task<FileStreamResult> Handle(GetFileQuery request, CancellationToken cancellationToken)
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

        public async Task<Result<List<AigFormaFarmaceutica>>> Handle(GetPharmaceuticalQuery request, CancellationToken cancellationToken)
        {
            Result<List<AigFormaFarmaceutica>> answer = new();
            try
            {
                var result = new List<AigFormaFarmaceutica>();
                var query = _unitOfWork.Repository<AigFormaFarmaceutica>().GetAll();
                if (!string.IsNullOrEmpty(request.Value))
                    result = await query.WhereByAsync(p => p.Nombre, new PharmaceuticalSpecification(request.Value));
                else
                    result = await query.WhereByAsync(p => p.Nombre);
                answer= Result<List<AigFormaFarmaceutica>>.Success(result);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<List<AigFormaFarmaceutica>>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<Result<List<AigViaAdministracion>>> Handle(GetMedicationRoutelQuery request, CancellationToken cancellationToken)
        {
            Result<List<AigViaAdministracion>> answer = new();
            try
            {
                var result = new List<AigViaAdministracion>();
                var query = _unitOfWork.Repository<AigViaAdministracion>().GetAll();
                if (!string.IsNullOrEmpty(request.Value))
                    result = await query.WhereByAsync(p => p.Nombre, new MedicationRouteSpecification(request.Value));
                else
                    result = await query.WhereByAsync(p => p.Nombre);
                answer = Result<List<AigViaAdministracion>>.Success(result);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<List<AigViaAdministracion>>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
        public async Task<Result<List<AigFabricante>>> Handle(GetMarkerQuery request, CancellationToken cancellationToken)
        {
            Result<List<AigFabricante>> answer = new();
            try
            {
                var result = new List<AigFabricante>();
                var query = _unitOfWork.Repository<AigFabricante>().GetAll();
                if (!string.IsNullOrEmpty(request.Value))
                    result = await query.WhereByAsync(p => p.Nombre, new MakerSpecification(request.Value));
                else
                    result = await query.WhereByAsync(p => p.Nombre);
                answer = Result<List<AigFabricante>>.Success(result);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<List<AigFabricante>>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
      
        public async Task<Result<AigMedicamento>> Handle(GetMedicamentQuery request, CancellationToken cancellationToken)
        {
            var answer = new Result<AigMedicamento>();
            try
            {
                var result =await _unitOfWork.Repository<AigMedicamento>().GetByIdAsync(request.Id);
                answer = result==null? Result<AigMedicamento>.Fail(): Result<AigMedicamento>.Success(result);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<AigMedicamento>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<Result<DashboardMedicamentResponse>> Handle(GetDashboardMedicamentQuery request, CancellationToken cancellationToken)
        {
            var answer = new Result<DashboardMedicamentResponse>();
            try
            {
                var modelData = new DashboardMedicamentResponse();
                var repository = _unitOfWork.Repository<AigMedicamento>();
                modelData.MedicamentCount = await repository.CountAsync();
                if (modelData.MedicamentCount == 0) return answer;
                modelData.ReferenceCount = repository.GetAll().Where(p => p.TipoEquivalencia == "R").Count();
                if (modelData.ReferenceCount > 0)
                {
                    var percentage = ((decimal)modelData.ReferenceCount / (decimal)modelData.MedicamentCount) * 100;
                    modelData.ReferencePercent = $"{Math.Round(percentage, 2)}%";
                }
                modelData.InterchangeableCount = repository.GetAll().Where(p => p.TipoEquivalencia == "I").Count();
                if (modelData.InterchangeableCount > 0)
                {
                    var percentage = ((decimal)modelData.InterchangeableCount / (decimal)modelData.MedicamentCount) * 100;
                    modelData.InterchangeablePercent = $"{Math.Round(percentage, 2)}%";
                }
                modelData.GenericCount = repository.GetAll().Where(p => p.TipoEquivalencia == "G").Count();
                if (modelData.GenericCount > 0)
                {
                    var percentage = ((decimal)modelData.GenericCount / (decimal)modelData.MedicamentCount) * 100;
                    modelData.GenericPercent = $"{Math.Round(percentage, 2)}%";
                }
                modelData.PrescriptionCount = repository.GetAll().Where(p => p.CondicionVenta == "CP").Count();
                if (modelData.PrescriptionCount > 0)
                {
                    var percentage = ((decimal)modelData.PrescriptionCount / (decimal)modelData.MedicamentCount) * 100;
                    modelData.PrescriptionPercent = $"{Math.Round(percentage, 2)}%";
                }
                modelData.NotPrescriptionCount = repository.GetAll().Where(p => p.CondicionVenta == "SP").Count();
                if (modelData.NotPrescriptionCount > 0)
                {
                    var percentage = ((decimal)modelData.NotPrescriptionCount / (decimal)modelData.MedicamentCount) * 100;
                    modelData.NotPrescriptionPercent = $"{Math.Round(percentage, 2)}%";
                }
                modelData.HospitalUseCount = repository.GetAll().Where(p => p.CondicionVenta == "UH").Count();
                if (modelData.HospitalUseCount > 0)
                {
                    var percentage = ((decimal)modelData.HospitalUseCount / (decimal)modelData.MedicamentCount) * 100;
                    modelData.HospitalUsePercent = $"{Math.Round(percentage, 2)}%";
                }
                modelData.PopularSaleCount = repository.GetAll().Where(p => p.CondicionVenta == "VP").Count();
                if (modelData.PopularSaleCount > 0)
                {
                    var percentage = ((decimal)modelData.PopularSaleCount / (decimal)modelData.MedicamentCount) * 100;
                    modelData.PopularSalePercent = $"{Math.Round(percentage, 2)}%";
                }

                modelData.ActiveCount = repository.GetAll().Where(p => p.Vigente).Count();
                if (modelData.ActiveCount > 0)
                {
                    var percentage = ((decimal)modelData.ActiveCount / (decimal)modelData.MedicamentCount) * 100;
                    modelData.ActivePercent = $"{Math.Round(percentage, 2)}%";
                }

                modelData.NotActiveCount = modelData.MedicamentCount - modelData.ActiveCount;
                if (modelData.NotActiveCount > 0)
                {
                    var percentage = ((decimal)modelData.NotActiveCount / (decimal)modelData.MedicamentCount) * 100;
                    modelData.NotActivePercent = $"{Math.Round(percentage, 2)}%";
                }

                answer =  Result<DashboardMedicamentResponse>.Success(modelData);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<DashboardMedicamentResponse>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<PaginatedResult<AigMedicamento>> Handle(ListMedicamentQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigMedicamento> answer;
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
                return PaginatedResult<AigMedicamento>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }
    }
}