using Interceptadores.Api.Security;
using Interceptadores.Domain.Dto;
using NUnit.Framework;

namespace Interceptadores.NUnitTest.Security
{
    public class AccessTokenTest
    {
        [Test]
        public void GenerateToken()
        {
            UsuarioDto usuarioDto = new UsuarioDto();
            usuarioDto.Senha = "123";
            usuarioDto.Nome = "Teste";
            usuarioDto.Login = "Teste";

            Assert.IsNotEmpty(AccessToken.GenerateToken(usuarioDto));
        }
    }
}