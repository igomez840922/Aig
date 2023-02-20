using Aig.Farmacoterapia.Domain.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Identity
{
    public class UserSpecification : BaseSpecification<ApplicationUser>
    {
        public UserSpecification(List<Expression<Func<ApplicationUser, bool>>> filters)
        {
            Criteria = p => p.UserName!= "sys@sys.com";
            foreach (var filter in filters)
                And(filter);
        }
    }
}
