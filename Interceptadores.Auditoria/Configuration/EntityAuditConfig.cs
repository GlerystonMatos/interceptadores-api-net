using Interceptadores.Auditoria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interceptadores.Auditoria.Configuration
{
    public class EntityAuditConfig : IEntityTypeConfiguration<EntityAudit>
    {
        public void Configure(EntityTypeBuilder<EntityAudit> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.State).IsRequired();
            builder.Property(a => a.AuditUser).IsRequired();
            builder.Property(a => a.AuditMessage).IsRequired();
            builder.Property(a => a.SaveChangesAuditId).IsRequired();
            builder.HasOne(a => a.SaveChangesAudit).WithMany(s => s.Entities).HasForeignKey(a => a.SaveChangesAuditId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}