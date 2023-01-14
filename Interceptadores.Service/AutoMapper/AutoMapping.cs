using AutoMapper;
using Interceptadores.Domain.Dto;
using Interceptadores.Domain.Entities;

namespace Interceptadores.Service.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Animal, AnimalDto>()
                .ReverseMap();

            CreateMap<Usuario, UsuarioDto>()
                .ReverseMap();
        }
    }
}