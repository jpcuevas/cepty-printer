using cepty_printer.Models;
using cepty_printer.Models.Database;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace cepty_printer.ServiceBus.Consumer
{
    public class PrintTicketConsumer : IConsumer<PrintTicketsMessage>
    {
        private readonly ILogger<PrintTicketConsumer> _logger;
        private readonly IPanamaBusTicketsContext _context;


        public PrintTicketConsumer(
            ILogger<PrintTicketConsumer> logger,
            IPanamaBusTicketsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Consume(ConsumeContext<PrintTicketsMessage> context)
        {
            try
            {
                foreach (var shiftDetailId in context.Message.ShiftDetailId)
                {
                    // Lógica para imprimir el boleto
                    var logData = new Dictionary<string, object>
                    {
                        { "ShiftDetailId", shiftDetailId },
                    };
                    _logger.LogInformation("Received CreateTicketActivity: {@LogData}", logData);
                    var ticketToPrint = _context.TicketDetails.FirstOrDefault(x => x.ShiftDetailId == shiftDetailId);
                    var shiftDetail = _context.ShiftDetails.FirstOrDefault(x => x.Id == shiftDetailId);
                    _logger.LogInformation("Waiting for 4 seconds to simulate printing...");
                    await Task.Delay(4000);
                    _logger.LogInformation($"print this ticket: {shiftDetailId}");
                    logData["TicketId"] = ticketToPrint!.TicketId;
                    logData["TicketType"] = ticketToPrint!.TicketType!;
                    logData["PassangerName"] = ticketToPrint!.PassangerName!;
                    logData["ShiftDetailId"] = ticketToPrint!.ShiftDetailId;
                    logData["StopName"] = ticketToPrint!.StopName!;
                    logData["DestinationName"] = ticketToPrint!.DestinationName!;
                    logData["OriginName"] = ticketToPrint!.OriginName!;
                    logData["Price"] = ticketToPrint.Price;
                    logData["CreatedAt"] = ticketToPrint.CreatedAt;
                    logData["User"] = ticketToPrint!.CreatedBy!;
                    _logger.LogInformation("print this ticket{@LogData}", logData);
                    ticketToPrint.Printed = true;
                    shiftDetail!.TicketId = ticketToPrint.TicketId;
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Received Message: {@LogData}", logData);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }

    public class PrintTicketsMessage
    {
        public Guid[] ShiftDetailId { get; }
    }

}