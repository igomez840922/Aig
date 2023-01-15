using Aig.Farmacoterapia.Admin.Wasm.Infrastructure;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Admin.Wasm.Infrastructure.Managers.User
{
    public interface IUserManager : IManager
    {
        Task<PaginatedResult<UserModelOutput>> SearchAsync(PageSearchArgs request);
        Task<IResult<bool>> UsernameExists(string userName);
        Task<IResult<bool>> PhoneExists(string userName);
    }
}
