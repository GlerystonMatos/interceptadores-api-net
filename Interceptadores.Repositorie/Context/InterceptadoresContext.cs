using Interceptadores.Auditoria.Interceptor;
using Interceptadores.Data.Configuration;
using Interceptadores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Interceptadores.Data.Context
{
    public class InterceptadoresContext : DbContext
    {
        private readonly AuditoriaInterceptor _auditoriaInterceptor;

        public InterceptadoresContext(DbContextOptions<InterceptadoresContext> options) : base(options)
            => _auditoriaInterceptor = new AuditoriaInterceptor("Data Source=DESKTOP-STV0UEG\\SQLEXPRESS;Initial Catalog=InterceptadoresAuditoria;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=False");

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
            => builder.AddInterceptors(_auditoriaInterceptor);
    }
}