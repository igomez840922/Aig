using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Infrastructure.Identity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Application.Features.User.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserModelOutput>();
        }
    }
}
