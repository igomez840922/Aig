using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Application.Features.Account.Commands
{
    public class LoginCommand : IRequest<Result<TokenResponse>>
    {
        public TokenRequest Model { get; set; }
        public LoginCommand(TokenRequest model) => Model = model;
    }
    public class RefreshTokenCommand : IRequest<Result<TokenResponse>>
    {
        public RefreshTokenRequest Model { get; set; }
        public RefreshTokenCommand(RefreshTokenRequest model) => Model = model;
    }
    public class UpdateProfileCommand : IRequest<IResult>
    {
        public UpdateProfileRequest Model { get; set; }
        public UpdateProfileCommand(UpdateProfileRequest model) => Model = model;
    }

    internal class AccountCommandHandler :
    IRequestHandler<LoginCommand, Result<TokenResponse>>,
    IRequestHandler<RefreshTokenCommand, Result<TokenResponse>>,
    IRequestHandler<UpdateProfileCommand, IResult>
    {
        private readonly ITokenService _identityService;
        private readonly IUserService _userService;
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _logger;

        public AccountCommandHandler(ITokenService identityService, IUserService userService, IUploadService uploadService, ISystemLogger logger)
        {
            _identityService = identityService;
            _userService = userService;
            _uploadService = uploadService;
            _logger = logger;
        }

        public async Task<Result<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Result<TokenResponse> answer = new();
            try
            {
                answer = await _identityService.LoginAsync(request.Model);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<TokenResponse>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
        public async Task<Result<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            Result<TokenResponse> answer = new();
            try
            {
                answer = await _identityService.GetRefreshTokenAsync(request.Model);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<TokenResponse>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
        public async Task<IResult> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                if (request.Model.UploadRequest!=null && !string.IsNullOrEmpty(await _uploadService.UploadAsync(request.Model.UploadRequest)))
                    request.Model.ProfilePicture = request.Model.UploadRequest.FileName;
                answer = await _userService.UpdateProfileAsync(request.Model);
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

