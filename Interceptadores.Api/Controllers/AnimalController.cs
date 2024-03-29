﻿using Interceptadores.Domain.Dto;
using Interceptadores.Domain.Exception;
using Interceptadores.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Linq;

namespace Interceptadores.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
            => _animalService = animalService;

        /// <summary>
        /// Consulta
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        [HttpGet]
        [EnableQuery()]
        [ProducesResponseType(typeof(IQueryable<AnimalDto>), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Get()
            => Ok(_animalService.ObterTodos());

        /// <summary>
        /// Criar
        /// </summary>
        /// <param name="animal"></param>
        /// <response code="200">Criado com sucesso.</response>
        /// <response code="400">Não foi possível criar.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Post(AnimalDto animal)
        {
            if (!ModelState.IsValid)
            {
                throw new InterceptadoresException("Os dados para criação são inválidos.");
            }

            _animalService.Criar(animal);
            return Ok();
        }

        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="animal"></param>
        /// <response code="200">Atualizado com sucesso.</response>
        /// <response code="400">Não foi possível atualizar.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Put(AnimalDto animal)
        {
            if (!ModelState.IsValid)
            {
                throw new InterceptadoresException("Os dados para atualização são inválidos.");
            }

            if ((animal.Id.ToString().Equals("")) || (_animalService.PesquisarPorId(animal.Id) == null))
            {
                return NotFound();
            }

            _animalService.Atualizar(animal);
            return Ok();
        }

        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Exclusão realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a exclusão.</response>
        /// <response code="404">Não localizado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Delete(Guid id)
        {
            AnimalDto animal = _animalService.PesquisarPorId(id);
            if (animal == null)
            {
                return NotFound();
            }

            _animalService.Remover(animal);
            return Ok();
        }
    }
}