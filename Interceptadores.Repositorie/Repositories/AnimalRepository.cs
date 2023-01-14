using Interceptadores.Data.Common;
using Interceptadores.Data.Context;
using Interceptadores.Domain.Entities;
using Interceptadores.Domain.Interfaces.Data;

namespace Interceptadores.Data.Repositories
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(InterceptadoresContext context) : base(context)
        {
        }
    }
}