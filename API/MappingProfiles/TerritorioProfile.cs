using API.DTOs;
using API.Entities;

namespace API.MappingProfiles
{
    public class TerritorioProfile : AutoMapper.Profile
    {
        public TerritorioProfile()
        {
            CreateMap<Territorio, TerritorioDto>();
            CreateMap<TerritorioDto, Territorio>();
        }
    }
}