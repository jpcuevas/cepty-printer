using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cepty_printer.Models.Database;

public partial class PanamaBusTicketsContext : DbContext, IPanamaBusTicketsContext
{
    public PanamaBusTicketsContext()
    {
    }

    public PanamaBusTicketsContext(DbContextOptions<PanamaBusTicketsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationUserProvider> ApplicationUserProviders { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<CustomerLocker> CustomerLockers { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<PackageTimeline> PackageTimelines { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<RatePrice> RatePrices { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShiftAssignment> ShiftAssignments { get; set; }

    public virtual DbSet<ShiftDetail> ShiftDetails { get; set; }

    public virtual DbSet<ShipmentPackage> ShipmentPackages { get; set; }

    public virtual DbSet<TicketDetail> TicketDetails { get; set; }

    public virtual DbSet<VendorInvoice> VendorInvoices { get; set; }

    public virtual DbSet<VendorInvoiceDetail> VendorInvoiceDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Cepty_DbDevelop_v2;Username=postgres;Password=Developer2020");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUserProvider>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CompanyId });

            entity.HasIndex(e => e.CompanyId, "IX_ApplicationUserProviders_CompanyId");

            entity.HasOne(d => d.Company).WithMany(p => p.ApplicationUserProviders).HasForeignKey(d => d.CompanyId);

            entity.HasOne(d => d.User).WithMany(p => p.ApplicationUserProviders).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Discriminator).HasMaxLength(21);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.ApplicationUserId, "IX_AspNetUserClaims_ApplicationUserId");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.AspNetUserClaimApplicationUsers).HasForeignKey(d => d.ApplicationUserId);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaimUsers).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasIndex(e => new { e.BusNumber, e.TransportRegistry }, "IX_Buses_BusNumber_TransportRegistry").IsUnique();

            entity.HasIndex(e => e.DriverId, "IX_Buses_DriverId");

            entity.HasIndex(e => e.LicensePlate, "IX_Buses_LicensePlate").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Brand).HasMaxLength(150);
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Bus'::character varying");
            entity.Property(e => e.Color).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.LicensePlate).HasMaxLength(20);
            entity.Property(e => e.Model).HasMaxLength(150);
            entity.Property(e => e.OwnershipType)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Commercial'::character varying");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Active'::character varying");
            entity.Property(e => e.TransportRegistry).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);

            entity.HasOne(d => d.Driver).WithMany(p => p.Buses).HasForeignKey(d => d.DriverId);
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.ToTable("Configuration");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerLocker>(entity =>
        {
            entity.HasIndex(e => new { e.LockerId, e.ProviderName }, "IX_CustomerLockers_LockerId_ProviderName").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.LockerCode)
                .HasMaxLength(150)
                .HasDefaultValueSql("'CE'::character varying");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);
            entity.Property(e => e.Ruc).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasIndex(e => e.ProvinceId, "IX_Districts_ProvinceId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Province).WithMany(p => p.Districts).HasForeignKey(d => d.ProvinceId);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasIndex(e => e.BusId, "IX_Drivers_BusId");

            entity.HasIndex(e => new { e.IdentificationType, e.IdentificationCard }, "IX_Drivers_IdentificationType_IdentificationCard").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.IdentificationCard).HasMaxLength(100);
            entity.Property(e => e.IdentificationType).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(150);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);

            entity.HasOne(d => d.Bus).WithMany(p => p.Drivers).HasForeignKey(d => d.BusId);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasIndex(e => e.CustomerLockerId, "IX_Inventories_CustomerLockerId");

            entity.HasIndex(e => e.InvoiceId, "IX_Inventories_InvoiceId");

            entity.HasIndex(e => e.ShipmentId, "IX_Inventories_ShipmentId");

            entity.HasIndex(e => e.VendorInvoiceId, "IX_Inventories_VendorInvoiceId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TrackingId).HasMaxLength(150);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);

            entity.HasOne(d => d.CustomerLocker).WithMany(p => p.Inventories).HasForeignKey(d => d.CustomerLockerId);

            entity.HasOne(d => d.Invoice).WithMany(p => p.Inventories).HasForeignKey(d => d.InvoiceId);

            entity.HasOne(d => d.Shipment).WithMany(p => p.Inventories).HasForeignKey(d => d.ShipmentId);

            entity.HasOne(d => d.VendorInvoice).WithMany(p => p.Inventories).HasForeignKey(d => d.VendorInvoiceId);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CustomerLockerId).HasColumnName("customerLockerId");
            entity.Property(e => e.InvoiceStatus).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasIndex(e => e.InvoiceId, "IX_InvoiceDetails_InvoiceId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.PackageCode).HasMaxLength(150);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceDetails).HasForeignKey(d => d.InvoiceId);
        });

        modelBuilder.Entity<PackageTimeline>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Body).HasMaxLength(300);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.NextStep).HasMaxLength(50);
            entity.Property(e => e.PackageCode).HasMaxLength(150);
            entity.Property(e => e.Step).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(150);
            entity.Property(e => e.TitleUrl).HasMaxLength(150);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(150);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Provider1).HasColumnName("Provider");
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.HasIndex(e => e.DestinyId, "IX_Rates_DestinyId");

            entity.HasIndex(e => e.OriginId, "IX_Rates_OriginId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.StopName).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);

            entity.HasOne(d => d.Destiny).WithMany(p => p.RateDestinies)
                .HasForeignKey(d => d.DestinyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Origin).WithMany(p => p.RateOrigins)
                .HasForeignKey(d => d.OriginId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<RatePrice>(entity =>
        {
            entity.HasIndex(e => e.RateId, "IX_RatePrices_RateId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.Price).HasPrecision(18, 2);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);

            entity.HasOne(d => d.Rate).WithMany(p => p.RatePrices).HasForeignKey(d => d.RateId);
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasIndex(e => e.BusId, "IX_Shifts_BusId");

            entity.HasIndex(e => e.DestinationId, "IX_Shifts_DestinationId");

            entity.HasIndex(e => e.OriginId, "IX_Shifts_OriginId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);

            entity.HasOne(d => d.Bus).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.BusId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Destination).WithMany(p => p.ShiftDestinations)
                .HasForeignKey(d => d.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Origin).WithMany(p => p.ShiftOrigins)
                .HasForeignKey(d => d.OriginId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ShiftAssignment>(entity =>
        {
            entity.HasIndex(e => e.BusId, "IX_ShiftAssignments_BusId");

            entity.HasIndex(e => e.DriverId, "IX_ShiftAssignments_DriverId");

            entity.HasIndex(e => e.ShiftId, "IX_ShiftAssignments_ShiftId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);

            entity.HasOne(d => d.Bus).WithMany(p => p.ShiftAssignments)
                .HasForeignKey(d => d.BusId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Driver).WithMany(p => p.ShiftAssignments)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Shift).WithMany(p => p.ShiftAssignments).HasForeignKey(d => d.ShiftId);
        });

        modelBuilder.Entity<ShiftDetail>(entity =>
        {
            entity.HasIndex(e => e.ShiftId, "IX_ShiftDetails_ShiftId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClientType).HasMaxLength(50);
            entity.Property(e => e.Comments).HasMaxLength(500);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.PassangerName).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);

            entity.HasOne(d => d.Shift).WithMany(p => p.ShiftDetails).HasForeignKey(d => d.ShiftId);
        });

        modelBuilder.Entity<ShipmentPackage>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);
        });

        modelBuilder.Entity<TicketDetail>(entity =>
        {
            entity.HasIndex(e => e.ShiftDetailId, "IX_TicketDetails_ShiftDetailId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.ShiftDetail).WithMany(p => p.TicketDetails).HasForeignKey(d => d.ShiftDetailId);
        });

        modelBuilder.Entity<VendorInvoice>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.InvoiceId).HasMaxLength(50);
            entity.Property(e => e.InvoiceStatus).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);
        });

        modelBuilder.Entity<VendorInvoiceDetail>(entity =>
        {
            entity.HasIndex(e => e.VendorInvoiceId, "IX_VendorInvoiceDetails_VendorInvoiceId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.InvoiceType).HasMaxLength(50);
            entity.Property(e => e.PackageCode).HasMaxLength(150);
            entity.Property(e => e.UpdatedBy).HasMaxLength(150);

            entity.HasOne(d => d.VendorInvoice).WithMany(p => p.VendorInvoiceDetails).HasForeignKey(d => d.VendorInvoiceId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
