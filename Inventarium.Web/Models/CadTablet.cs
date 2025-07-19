using System;
using System.Collections.Generic;

namespace InventariumWebApp.Models;

public partial class CadTablet
{
    public string Unidade { get; set; } = null!;

    public string Depto { get; set; } = null!;

    public string Fabricante { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Ns { get; set; } = null!;

    public string? Patrimonio { get; set; }

    public int Id { get; set; }

    public string TenantId { get; set; }
}
