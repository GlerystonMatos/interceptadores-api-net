using Interceptadores.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Interceptadores.CrossCutting
{
    public static class InjectorDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddDbContext<InterceptadoresContext>();
            services.RegisterRepository();
            services.RegisterService();
        }
    }
}