using DataModel;
using DataModel.DTO;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditoriaApp.Services
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(RegisterModel userForRegistration);
        Task<AuthResponseDto> Login(LoginModel userForAuthentication); 
        Task Logout();
        Task<bool> HeartBeat();
    }
}
