using Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITenantService
    {
        public string GetDbProvider();
        public string GetConnectionString();
        public Tenant GetTenant();
    }
}
