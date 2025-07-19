using System;
using System.Collections.Generic;

namespace InventariumWebApp.Models;

public partial class CadNote
{
    public string Unidade { get; set; } = null!;

    public string Depto { get; set; } = null!;

    public string Processador { get; set; } = null!;

    public string? Ram { get; set; }

    public string? Storage { get; set; }

    public string Hostname { get; set; } = null!;

    public string Fabricante { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Ns { get; set; } = null!;

    public string? Patrimonio { get; set; }

    public string So { get; set; } = null!;

    public int Id { get; set; }

    public string TenantId { get; set; }
}
