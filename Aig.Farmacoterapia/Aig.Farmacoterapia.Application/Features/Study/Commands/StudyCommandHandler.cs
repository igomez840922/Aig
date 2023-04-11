using AutoMapper;
using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Mail;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;

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
    public partial class CloneStudyCommand : IRequest<IResult>
    {
        public long Id { get; set; }
    }

    internal class StudyCommandHandler : 
        IRequestHandler<AddEditStudyCommand, IResult>,
        IRequestHandler<DeleteStudyCommand, IResult>,
        IRequestHandler<CloneStudyCommand, IResult>,
        IRequestHandler<SetEvaluatorCommand, IResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly IOptions<AppConfiguration> _config;
        private readonly ISystemLogger _logger;

        public StudyCommandHandler(IUnitOfWork unitOfWork, 
            IUserService userService, 
            IMailService mailService,
            IMapper mapper,
            IOptions<AppConfiguration> confi,
            ISystemLogger logger)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _mailService = mailService;
            _mapper = mapper;
            _config = confi;
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
                if(item!=null) request.Model.AigEstudioDNFDId = item.Id;
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
                    answer = _unitOfWork.Commit() ? Result<bool>.Success("Elemento eliminado correctamente !") :
                             Result<bool>.Fail("Error durante la operación");
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
                var notifications = new List<dynamic>();
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
                    var user = await _userService.GetAsync(item);
                    var stydy = _unitOfWork.Repository<AigEstudio>().Entities.FirstOrDefault(p => p.Id == request.StudyId);
                    notifications.Add(new {
                        email = user?.Email,
                        message = $"{stydy?.Titulo} ({stydy?.Codigo})"
                    });
                }
                answer = _unitOfWork.Commit()?
                         Result<bool>.Success("Evaluadores actualizados correctamente !"):
                         Result.Fail(new List<string>() { "Error durante la operación. No fue posible asignar los evaluadores"});
                if (answer.Succeeded) {
                    var endpointUri = new Uri(string.Concat($"{_config.Value.BaseUrl}", "studies"));
                    foreach (var email in notifications) {
                        var mailRequest = new MailRequest {
                            To = Convert.ToString(email.email),
                            Body =$"Se le ha asignado una solicitud de autorización de permiso de importación con fines de investigación: {Convert.ToString(email.message)} <a href='{HtmlEncoder.Default.Encode(endpointUri.ToString())}'> (click aqui) </a>",
                            Subject = "Farmacoterapia (Nueva solicitud de importación)",
                        };
                        await _mailService.SendAsync(mailRequest);
                    }
                }
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<IResult> Handle(CloneStudyCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                var item =  _unitOfWork.Repository<AigEstudio>().EntitiesNoTracking.FirstOrDefault(s => s.Id == request.Id);
                if (item != null)
                {
                     var clone = _mapper.Map<AigEstudio>(item);
                     clone.Id = 0;
                     clone.FechaAsignacion = null;
                     clone.Estado = EstadoEstudio.Pendiente;
                     clone.Nota = new AigNotaEstudio();

                     await _unitOfWork.Repository<AigEstudio>().AddAsync(clone);
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