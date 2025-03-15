using cepty_printer.Models;
using cepty_printer.Models.Database;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace cepty_printer.Activity
{
    public class PrintTicketActivity : IActivity<PrintTicketArguments, PrintTicketLog>
    {
        private readonly ILogger<PrintTicketActivity> _logger;
        private readonly IPanamaBusTicketsContext _context;
        public PrintTicketActivity(
            ILogger<PrintTicketActivity> logger,
            IPanamaBusTicketsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ExecutionResult> Execute(ExecuteContext<PrintTicketArguments> context)
        {
            foreach (var shiftDetailId in context.Arguments.ShiftDetailId)
            {
                // Lógica para imprimir el boleto
                var logData = new Dictionary<string, object>
                {
                    { "ShiftDetailId", shiftDetailId },
                };
                _logger.LogInformation("Received CreateTicketActivity: {@LogData}", logData);
                var ticketToPrint = _context.TicketDetails.FirstOrDefault(x => x.ShiftDetailId == shiftDetailId);
                var shiftDetail = _context.ShiftDetails.FirstOrDefault(x => x.Id == shiftDetailId);
                await Task.Delay(3000);
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
            }

            return context.Completed();
        }

        public async Task<CompensationResult> Compensate(CompensateContext<PrintTicketLog> context)
        {
            // Lógica para compensar la impresión del boleto
            await Console.Out.WriteLineAsync($"Compensating Ticket Printing: {context.Log.TicketId}");

            return context.Compensated();
        }
    }
}