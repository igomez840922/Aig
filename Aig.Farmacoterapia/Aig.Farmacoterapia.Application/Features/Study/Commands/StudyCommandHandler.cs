using AutoMapper;
using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Entities.Studies;

namespace Aig.Farmacoterapia.Application.Features.Study.Commands
{
    public partial class AddEditStudyCommand : IRequest<IResult>
    {
        public AigEstudio Model { get; set; }
        public AddEditStudyCommand(AigEstudio model) => Model = model;

    }
    public partial class DeleteStudyCommand : IRequest<IResult>
    {
        public long Id { get; set; }
    }

    public partial class SetEvaluatorCommand : IRequest<IResult>
    {
        public long StudyId { get; set; } = 0;
        public string[] Evaluators { get; set; } = Array.Empty<string>();

    }
    internal class StudyCommandHandler : 
        IRequestHandler<AddEditStudyCommand, IResult>,
        IRequestHandler<DeleteStudyCommand, IResult>,
        IRequestHandler<SetEvaluatorCommand, IResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemLogger _logger;

        public StudyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISystemLogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
      
        public async Task<IResult> Handle(AddEditStudyCommand request, CancellationToken cancellationToken)
        {
            IResult answer;
            try
            {
                //if(_unitOfWork.Repository<AigEstudio>().Entities.FirstOrDefault(p => p.Codigo == request.Model.Codigo && p.Id!= request.Model.Id) != null)
                //    return Result.Fail(new List<string>() { "Error en la operación solicitada. Ya existe un registro con ese código" });

                //request.Model.ProductsMetadata = JsonConvert.SerializeObject(request.Model.Medicamentos, 
                //    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore 
                //   });

                request.Model.ProductsMetadata = string.Join("//", request.Model.Medicamentos.Select(p => p.Nombre));
                var item = _unitOfWork.Repository<AigEstudioDNFD>().GetAll().FirstOrDefault(p => p.AigCodigo.Codigo == request.Model.Codigo);
                request.Model.AigEstudioDNFDId = item != null ? item.Id : null;
                if (request.Model.Id > 0)
                    await _unitOfWork.Repository<AigEstudio>().UpdateAsync(request.Model);
                else
                    await _unitOfWork.Repository<AigEstudio>().AddAsync(request.Model);
                answer = Result<bool>.Success(_unitOfWork.Commit());

            }
            catch (Exception exc)
            {
                _logger.Error("Error en la operación solicitada", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<IResult> Handle(DeleteStudyCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                var item=await _unitOfWork.Repository<AigEstudio>().GetByIdAsync(request.Id);
                if (item != null){
                    await _unitOfWork.Repository<AigEstudio>().DeleteAsync(item);
                    answer = Result<bool>.Success(_unitOfWork.Commit());
                }
                else answer = Result<bool>.Fail();
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
        public async Task<IResult> Handle(SetEvaluatorCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                var evaluators = _unitOfWork.Repository<AigEstudioEvaluador>().Entities
                    .Where(p => p.EstudioId == request.StudyId)
                    .ToList();
                foreach (var item in evaluators)
                    await _unitOfWork.Repository<AigEstudioEvaluador>().DeleteAsync(item);
                foreach (var item in request.Evaluators){
                    await _unitOfWork.Repository<AigEstudioEvaluador>().AddAsync(
                        new AigEstudioEvaluador(){
                            EstudioId = request.StudyId,
                            UserId = item
                        });
                }
                answer = Result<bool>.Success(_unitOfWork.Commit(),"Evaluadores actualizados correctamente !");

            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
        
    }
}