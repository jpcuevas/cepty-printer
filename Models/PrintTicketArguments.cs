namespace cepty_printer.Models
{
    public interface PrintTicketArguments
    {
        public Guid[] ShiftDetailId { get; }
    }

    public interface PrintTicketLog
    {
        Guid TicketId { get; }
    }


}