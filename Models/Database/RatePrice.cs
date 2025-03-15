using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class RatePrice
{
    public Guid Id { get; set; }

    public Guid RateId { get; set; }

    public int RateType { get; set; }

    public int Status { get; set; }

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Rate Rate { get; set; } = null!;
}
