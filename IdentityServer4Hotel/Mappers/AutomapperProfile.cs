using AutoMapper;
using IdentityServer4Hotel.Models;

namespace IdentityServer4Hotel.Mappers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<LoginMetaModel, User>()
               .ForMember(au => au.Email, opt => opt.MapFrom(ul => ul.Email))
               .ForMember(au => au.UserName, opt => opt.MapFrom(ul => ul.Email));

            CreateMap<RegisterViewModel, User>()
              .ForMember(au => au.Email, opt => opt.MapFrom(ur => ur.Email))
              .ForMember(au => au.UserName, opt => opt.MapFrom(ur => ur.Email));

        }
    }
}
