using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InventariumWebApp.Models;

public class CadMonitorConfiguration : IEntityTypeConfiguration<CadMonitor>
{
    public void Configure(EntityTypeBuilder<CadMonitor> entity)
    {
        entity.HasKey(e => e.Id);
        entity.ToTable("cadMonitor");

        entity.Property(e => e.Id).HasColumnName("ID");
        entity.Property(e => e.Unidade).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Depto).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Fabricante).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Modelo).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Ns).HasMaxLength(20).IsUnicode(false).HasColumnName("NS");
        entity.Property(e => e.Patrimonio).HasMaxLength(30);
        entity.Property(e => e.TenantId).IsRequired();
    }
}
