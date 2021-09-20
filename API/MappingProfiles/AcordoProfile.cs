using System.Collections.Generic;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.MappingProfiles
{
    public class AcordoProfile : AutoMapper.Profile
    {
        public AcordoProfile()
        {
            CreateMap<Acordo, AcordoDto>();
            CreateMap<AcordoDto, Acordo>();

            // CreateMap<List<Acordo>, List<AcordoDto>>();
            // CreateMap<List<AcordoDto>, List<Acordo>>();
        }
    }
}