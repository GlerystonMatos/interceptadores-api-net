using System.Linq;

namespace Interceptadores.Domain.Interfaces.Common
{
    public interface IService<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}