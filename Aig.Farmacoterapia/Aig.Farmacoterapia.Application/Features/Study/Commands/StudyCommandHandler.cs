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
                if (request.Model.Id > 0)
                    await _unitOfWork.Repository<AigEstudio>().UpdateAsync(request.Model);
                else {
                    var newitem = new AigEstudioDNFD();
                    newitem.Codigo = request.Model.Codigo;
                    newitem.Titulo = request.Model.Titulo;
                    newitem.CentroInvestigacion = request.Model.CentroInvestigacion;
                    newitem.InvestigadorPrincipal = request.Model.InvestigadorPrincipal;
                    newitem.Participantes = request.Model.Participantes;
                    newitem.Patrocinador = request.Model.Patrocinador;
                    newitem.Duracion = request.Model.Duracion;
                    newitem.Poblacion = request.Model.Poblacion;
                    newitem.Medicamentos = request.Model.Medicamentos;
                    newitem.ProductsMetadata = request.Model.ProductsMetadata;

                    newitem.RegistroProtocoloDIGESA = string.Empty;
                    newitem.ComiteBioetica = string.Empty;

                    await _unitOfWork.ExecuteInTransactionAsync(async (cc) => {
                        await _unitOfWork.BeginTransactionAsync(cc);
                        newitem.AigEstudio= await _unitOfWork.Repository<AigEstudio>().AddAsync(request.Model);
                        await _unitOfWork.Repository<AigEstudioDNFD>().AddAsync(newitem);
                        answer = Result<bool>.Success(_unitOfWork.Commit());
                    }, cancellationToken);
                }  
                answer = Result<bool>.Success(_unitOfWork.Commit(), "Operación realizada satisfactoriamente !");
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