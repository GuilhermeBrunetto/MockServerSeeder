using API.DTOs;
using API.Entities;

namespace API.MappingProfiles
{
    public class GraoProfile : AutoMapper.Profile
    {
        public GraoProfile()
        {
            CreateMap<Grao, GraoDto>();
            CreateMap<GraoDto, Grao>();
        }
    }
}