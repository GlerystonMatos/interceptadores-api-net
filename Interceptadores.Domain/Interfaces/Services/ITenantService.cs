using Interceptadores.Domain.Tenant;

namespace Interceptadores.Domain.Interfaces.Services
{
    public interface ITenantService
    {
        TenantConfiguration Get();

        string GetUser();

        void Set(TenantConfiguration tenant);

        void SetUser(string user);
    }
}