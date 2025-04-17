using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class ShipmentPackage
{
    public Guid Id { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Provider { get; set; }

    public string? ProviderName { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
