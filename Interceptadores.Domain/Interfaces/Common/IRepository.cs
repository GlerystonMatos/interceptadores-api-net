using System.Linq;

namespace Interceptadores.Domain.Interfaces.Common
{
    public interface IRepository<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}