using Interceptadores.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Interceptadores.CrossCutting
{
    public static class InjectorDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services, string defaultConnection)
        {
            services.AddDbContext<InterceptadoresContext>(options => options.UseSqlServer(defaultConnection));
            services.RegisterRepository();
            services.RegisterService();
        }
    }
}