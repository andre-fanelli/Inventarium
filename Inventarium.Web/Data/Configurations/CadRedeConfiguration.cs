using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InventariumWebApp.Models;

public class CadRedeConfiguration : IEntityTypeConfiguration<CadRede>
{
    public void Configure(EntityTypeBuilder<CadRede> entity)
    {
        entity.HasKey(e => e.Id);
        entity.ToTable("cadRede");

        entity.Property(e => e.Id).HasColumnName("ID");
        entity.Property(e => e.Unidade).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Depto).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Tipo).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Modelo).HasMaxLength(30).IsUnicode(false);
        entity.Property(e => e.Ns).HasMaxLength(20).IsUnicode(false).HasColumnName("NS");
        entity.Property(e => e.Patrimonio).HasMaxLength(30);
        entity.Property(e => e.TenantId).IsRequired();
    }
}
