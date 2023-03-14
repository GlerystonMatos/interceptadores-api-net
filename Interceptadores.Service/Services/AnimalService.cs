using AutoMapper;
using AutoMapper.QueryableExtensions;
using Interceptadores.Domain.Dto;
using Interceptadores.Domain.Entities;
using Interceptadores.Domain.Interfaces.Data;
using Interceptadores.Domain.Interfaces.Services;
using System;
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

        public void Criar(AnimalDto animal)
            => _animalRepository.Criar(_mapper.Map<Animal>(animal));

        public void Atualizar(AnimalDto animal)
            => _animalRepository.Atualizar(_mapper.Map<Animal>(animal));

        public void Remover(AnimalDto animal)
            => _animalRepository.Remover(_mapper.Map<Animal>(animal));

        public AnimalDto PesquisarPorId(Guid id)
            => _mapper.Map<AnimalDto>(_animalRepository.PesquisarPorId(id));

        public IQueryable<AnimalDto> ObterTodos()
            => _animalRepository.ObterTodos().ProjectTo<AnimalDto>(_mapper.ConfigurationProvider);
    }
}