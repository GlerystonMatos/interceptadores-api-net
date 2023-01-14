using Interceptadores.Data.Common;
using Interceptadores.Data.Context;
using Interceptadores.Domain.Entities;
using Interceptadores.Domain.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Interceptadores.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(InterceptadoresContext context) : base(context)
        {
        }

        public Usuario PesquisarPorLoginSenha(string login, string senha)
            => _context.Set<Usuario>().Where(u => u.Login.ToUpper().Equals(login.ToUpper()) && u.Senha.ToUpper()
            .Equals(senha.ToUpper())).AsNoTracking().FirstOrDefault();
    }
}