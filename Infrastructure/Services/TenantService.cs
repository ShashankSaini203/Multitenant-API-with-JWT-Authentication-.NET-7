using Core.Interfaces;
using Core.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    //Objective of this TenantService is to study the HTTP request header via "contextAccessor" and find which Tenant has been requested. Then set that tenant as Current_Tenant
    //Once the correct Tenant is set, we can fetch other details w.r.t that tenant
    public class TenantService : ITenantService
    {
        private readonly TenantSetting _tenantSettings;
        private HttpContext _httpContext;
        private Tenant _currentTenant;
        public TenantService(IOptions<TenantSetting> tenantSettings, IHttpContextAccessor contextAccessor)
        {
            _tenantSettings = tenantSettings.Value;
            _httpContext = contextAccessor.HttpContext;
            if (_httpContext != null)
            {
                if (_httpContext.Request.Headers.TryGetValue("tenant", out var tenant))
                {
                    int? tenantId = _tenantSettings.Tenants.FirstOrDefault(t => t.TenantName.ToLower() == tenant.ToString().ToLower()).TenantId;
                    if (tenantId == null) throw new Exception("Invalid Tenant!");
                    else SetTenant(Convert.ToInt32(tenantId));
                }
                else
                {
                    throw new Exception("Invalid Tenant!");
                }
            }
        }
        private void SetTenant(int tenantId)
        {
            _currentTenant = _tenantSettings.Tenants.Where(a => a.TenantId == tenantId).FirstOrDefault();
            if (string.IsNullOrEmpty(_currentTenant.TenantConnectionString))
            {
                SetDefaultConnectionStringToCurrentTenant();
            }
        }
        private void SetDefaultConnectionStringToCurrentTenant()
        {
            _currentTenant.TenantConnectionString = _tenantSettings.Default.DefaultConnectionString;
        }
        public string GetConnectionString()
        {
            return _currentTenant?.TenantConnectionString;
        }

        public string GetDbProvider()
        {
            return _tenantSettings.Default?.DBProvider;
        }

        public Tenant GetTenant()
        {
            return _currentTenant;
        }
    }
}
