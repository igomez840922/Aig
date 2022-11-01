using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;

namespace Aig.Farmacoterapia.Domain.Interfaces
{
    public interface IUserService
    {

        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<Result<string>> CreateUserAsync(string userName, string password);

        Task<Result<string>> DeleteUserAsync(string userId);
    }
}
