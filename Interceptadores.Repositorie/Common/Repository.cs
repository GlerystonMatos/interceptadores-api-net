using Interceptadores.Data.Context;
using Interceptadores.Domain.Entities;
using Interceptadores.Domain.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Interceptadores.Data.Common
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : Entity
    {
        protected readonly InterceptadoresContext _context;

        public Repository(InterceptadoresContext context)
            => _context = context;

        public virtual IQueryable<TModel> ObterTodos()
            => _context.Set<TModel>().AsNoTracking().AsQueryable();
    }
}