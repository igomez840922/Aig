using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using MediatR;

namespace Aig.Farmacoterapia.Application.Features.Account.Commands
{
    #region Command
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
  
    #endregion

    internal class AccountCommandHandler :
    IRequestHandler<LoginCommand, Result<TokenResponse>>,
    IRequestHandler<RefreshTokenCommand, Result<TokenResponse>>

    {
        private readonly ITokenService _identityService;
        private readonly ISystemLogger _logger;

        public AccountCommandHandler(ITokenService identityService, ISystemLogger logger)
        {
            _identityService = identityService;
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
       
    }

}

