using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class VendorInvoiceDetail
{
    public Guid Id { get; set; }

    public Guid VendorInvoiceId { get; set; }

    public string? InvoiceType { get; set; }

    public string? PackageCode { get; set; }

    public decimal Long { get; set; }

    public decimal High { get; set; }

    public decimal Width { get; set; }

    public decimal Weight { get; set; }

    public decimal Volumen { get; set; }

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual VendorInvoice VendorInvoice { get; set; } = null!;
}
