using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class CustomerLocker
{
    public Guid Id { get; set; }

    public int LockerId { get; set; }

    public string? LockerCode { get; set; }

    public string Name { get; set; } = null!;

    public string? LockerStatus { get; set; }

    public string? Phone { get; set; }

    public string? Ruc { get; set; }

    public string? Email { get; set; }

    public Guid? AssignedUser { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Provider { get; set; }

    public string? ProviderName { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
