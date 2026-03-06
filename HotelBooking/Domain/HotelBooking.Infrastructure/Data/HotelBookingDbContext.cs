using Microsoft.EntityFrameworkCore;
using HotelBooking.Domain;

namespace HotelBooking.Infrastructure.Data;

public class HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : DbContext(options)
{
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
