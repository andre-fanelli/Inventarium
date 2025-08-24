using System;
using System.Collections.Generic;
using InventariumWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Inventarium.Web.Services;

namespace InventariumWebApp.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual DbSet<CadImpressora> Printers { get; set; }
        public virtual DbSet<CadMonitor> Displays { get; set; }
        public virtual DbSet<CadNote> Notebooks { get; set; }
        public virtual DbSet<CadPc> Computers { get; set; }
        public virtual DbSet<CadRede> Networks { get; set; }
        public virtual DbSet<CadTablet> Tablets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use fallback se necessário, mas evite hardcoded
                optionsBuilder.UseSqlServer("ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Obter o TenantId diretamente das claims do usuário
            string? tenantId = null;
            if (_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true)
            {
                tenantId = _httpContextAccessor.HttpContext.User.FindFirst("TenantId")?.Value;
            }

            // Aplicar os filtros somente se o tenantId estiver disponível
            if (!string.IsNullOrEmpty(tenantId))
            {
                string finalTenantId = tenantId; // Capturar em variável local para uso nas expressões lambda
                modelBuilder.Entity<CadPc>().HasQueryFilter(e => e.TenantId == finalTenantId);
                modelBuilder.Entity<CadNote>().HasQueryFilter(e => e.TenantId == finalTenantId);
                modelBuilder.Entity<CadMonitor>().HasQueryFilter(e => e.TenantId == finalTenantId);
                modelBuilder.Entity<CadImpressora>().HasQueryFilter(e => e.TenantId == finalTenantId);
                modelBuilder.Entity<CadTablet>().HasQueryFilter(e => e.TenantId == finalTenantId);
                modelBuilder.Entity<CadRede>().HasQueryFilter(e => e.TenantId == finalTenantId);
            }

            modelBuilder.ApplyConfiguration(new CadPcConfiguration());
            modelBuilder.ApplyConfiguration(new CadNoteConfiguration());
            modelBuilder.ApplyConfiguration(new CadMonitorConfiguration());
            modelBuilder.ApplyConfiguration(new CadImpressoraConfiguration());
            modelBuilder.ApplyConfiguration(new CadRedeConfiguration());
            modelBuilder.ApplyConfiguration(new CadTabletConfiguration());
        }

        public string? GetCurrentTenantId()
        {
            if (_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated != true)
            {
                return null;
            }

            return _httpContextAccessor.HttpContext.User.FindFirst("TenantId")?.Value;
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}