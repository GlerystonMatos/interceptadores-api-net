﻿using Interceptadores.Domain.Interfaces.Services;
using Interceptadores.Domain.Tenant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Interceptadores.Api.Middleware
{
    public class TenantMiddleware : IAuthorizationHandler
    {
        private readonly ITenantService _tenantService;
        private readonly ILogger<TenantMiddleware> _logger;
        private readonly IOptions<TenantConfigurationSection> _options;

        public TenantMiddleware(ITenantService tenantService, ILogger<TenantMiddleware> logger, IOptions<TenantConfigurationSection> options)
        {
            _logger = logger;
            _options = options;
            _tenantService = tenantService;
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            string user = "";
            TenantConfiguration tenant = _options.Value.Tenants.Where(t => t.Name.Equals("Tenant00")).SingleOrDefault();

            Claim clain = context.User.Claims.Where(c => c.Type.Equals("tenant")).SingleOrDefault();
            if (clain != null)
            {
                tenant = _options.Value.Tenants.Where(t => t.Name.Equals(clain.Value)).SingleOrDefault();
            }

            clain = context.User.Claims.Where(c => c.Type.Equals(ClaimTypes.Name)).SingleOrDefault();
            if (clain != null)
            {
                user = clain.Value;
            }

            _tenantService.Set(tenant);
            _tenantService.SetUser(user);
            _logger.LogInformation("User: " + user);
            _logger.LogInformation("Tenant: " + tenant.Name);

            return Task.CompletedTask;
        }
    }
}