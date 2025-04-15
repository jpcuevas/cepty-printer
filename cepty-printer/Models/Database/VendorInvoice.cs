using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class VendorInvoice
{
    public Guid Id { get; set; }

    public string? InvoiceId { get; set; }

    public string? InvoiceStatus { get; set; }

    public decimal TotalInvociePrice { get; set; }

    public DateTime InvoiceDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string? Provider { get; set; }

    public string? ProviderName { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<VendorInvoiceDetail> VendorInvoiceDetails { get; set; } = new List<VendorInvoiceDetail>();
}
