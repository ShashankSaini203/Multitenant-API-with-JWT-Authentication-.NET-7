using System.Collections.Generic;

namespace Core.Settings
{
    public class TenantSetting
    {
        public DeafultConfiguration Default { get; set; }
        public List<Tenant> Tenants { get; set; }
    }

    public class DeafultConfiguration
    {
        public string DBProvider { get; set; }
        public string DefaultConnectionString { get; set; }
    }

    public class Tenant
    {
        public string TenantName { get; set; }
        public int TenantId { get; set; }
        public string TenantConnectionString { get; set; }

    }
}

