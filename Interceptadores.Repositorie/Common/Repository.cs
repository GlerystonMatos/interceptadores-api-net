using Interceptadores.Data.Context;
using Interceptadores.Domain.Entities;
using Interceptadores.Domain.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Interceptadores.Data.Common
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : Entity
    {
        protected readonly InterceptadoresContext _context;

        public Repository(InterceptadoresContext context)
            => _context = context;

        public void Criar(TModel model)
        {
            _context.Set<TModel>().Add(model);
            _context.SaveChanges();
        }

        public void Atualizar(TModel model)
        {
            _context.Set<TModel>().Update(model);
            _context.SaveChanges();
        }

        public void Remover(TModel model)
        {
            _context.Set<TModel>().Remove(model);
            _context.SaveChanges();
        }

        public TModel PesquisarPorId(Guid id)
            => _context.Set<TModel>().Where(t => t.Id.Equals(id)).AsNoTracking().FirstOrDefault();

        public virtual IQueryable<TModel> ObterTodos()
            => _context.Set<TModel>().AsNoTracking().AsQueryable();
    }
}