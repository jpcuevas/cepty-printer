using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class Invoice
{
    public Guid Id { get; set; }

    public string? InvoiceTo { get; set; }

    public long InvoiceId { get; set; }

    public string? InvoiceStatus { get; set; }

    public decimal TotalInvociePrice { get; set; }

    public DateTime InvoiceDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Provider { get; set; }

    public string? ProviderName { get; set; }

    public Guid CustomerLockerId { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
