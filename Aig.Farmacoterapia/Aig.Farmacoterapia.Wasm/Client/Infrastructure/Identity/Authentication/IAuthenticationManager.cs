using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure.Identity.Authentication
{
    public interface IAuthenticationManager : IManager
    {
        Task<IResult> Login(TokenRequest model);

        Task<IResult> Logout();

        Task<string> RefreshToken();

        Task<string> TryRefreshToken();

        Task<string> TryForceRefreshToken();

        Task<ClaimsPrincipal> CurrentUser();

        Task<IResult<long>> GetNotificationAsync();
    }
}