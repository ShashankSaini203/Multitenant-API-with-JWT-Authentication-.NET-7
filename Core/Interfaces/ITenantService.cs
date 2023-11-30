using Core.Settings;

namespace Core.Interfaces
{
    public interface ITenantService
    {
        public string GetDbProvider();
        public string GetConnectionString();
        public Tenant GetTenant();
    }
}
