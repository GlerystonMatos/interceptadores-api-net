using System;
using System.Linq;

namespace Interceptadores.Domain.Interfaces.Common
{
    public interface IRepository<TModel>
    {
        void Criar(TModel model);

        void Atualizar(TModel model);

        void Remover(TModel model);

        TModel PesquisarPorId(Guid id);

        IQueryable<TModel> ObterTodos();
    }
}