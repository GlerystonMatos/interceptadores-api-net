using Interceptadores.Domain.Entities;
using Interceptadores.Domain.Interfaces.Common;

namespace Interceptadores.Domain.Interfaces.Data
{
    public interface IAnimalRepository : IRepository<Animal>
    {
    }
}