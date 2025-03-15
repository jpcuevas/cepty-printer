using System;
using System.Collections.Generic;

namespace cepty_printer.Models.Database;

public partial class TicketDetail
{
    public Guid Id { get; set; }

    public Guid ShiftDetailId { get; set; }

    public int TicketId { get; set; }

    public string? PassangerName { get; set; }

    public string? StopName { get; set; }

    public string? OriginName { get; set; }

    public string? DestinationName { get; set; }

    public string? User { get; set; }

    public DateTime Created { get; set; }

    public string? TicketType { get; set; }

    public decimal Price { get; set; }

    public bool Printed { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ShiftDetail ShiftDetail { get; set; } = null!;
}
