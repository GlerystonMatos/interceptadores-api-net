using AutoMapper;
using AutoMapper.QueryableExtensions;
using Interceptadores.Domain.Dto;
using Interceptadores.Domain.Interfaces.Data;
using Interceptadores.Domain.Interfaces.Services;
using System.Linq;

namespace Interceptadores.Service.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IMapper mapper, IAnimalRepository animalRepository)
        {
            _mapper = mapper;
            _animalRepository = animalRepository;
        }

        public IQueryable<AnimalDto> ObterTodos()
            => _animalRepository.ObterTodos().ProjectTo<AnimalDto>(_mapper.ConfigurationProvider);
    }
}