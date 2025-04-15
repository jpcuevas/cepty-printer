using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class Bus
{
    public Guid Id { get; set; }

    public int BusNumber { get; set; }

    public string TransportRegistry { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public string? LicensePlate { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public string? BrandCode { get; set; }

    public string? ModelCode { get; set; }

    public int SeatNumbers { get; set; }

    public string? Color { get; set; }

    public int ModelYear { get; set; }

    public string Status { get; set; } = null!;

    public string? OwnershipType { get; set; }

    public string? Category { get; set; }

    public Guid? DriverId { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public virtual ICollection<ShiftAssignment> ShiftAssignments { get; set; } = new List<ShiftAssignment>();

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
}
