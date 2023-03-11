using Interceptadores.Auditoria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interceptadores.Auditoria.Configuration
{
    public class SaveChangesAuditConfig : IEntityTypeConfiguration<SaveChangesAudit>
    {
        public void Configure(EntityTypeBuilder<SaveChangesAudit> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.AuditId).IsRequired();
            builder.Property(a => a.EndTime).IsRequired();
            builder.Property(a => a.Succeeded).IsRequired();
            builder.Property(a => a.StartTime).IsRequired();
            builder.Property(a => a.ErrorMessage).IsRequired();
        }
    }
}