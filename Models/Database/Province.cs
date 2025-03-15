using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class Province
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Number { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual ICollection<Rate> RateDestinies { get; set; } = new List<Rate>();

    public virtual ICollection<Rate> RateOrigins { get; set; } = new List<Rate>();

    public virtual ICollection<Shift> ShiftDestinations { get; set; } = new List<Shift>();

    public virtual ICollection<Shift> ShiftOrigins { get; set; } = new List<Shift>();
}
