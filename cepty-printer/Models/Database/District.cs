using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class District
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid ProvinceId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Province Province { get; set; } = null!;
}
