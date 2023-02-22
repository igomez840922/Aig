using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using Aig.Farmacoterapia.Domain.Entities.Studies;

namespace Aig.Farmacoterapia.Application.Features.User.Commands
{
    public partial class DeleteUserCommand : IRequest<IResult>
    {
        public string Id { get; set; } 
    }
    public class RegisterUserCommand : IRequest<IResult>
    {
        public RegisterRequest Model { get; set; }
        public RegisterUserCommand(RegisterRequest model) => Model = model;
    }
    public class UpdateProfileCommand : IRequest<IResult>
    {
        public UpdateProfileRequest Model { get; set; }
        public UpdateProfileCommand(UpdateProfileRequest model) => Model = model;
    }

    public class UpdateUserRolesCommand : IRequest<IResult>
    {
        public UpdateUserRolesRequest Model { get; set; }
        public UpdateUserRolesCommand(UpdateUserRolesRequest model) => Model = model;
    }

    public class ChangePasswordCommand : IRequest<IResult>
    {
        public ChangePasswordRequest Model { get; set; }
        public ChangePasswordCommand(ChangePasswordRequest model) => Model = model;
    }

    internal class UserCommandHandler : 
        IRequestHandler<RegisterUserCommand, IResult>,
        IRequestHandler<DeleteUserCommand, IResult>,
        IRequestHandler<UpdateProfileCommand, IResult>,
        IRequestHandler<UpdateUserRolesCommand, IResult>,
        IRequestHandler<ChangePasswordCommand, IResult>
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemLogger _logger;

        public UserCommandHandler(IUserService userService, IUnitOfWork unitOfWork, ISystemLogger logger)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<IResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                answer = await _userService.RegisterAsync(request.Model);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;

        }
        public async Task<IResult> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                answer = await _userService.UpdateProfileAsync(request.Model);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
        public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                answer = await _userService.DeleteAsync(request.Id);
              
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
        public async Task<IResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {

            IResult answer = new Result();
            try
            {
                answer = await _userService.ChangePasswordAsync(request.Model);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;

        }

        public async Task<IResult> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                answer = await _userService.UpdateRolesAsync(request.Model);
                if (answer.Succeeded && request.Model.Role!=Domain.Entities.Enums.RoleType.Evaluator) {
                    var evaluators = _unitOfWork.Repository<AigEstudioEvaluador>().Entities
                       .Where(p => p.UserId == request.Model.UserId).ToList();
                    foreach (var item in evaluators)
                        await _unitOfWork.Repository<AigEstudioEvaluador>().DeleteAsync(item);
                    if (evaluators.Count > 0) 
                        _unitOfWork.Commit();
                }

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