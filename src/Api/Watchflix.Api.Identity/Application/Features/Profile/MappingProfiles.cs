using Watchflix.Api.Identity.Application.Models.Dtos;
using Watchflix.Api.Identity.Application.Models.Entities;

namespace Watchflix.Api.Identity.Application.Features.Profile
{
    public class MappingProfiles:AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserQueryDto>().ReverseMap();
        }
    }
}
