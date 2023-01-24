using Aig.Farmacoterapia.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Identity
{
    public class UpdateUserRolesRequest
    {
        public string UserId { get; set; }
        public RoleType Role { get; set; }
    }
}
