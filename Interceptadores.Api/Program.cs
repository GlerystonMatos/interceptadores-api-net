using Interceptadores.Auditoria.Context;
using Interceptadores.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Interceptadores.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                InterceptadoresContext db = scope.ServiceProvider.GetRequiredService<InterceptadoresContext>();
                db.Database.Migrate();

                AuditoriaContext dba = new AuditoriaContext("Data Source=DESKTOP-STV0UEG\\SQLEXPRESS;Initial Catalog=InterceptadoresAuditoria;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=False");
                dba.Database.Migrate();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}