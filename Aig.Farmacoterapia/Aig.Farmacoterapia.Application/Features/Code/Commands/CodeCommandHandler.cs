using AutoMapper;
using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Entities.Studies;

namespace Aig.Farmacoterapia.Application.Features.Study.Commands
{
    public partial class AddEditCodeCommand : IRequest<IResult>
    {
        public AigCodigoEstudio Model { get; set; }
        public AddEditCodeCommand(AigCodigoEstudio model) => Model = model;

    }
    public partial class DeleteCodeCommand : IRequest<IResult>
    {
        public long Id { get; set; }
    }

    internal class CodeCommandHandler : 
        IRequestHandler<AddEditCodeCommand, IResult>,
        IRequestHandler<DeleteCodeCommand, IResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemLogger _logger;

        public CodeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISystemLogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
      
        public async Task<IResult> Handle(AddEditCodeCommand request, CancellationToken cancellationToken)
        {
            IResult answer;
            try
            {
                var item = _unitOfWork.Repository<AigCodigoEstudio>().GetAll().FirstOrDefault(p => p.Id != request.Model.Id && p.Codigo == request.Model.Codigo);
                if (item != null)
                    return Result<bool>.Fail($"El código: {request.Model.Codigo}, ya fue registrado");

                if (request.Model.Id > 0)
                    await _unitOfWork.Repository<AigCodigoEstudio>().UpdateAsync(request.Model);
                else
                    await _unitOfWork.Repository<AigCodigoEstudio>().AddAsync(request.Model);
                answer = Result<bool>.Success(_unitOfWork.Commit());
            }
            catch (Exception exc)
            {
                _logger.Error("Error en la operación solicitada", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<IResult> Handle(DeleteCodeCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {

                var item =await _unitOfWork.Repository<AigCodigoEstudio>().GetByIdAsync(request.Id);
                if (item != null){

                    var study = _unitOfWork.Repository<AigEstudioDNFD>().GetAll().FirstOrDefault(p => p.AigCodigoEstudioId == item.Id);
                    if (study != null)
                        return Result<bool>.Fail($"En código: {item.Codigo}, es utilizado en el estudio: {study.Titulo}");

                    await _unitOfWork.Repository<AigCodigoEstudio>().DeleteAsync(item);
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
       
        
    }
}