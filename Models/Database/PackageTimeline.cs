using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class PackageTimeline
{
    public Guid Id { get; set; }

    public string? PackageCode { get; set; }

    public string? Title { get; set; }

    public string? Step { get; set; }

    public string? TitleUrl { get; set; }

    public string? Body { get; set; }

    public string? NextStep { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
