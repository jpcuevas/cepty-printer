namespace cepty_printer.ServiceBus.Consumer
{
    public class PrintTicketsMessage
    {
        public Guid[] ShiftDetailId { get; init; }
    }

}