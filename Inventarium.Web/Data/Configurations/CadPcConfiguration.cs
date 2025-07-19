using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InventariumWebApp.Models;

public class CadPcConfiguration : IEntityTypeConfiguration<CadPc>
{
    public void Configure(EntityTypeBuilder<CadPc> entity)
    {
        entity.HasKey(e => e.Id);
        entity.ToTable("cadPC");

        entity.Property(e => e.Id).HasColumnName("ID");
        entity.Property(e => e.Unidade).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Depto).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Processador).HasMaxLength(50).IsUnicode(false);
        entity.Property(e => e.Ram).HasMaxLength(10).HasColumnName("RAM");
        entity.Property(e => e.Storage).HasMaxLength(20);
        entity.Property(e => e.Hostname).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Fabricante).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Modelo).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Ns).HasMaxLength(20).IsUnicode(false).HasColumnName("NS");
        entity.Property(e => e.Patrimonio).HasMaxLength(30);
        entity.Property(e => e.So).HasMaxLength(50).IsUnicode(false).HasColumnName("SO");
        entity.Property(e => e.TenantId).IsRequired();
    }
}
