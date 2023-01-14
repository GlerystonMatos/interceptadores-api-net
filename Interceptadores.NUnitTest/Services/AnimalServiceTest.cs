using AutoMapper;
using Interceptadores.Domain.Dto;
using Interceptadores.Domain.Entities;
using Interceptadores.Domain.Interfaces.Data;
using Interceptadores.Domain.Interfaces.Services;
using Interceptadores.NUnitTest.Common;
using Interceptadores.Service.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interceptadores.NUnitTest.Services
{
    public class AnimalServiceTest
    {
        private Animal _animal;
        private IMapper _mapper;
        private IAnimalService _animalService;
        private Mock<IAnimalRepository> _mockAnimalRepository;

        public AnimalServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _animal = new Animal(Guid.NewGuid(), "Cachorro");
            _mockAnimalRepository = new Mock<IAnimalRepository>();
            _animalService = new AnimalService(_mapper, _mockAnimalRepository.Object);
        }

        [Test]
        public void CriarComConstrutorTest()
            => Assert.IsNotNull(new AnimalDto());

        [Test]
        public void ObterTodosTest()
        {
            IList<Animal> animalsList = new List<Animal>();
            animalsList.Add(_animal);

            _mockAnimalRepository.Setup(r => r.ObterTodos()).Returns(animalsList.AsQueryable());
            Assert.IsNotNull(_animalService.ObterTodos());
        }
    }
}