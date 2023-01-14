using Interceptadores.Api.Security;
using Interceptadores.Domain.Dto;
using Interceptadores.Domain.Exception;
using Interceptadores.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Interceptadores.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IUsuarioService usuarioService, ILogger<LoginController> logger)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Autenticar usuário da naja
        /// </summary>
        /// <param name="login"></param>
        /// <response code="200">Usuário autenticado.</response>
        /// <response code="400">Usuário não autenticado.</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("Authenticate")]
        [ProducesResponseType(typeof(TokenDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Authenticate([FromBody] LoginDto login)
        {
            UsuarioDto usuarioDto = _usuarioService.ObterUsuarioParaAutenticacao(login);
            _logger.LogInformation("Login realizado: " + usuarioDto.Nome);

            return Ok(new TokenDto(AccessToken.GenerateToken(usuarioDto)));
        }

        /// <summary>
        /// Verificar o usuário autenticado.
        /// </summary>
        /// <response code="200">Usuário autenticado.</response>
        /// <response code="400">Usuário não autenticado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet]
        [Authorize]
        [Route("Authenticated")]
        [ProducesResponseType(typeof(ExceptionMessage), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Authenticated()
            => Ok(new ExceptionMessage(string.Format("Usuário autenticado - {0}", User.Identity.Name)));
    }
}