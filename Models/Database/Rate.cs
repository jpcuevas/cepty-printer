using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class Rate
{
    public Guid Id { get; set; }

    public Guid OriginId { get; set; }

    public Guid DestinyId { get; set; }

    public string StopName { get; set; } = null!;

    public int Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Province Destiny { get; set; } = null!;

    public virtual Province Origin { get; set; } = null!;

    public virtual ICollection<RatePrice> RatePrices { get; set; } = new List<RatePrice>();
}
