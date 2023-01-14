using Interceptadores.Domain.Entities;
using Interceptadores.Domain.Interfaces.Common;

namespace Interceptadores.Domain.Interfaces.Data
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario PesquisarPorLoginSenha(string login, string senha);
    }
}