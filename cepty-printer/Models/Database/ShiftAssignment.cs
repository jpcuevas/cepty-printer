using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class ShiftAssignment
{
    public Guid Id { get; set; }

    public Guid ShiftId { get; set; }

    public Guid BusId { get; set; }

    public Guid DriverId { get; set; }

    public DateTime AssignedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Bus Bus { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual Shift Shift { get; set; } = null!;
}
