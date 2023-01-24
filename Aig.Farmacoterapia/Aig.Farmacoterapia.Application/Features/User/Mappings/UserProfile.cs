using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Infrastructure.Identity;
using AutoMapper;

namespace Aig.Farmacoterapia.Application.Features.User.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserModelOutput>();
            CreateMap<ApplicationUser, UpdateProfileRequest>();
        }
    }
}
