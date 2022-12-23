using DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aig.Auditoria2.Services
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(RegisterDTO userForRegistration);
        Task<AuthResponseDto> Login(LoginDTO userForAuthentication); 
        Task Logout();
    }
}
