using API.DTOs;
using API.Entities;

namespace API.MappingProfiles
{
    public class ProdutoProfile : AutoMapper.Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDto>();
            CreateMap<ProdutoDto, Produto>();
        }
    }
}