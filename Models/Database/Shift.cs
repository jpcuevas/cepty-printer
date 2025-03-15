using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class Shift
{
    public Guid Id { get; set; }

    public int ShiftNumber { get; set; }

    public DateTime ShiftStart { get; set; }

    public DateTime? ShiftEnd { get; set; }

    public string Status { get; set; } = null!;

    public Guid BusId { get; set; }

    public Guid OriginId { get; set; }

    public Guid DestinationId { get; set; }

    public int TicketsSold { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Bus Bus { get; set; } = null!;

    public virtual Province Destination { get; set; } = null!;

    public virtual Province Origin { get; set; } = null!;

    public virtual ICollection<ShiftAssignment> ShiftAssignments { get; set; } = new List<ShiftAssignment>();

    public virtual ICollection<ShiftDetail> ShiftDetails { get; set; } = new List<ShiftDetail>();
}
