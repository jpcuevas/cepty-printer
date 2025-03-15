using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class Configuration
{
    public Guid Id { get; set; }

    public string Value { get; set; } = null!;

    public int ConfigurationType { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
