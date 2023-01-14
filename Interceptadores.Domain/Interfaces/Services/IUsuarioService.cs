using Interceptadores.Domain.Dto;
using Interceptadores.Domain.Interfaces.Common;

namespace Interceptadores.Domain.Interfaces.Services
{
    public interface IUsuarioService : IService<UsuarioDto>
    {
        UsuarioDto ObterUsuarioParaAutenticacao(LoginDto loginDto);
    }
}