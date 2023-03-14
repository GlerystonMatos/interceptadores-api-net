using Interceptadores.Domain.Tenant;

namespace Interceptadores.Domain.Interfaces.Services
{
    public interface ITenantService
    {
        TenantConfiguration Get();

        void Set(TenantConfiguration tenant);
    }
}