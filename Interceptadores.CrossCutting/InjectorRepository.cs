using Interceptadores.Data.Repositories;
using Interceptadores.Domain.Interfaces.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Interceptadores.CrossCutting
{
    public static class InjectorRepository
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}