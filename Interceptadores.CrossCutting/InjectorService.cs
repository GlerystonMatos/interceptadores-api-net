using Interceptadores.Domain.Interfaces.Services;
using Interceptadores.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Interceptadores.CrossCutting
{
    public static class InjectorService
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}