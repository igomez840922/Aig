using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Identity
{
    public class UpdateUserRolesRequest
    {
#pragma warning disable CS8618 // Non-nullable property 'UserId' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string UserId { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'UserId' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'UserRoles' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public IList<IdentityRole> UserRoles { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'UserRoles' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
