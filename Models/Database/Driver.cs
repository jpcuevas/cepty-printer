using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class Driver
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string Status { get; set; } = null!;

    public string IdentificationCard { get; set; } = null!;

    public string IdentificationType { get; set; } = null!;

    public string? License { get; set; }

    public DateTime? Birthday { get; set; }

    public string Gender { get; set; } = null!;

    public Guid? BusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Bus? Bus { get; set; }

    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();

    public virtual ICollection<ShiftAssignment> ShiftAssignments { get; set; } = new List<ShiftAssignment>();
}
