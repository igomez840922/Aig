﻿
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Admin.Controllers.Identity
{
    [Route("api/identity")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _identityService;
        private readonly ISystemLogger _systemLogger;
        public TokenController(ITokenService identityService, ISystemLogger systemLogger)
        {
            _identityService = identityService;
            _systemLogger = systemLogger;
        }

        [HttpPost("token")]
        public async Task<Result<TokenResponse>> Token(TokenRequest model)
        {
            try
            {
                return await _identityService.LoginAsync(model);
            }
            catch (Exception ex)
            {
                _systemLogger.Error(ex.Message);
                return Result<TokenResponse>.Fail(new List<string>() { ex.Message });
            }
        }
    }
}