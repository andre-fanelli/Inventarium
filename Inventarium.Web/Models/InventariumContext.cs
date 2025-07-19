using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventariumWebApp.Models;

public partial class InventariumContext : DbContext
{
    public InventariumContext()
    {
    }

    public InventariumContext(DbContextOptions<InventariumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CadImpressora> CadImpressoras { get; set; }

    public virtual DbSet<CadMonitor> CadMonitors { get; set; }

    public virtual DbSet<CadNote> CadNotes { get; set; }

    public virtual DbSet<CadPc> CadPcs { get; set; }

    public virtual DbSet<CadRede> CadRedes { get; set; }

    public virtual DbSet<CadTablet> CadTablets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=PC01\\SQLEXPRESS;Database=Inventarium;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CadImpressora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cadImpre__3214EC27DE0EE400");

            entity.ToTable("cadImpressora");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Depto)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fabricante)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Ns)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NS");
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Unidade)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CadMonitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cadMonit__3214EC275A5D2762");

            entity.ToTable("cadMonitor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Depto)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fabricante)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Ns)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NS");
            entity.Property(e => e.Unidade)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CadNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cadNote__3214EC27763EFAE7");

            entity.ToTable("cadNote");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Depto)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Fabricante)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Hostname)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Ns)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NS");
            entity.Property(e => e.Processador)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ram).HasColumnName("RAM");
            entity.Property(e => e.So)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SO");
            entity.Property(e => e.Unidade)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CadPc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cadPC__3214EC2720EDD71D");

            entity.ToTable("cadPC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Depto)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fabricante)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Hostname)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Ns)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NS");
            entity.Property(e => e.Patrimonio)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Processador)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ram).HasColumnName("RAM");
            entity.Property(e => e.So)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SO");
            entity.Property(e => e.Unidade)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CadRede>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cadRede__3214EC27DBEC07A6");

            entity.ToTable("cadRede");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Depto)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fabricante)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Ns)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NS");
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Unidade)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CadTablet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cadTable__3214EC27DA06A619");

            entity.ToTable("cadTablet");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Depto)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fabricante)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Ns)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NS");
            entity.Property(e => e.Unidade)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
