using Microsoft.EntityFrameworkCore;

namespace cepty_printer.Models.Database
{
    public interface IPanamaBusTicketsContext
    {

        DbSet<Profile> Profiles { get; set; }
        DbSet<Bus> Buses { get; set; }
        DbSet<Driver> Drivers { get; set; }

        DbSet<Province> Provinces { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<Shift> Shifts { get; set; }
        DbSet<ShiftDetail> ShiftDetails { get; set; }
        DbSet<ShiftAssignment> ShiftAssignments { get; set; }
        DbSet<TicketDetail> TicketDetails { get; set; }
        DbSet<Rate> Rates { get; set; }
        DbSet<RatePrice> RatePrices { get; set; }
        DbSet<Configuration> Configurations { get; set; }



        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}