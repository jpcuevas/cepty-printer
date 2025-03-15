using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class ShiftDetail
{
    public Guid Id { get; set; }

    public Guid ShiftId { get; set; }

    public int TicketId { get; set; }

    public string Status { get; set; } = null!;

    public string PassangerName { get; set; } = null!;

    public Guid ClientDestination { get; set; }

    public string ClientType { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Comments { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Shift Shift { get; set; } = null!;

    public virtual ICollection<TicketDetail> TicketDetails { get; set; } = new List<TicketDetail>();
}
