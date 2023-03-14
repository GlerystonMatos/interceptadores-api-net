using Interceptadores.Auditoria.Context;
using Microsoft.EntityFrameworkCore.Design;

namespace Interceptadores.Data.Context
{
    public class AuditoriaDesignContext : IDesignTimeDbContextFactory<AuditoriaContext>
    {
        public AuditoriaContext CreateDbContext(string[] args)
            => new AuditoriaContext("Data Source=10.0.0.131\\SQLEXPRESS;Initial Catalog=InterceptadoresAuditoria;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=False");
    }
}