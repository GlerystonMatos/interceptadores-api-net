using Interceptadores.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Interceptadores.Data.Context
{
    public class DesignInterceptadoresContext : IDesignTimeDbContextFactory<InterceptadoresContext>
    {
        public InterceptadoresContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<InterceptadoresContext> builder = new DbContextOptionsBuilder<InterceptadoresContext>();
            builder.UseSqlServer("Data Source=10.0.0.131\\SQLEXPRESS;Initial Catalog=Interceptadores;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=False");
            return new InterceptadoresContext(builder.Options, new TenantService(), null);
        }
    }
}