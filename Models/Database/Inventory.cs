using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class Inventory
{
    public Guid Id { get; set; }

    public Guid? VendorInvoiceId { get; set; }

    public Guid? InvoiceId { get; set; }

    public Guid? CustomerLockerId { get; set; }

    public Guid? ShipmentId { get; set; }

    public string? TrackingId { get; set; }

    public decimal PackagePrice { get; set; }

    public decimal CeptyPackagePrice { get; set; }

    public decimal PackageLength { get; set; }

    public decimal PackageHeight { get; set; }

    public decimal PackageWidth { get; set; }

    public decimal PackageWeight { get; set; }

    public decimal LocalPackageWeight { get; set; }

    public decimal PackageVolume { get; set; }

    public decimal CeptyShipping { get; set; }

    public string? Status { get; set; }

    public string? Provider { get; set; }

    public string? ProviderName { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual CustomerLocker? CustomerLocker { get; set; }

    public virtual Invoice? Invoice { get; set; }

    public virtual ShipmentPackage? Shipment { get; set; }

    public virtual VendorInvoice? VendorInvoice { get; set; }
}
