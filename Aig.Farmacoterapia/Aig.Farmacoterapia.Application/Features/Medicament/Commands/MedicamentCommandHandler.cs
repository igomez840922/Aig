using AutoMapper;
using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Entities;

namespace Aig.Farmacoterapia.Application.Features.Medicament.Commands
{
    public partial class AddEditMedicamentCommand : IRequest<IResult>
    {
        public AigMedicamento Model { get; set; }
        public AddEditMedicamentCommand(AigMedicamento model) => Model = model;

    }
    public partial class DeleteMedicamentCommand : IRequest<IResult>
    {
        public long Id { get; set; }
    }
    internal class MedicamentCommandHandler : 
        IRequestHandler<AddEditMedicamentCommand, IResult>,
        IRequestHandler<DeleteMedicamentCommand, IResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _logger;

        public MedicamentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUploadService uploadService, ISystemLogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadService = uploadService;
            _logger = logger;
        }

        public async Task<IResult> Handle(AddEditMedicamentCommand request, CancellationToken cancellationToken)
        {
            IResult answer;
            try
            {
                if (request.Model != null) {
                    if (request.Model.ViaAdministracion != null){
                        request.Model.ViaAdministracionId = request.Model.ViaAdministracion.Id;
                        request.Model.ViaAdministracion = null;
                    }
                    if (request.Model.FormaFarmaceutica != null){
                        request.Model.FormaFarmaceuticaId = request.Model.FormaFarmaceutica.Id;
                        request.Model.FormaFarmaceutica = null;
                    }
                    if (request.Model.Fabricante != null){
                        request.Model.FabricanteId = request.Model.Fabricante.Id;
                        request.Model.Fabricante = null;
                    }
                }

                if (request.Model.Id > 0)
                    await _unitOfWork.Repository<AigMedicamento>().UpdateAsync(request.Model);
                else
                    await _unitOfWork.Repository<AigMedicamento>().AddAsync(request.Model);
                answer = Result<bool>.Success(_unitOfWork.Commit());
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<IResult> Handle(DeleteMedicamentCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                var item=await _unitOfWork.Repository<AigMedicamento>().GetByIdAsync(request.Id);
                if (item != null){
                    await _unitOfWork.Repository<AigMedicamento>().DeleteAsync(item);
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