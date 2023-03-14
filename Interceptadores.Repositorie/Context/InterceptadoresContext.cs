using Interceptadores.Auditoria.Interceptor;
using Interceptadores.Data.Configuration;
using Interceptadores.Domain.Entities;
using Interceptadores.Domain.Interfaces.Services;
using Interceptadores.Domain.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Interceptadores.Data.Context
{
    public class InterceptadoresContext : DbContext
    {
        private readonly ITenantService _tenantService;
        private AuditoriaInterceptor _auditoriaInterceptor;
        private readonly ILogger<InterceptadoresContext> _logger;

        public InterceptadoresContext(DbContextOptions<InterceptadoresContext> options, ITenantService tenantService,
            ILogger<InterceptadoresContext> logger) : base(options)
        {
            _logger = logger;
            _tenantService = tenantService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AnimalConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());

            IList<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario(Guid.Parse("d78a657f-66fa-43f2-a535-212e6bfb6630"), "Teste 01", "Teste01", "1234"));
            usuarios.Add(new Usuario(Guid.Parse("10b42acc-45bd-460a-9edd-d568ff236e37"), "Teste 02", "Teste02", "4567"));

            modelBuilder.Entity<Usuario>().HasData(usuarios);

            IList<Animal> animais = new List<Animal>();
            animais.Add(new Animal(Guid.Parse("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d003b"), "Cachorro"));
            animais.Add(new Animal(Guid.Parse("8b5c8482-f2ec-4cf6-aaa8-20ec25112cd7"), "Hamster"));

            modelBuilder.Entity<Animal>().HasData(animais);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            TenantConfiguration configuration = _tenantService.Get();
            if (configuration != null)
            {
                _auditoriaInterceptor = new AuditoriaInterceptor(configuration.ConnectionStringAuditoria);

                builder.AddInterceptors(_auditoriaInterceptor);
                builder.UseSqlServer(configuration.ConnectionStringDados);

                _logger.LogInformation("ConnectionStringDados: " + configuration.ConnectionStringDados);
                _logger.LogInformation("ConnectionStringAuditoria: " + configuration.ConnectionStringAuditoria);
            }
        }
    }
}