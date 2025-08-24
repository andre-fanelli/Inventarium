using Humanizer.Localisation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Resources.Models;

namespace InventariumWebApp.Models;

public partial class CadPc
{
    public int Id { get; set; }

    public string TenantId { get; set; }

    [Display(Name = "Unidade", ResourceType = typeof(Resources.Models.CadPc))]
    public string Unidade { get; set; } = null!;

    [Display(Name = "Depto", ResourceType = typeof(Resources.Models.CadPc))]
    public string Depto { get; set; } = null!;

    [Display(Name = "Processador", ResourceType = typeof(Resources.Models.CadPc))]
    public string Processador { get; set; } = null!;

    public string? Ram { get; set; }

    [Display(Name = "Storage", ResourceType = typeof(Resources.Models.CadPc))]
    public string? Storage { get; set; }

    [Display(Name = "Hostname", ResourceType = typeof(Resources.Models.CadPc))]
    public string Hostname { get; set; } = null!;

    [Display(Name = "Fabricante", ResourceType = typeof(Resources.Models.CadPc))]
    public string Fabricante { get; set; } = null!;

    [Display(Name = "Modelo", ResourceType = typeof(Resources.Models.CadPc))]
    public string Modelo { get; set; } = null!;

    [Display(Name = "Ns", ResourceType = typeof(Resources.Models.CadPc))]
    public string Ns { get; set; } = null!;

    [Display(Name = "Patrimonio", ResourceType = typeof(Resources.Models.CadPc))]
    public string? Patrimonio { get; set; }

    [Display(Name = "So", ResourceType = typeof(Resources.Models.CadPc))]
    public string So { get; set; } = null!;
}
